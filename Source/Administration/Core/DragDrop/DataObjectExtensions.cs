#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;

namespace updateSystemDotNet.Administration.Core.DragDrop {
	/// <summary>
	/// Provides extended functionality for the COM IDataObject interface.
	/// </summary>
	public static class ComDataObjectExtensions {
		#region DLL imports

		[DllImport("user32.dll")]
		private static extern uint RegisterClipboardFormat(string lpszFormatName);

		[DllImport("ole32.dll")]
		private static extern void ReleaseStgMedium(ref STGMEDIUM pmedium);

		[DllImport("ole32.dll")]
		private static extern int CreateStreamOnHGlobal(IntPtr hGlobal, bool fDeleteOnRelease, out IStream ppstm);

		#endregion // DLL imports

		#region Native constants

		// CFSTR_DROPDESCRIPTION
		private const string DropDescriptionFormat = "DropDescription";

		#endregion // Native constants

		private const TYMED TYMED_ANY =
			TYMED.TYMED_ENHMF
			| TYMED.TYMED_FILE
			| TYMED.TYMED_GDI
			| TYMED.TYMED_HGLOBAL
			| TYMED.TYMED_ISTORAGE
			| TYMED.TYMED_ISTREAM
			| TYMED.TYMED_MFPICT;

		private static readonly Guid ManagedDataStamp = new Guid("D98D9FD6-FA46-4716-A769-F3451DFBE4B4");

		/// <summary>
		/// Sets the drop description for the drag image manager.
		/// </summary>
		/// <param name="dataObject">The DataObject to set.</param>
		/// <param name="dropDescription">The drop description.</param>
		public static void SetDropDescription(this IDataObject dataObject, DropDescription dropDescription) {
			FORMATETC formatETC;
			FillFormatETC(DropDescriptionFormat, TYMED.TYMED_HGLOBAL, out formatETC);

			// We need to set the drop description as an HGLOBAL.
			// Allocate space ...
			IntPtr pDD = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (DropDescription)));
			try {
				// ... and marshal the data
				Marshal.StructureToPtr(dropDescription, pDD, false);

				// The medium wraps the HGLOBAL
				STGMEDIUM medium;
				medium.pUnkForRelease = null;
				medium.tymed = TYMED.TYMED_HGLOBAL;
				medium.unionmember = pDD;

				// Set the data
				IDataObject dataObjectCOM = dataObject;
				dataObjectCOM.SetData(ref formatETC, ref medium, true);
			}
			catch {
				// If we failed, we need to free the HGLOBAL memory
				Marshal.FreeHGlobal(pDD);
				throw;
			}
		}

		/// <summary>
		/// Gets the DropDescription format data.
		/// </summary>
		/// <param name="dataObject">The DataObject.</param>
		/// <returns>The DropDescription, if set.</returns>
		public static object GetDropDescription(this IDataObject dataObject) {
			FORMATETC formatETC;
			FillFormatETC(DropDescriptionFormat, TYMED.TYMED_HGLOBAL, out formatETC);

			if (0 == dataObject.QueryGetData(ref formatETC)) {
				STGMEDIUM medium;
				dataObject.GetData(ref formatETC, out medium);
				try {
					return (DropDescription) Marshal.PtrToStructure(medium.unionmember, typeof (DropDescription));
				}
				finally {
					ReleaseStgMedium(ref medium);
				}
			}

			return null;
		}

		// Combination of all non-null TYMEDs

		/// <summary>
		/// Sets up an advisory connection to the data object.
		/// </summary>
		/// <param name="dataObject">The data object on which to set the advisory connection.</param>
		/// <param name="sink">The advisory sink.</param>
		/// <param name="format">The format on which to callback on.</param>
		/// <param name="advf">Advisory flags. Can be 0.</param>
		/// <returns>The ID of the newly created advisory connection.</returns>
		public static int Advise(this IDataObject dataObject, IAdviseSink sink, string format, ADVF advf) {
			// Internally, we'll listen for any TYMED
			FORMATETC formatETC;
			FillFormatETC(format, TYMED_ANY, out formatETC);

			int connection;
			int hr = dataObject.DAdvise(ref formatETC, advf, sink, out connection);
			if (hr != 0)
				Marshal.ThrowExceptionForHR(hr);
			return connection;
		}

		/// <summary>
		/// Fills a FORMATETC structure.
		/// </summary>
		/// <param name="format">The format name.</param>
		/// <param name="tymed">The accepted TYMED.</param>
		/// <param name="formatETC">The structure to fill.</param>
		private static void FillFormatETC(string format, TYMED tymed, out FORMATETC formatETC) {
			formatETC.cfFormat = (short) RegisterClipboardFormat(format);
			formatETC.dwAspect = DVASPECT.DVASPECT_CONTENT;
			formatETC.lindex = -1;
			formatETC.ptd = IntPtr.Zero;
			formatETC.tymed = tymed;
		}

		// Identifies data that we need to do custom marshaling on

		/// <summary>
		/// Sets managed data to a clipboard DataObject.
		/// </summary>
		/// <param name="dataObject">The DataObject to set the data on.</param>
		/// <param name="format">The clipboard format.</param>
		/// <param name="data">The data object.</param>
		/// <remarks>
		/// Because the underlying data store is not storing managed objects, but
		/// unmanaged ones, this function provides intelligent conversion, allowing
		/// you to set unmanaged data into the COM implemented IDataObject.</remarks>
		public static void SetManagedData(this IDataObject dataObject, string format, object data) {
			// Initialize the format structure
			FORMATETC formatETC;
			FillFormatETC(format, TYMED.TYMED_HGLOBAL, out formatETC);

			// Serialize/marshal our data into an unmanaged medium
			STGMEDIUM medium;
			GetMediumFromObject(data, out medium);
			try {
				// Set the data on our data object
				dataObject.SetData(ref formatETC, ref medium, true);
			}
			catch {
				// On exceptions, release the medium
				ReleaseStgMedium(ref medium);
				throw;
			}
		}

		/// <summary>
		/// Gets managed data from a clipboard DataObject.
		/// </summary>
		/// <param name="dataObject">The DataObject to obtain the data from.</param>
		/// <param name="format">The format for which to get the data in.</param>
		/// <returns>The data object instance.</returns>
		public static object GetManagedData(this IDataObject dataObject, string format) {
			FORMATETC formatETC;
			FillFormatETC(format, TYMED.TYMED_HGLOBAL, out formatETC);

			// Get the data as a stream
			STGMEDIUM medium;
			dataObject.GetData(ref formatETC, out medium);

			IStream nativeStream;
			try {
				int hr = CreateStreamOnHGlobal(medium.unionmember, true, out nativeStream);
				if (hr != 0) {
					return null;
				}
			}
			finally {
				ReleaseStgMedium(ref medium);
			}


			// Convert the native stream to a managed stream            
			STATSTG statstg;
			nativeStream.Stat(out statstg, 0);
			if (statstg.cbSize > int.MaxValue)
				throw new NotSupportedException();
			var buf = new byte[statstg.cbSize];
			nativeStream.Read(buf, (int) statstg.cbSize, IntPtr.Zero);
			var dataStream = new MemoryStream(buf);

			// Check for our stamp
			int sizeOfGuid = Marshal.SizeOf(typeof (Guid));
			var guidBytes = new byte[sizeOfGuid];
			if (dataStream.Length >= sizeOfGuid) {
				if (sizeOfGuid == dataStream.Read(guidBytes, 0, sizeOfGuid)) {
					var guid = new Guid(guidBytes);
					if (ManagedDataStamp.Equals(guid)) {
						// Stamp matched, so deserialize
						var formatter = new BinaryFormatter();
						var dataType = (Type) formatter.Deserialize(dataStream);
						object data2 = formatter.Deserialize(dataStream);
						if (data2.GetType() == dataType)
							return data2;
						else if (data2 is string)
							return ConvertDataFromString((string) data2, dataType);
						else
							return null;
					}
				}
			}

			// Stamp didn't match... attempt to reset the seek pointer
			if (dataStream.CanSeek)
				dataStream.Position = 0;
			return null;
		}

		#region Helper methods

		/// <summary>
		/// Serializes managed data to an HGLOBAL.
		/// </summary>
		/// <param name="data">The managed data object.</param>
		/// <returns>An STGMEDIUM pointing to the allocated HGLOBAL.</returns>
		private static void GetMediumFromObject(object data, out STGMEDIUM medium) {
			// We'll serialize to a managed stream temporarily
			var stream = new MemoryStream();

			// Write an indentifying stamp, so we can recognize this as custom
			// marshaled data.
			stream.Write(ManagedDataStamp.ToByteArray(), 0, Marshal.SizeOf(typeof (Guid)));

			// Now serialize the data. Note, if the data is not directly serializable,
			// we'll try type conversion. Also, we serialize the type. That way,
			// during deserialization, we know which type to convert back to, if
			// appropriate.
			var formatter = new BinaryFormatter();
			formatter.Serialize(stream, data.GetType());
			formatter.Serialize(stream, GetAsSerializable(data));

			// Now copy to an HGLOBAL
			byte[] bytes = stream.GetBuffer();
			IntPtr p = Marshal.AllocHGlobal(bytes.Length);
			try {
				Marshal.Copy(bytes, 0, p, bytes.Length);
			}
			catch {
				// Make sure to free the memory on exceptions
				Marshal.FreeHGlobal(p);
				throw;
			}

			// Now allocate an STGMEDIUM to wrap the HGLOBAL
			medium.unionmember = p;
			medium.tymed = TYMED.TYMED_HGLOBAL;
			medium.pUnkForRelease = null;
		}

		/// <summary>
		/// Gets a serializable object representing the data.
		/// </summary>
		/// <param name="obj">The data.</param>
		/// <returns>If the data is serializable, then it is returned. Otherwise,
		/// type conversion is attempted. If successful, a string value will be
		/// returned.</returns>
		private static object GetAsSerializable(object obj) {
			// If the data is directly serializable, run with it
			if (obj.GetType().IsSerializable)
				return obj;

			// Attempt type conversion to a string, but only if we know it can be converted back
			TypeConverter conv = GetTypeConverterForType(obj.GetType());
			if (conv != null && conv.CanConvertTo(typeof (string)) && conv.CanConvertFrom(typeof (string)))
				return conv.ConvertToInvariantString(obj);

			throw new NotSupportedException("Cannot serialize the object");
		}

		/// <summary>
		/// Converts data from a string to the specified format.
		/// </summary>
		/// <param name="data">The data to convert.</param>
		/// <param name="dataType">The target data type.</param>
		/// <returns>Returns the converted data instance.</returns>
		private static object ConvertDataFromString(string data, Type dataType) {
			TypeConverter conv = GetTypeConverterForType(dataType);
			if (conv != null && conv.CanConvertFrom(typeof (string)))
				return conv.ConvertFromInvariantString(data);

			throw new NotSupportedException("Cannot convert data");
		}

		/// <summary>
		/// Gets a TypeConverter instance for the specified type.
		/// </summary>
		/// <param name="dataType">The type.</param>
		/// <returns>An instance of a TypeConverter for the type, if one exists.</returns>
		private static TypeConverter GetTypeConverterForType(Type dataType) {
			var typeConverterAttrs =
				(TypeConverterAttribute[]) dataType.GetCustomAttributes(typeof (TypeConverterAttribute), true);
			if (typeConverterAttrs.Length > 0) {
				Type convType = Type.GetType(typeConverterAttrs[0].ConverterTypeName);
				return (TypeConverter) Activator.CreateInstance(convType);
			}

			return null;
		}

		#endregion // Helper methods
	}
}