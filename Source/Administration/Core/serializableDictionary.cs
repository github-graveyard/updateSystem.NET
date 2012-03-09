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

using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System;

namespace updateSystemDotNet.Administration.Core {
	[XmlRoot("dictionary")]
	public class serializableDictionary<TKey, TValue>
		: Dictionary<TKey, TValue>, IXmlSerializable, ICloneable {
		#region IXmlSerializable Members

		public XmlSchema GetSchema() {
			return null;
		}

		public void ReadXml(XmlReader reader) {
			var keySerializer = new XmlSerializer(typeof (TKey));
			var valueSerializer = new XmlSerializer(typeof (TValue));

			bool wasEmpty = reader.IsEmptyElement;
			reader.Read();

			if (wasEmpty)
				return;

			while (reader.NodeType != XmlNodeType.EndElement) {
				reader.ReadStartElement("item");
				reader.ReadStartElement("key");
				var key = (TKey) keySerializer.Deserialize(reader);
				reader.ReadEndElement();

				reader.ReadStartElement("value");
				var value = (TValue) valueSerializer.Deserialize(reader);
				reader.ReadEndElement();

				Add(key, value);
				reader.ReadEndElement();
				reader.MoveToContent();
			}
			reader.ReadEndElement();
		}

		public void WriteXml(XmlWriter writer) {
			var keySerializer = new XmlSerializer(typeof (TKey));
			var valueSerializer = new XmlSerializer(typeof (TValue));

			foreach (TKey key in Keys) {
				writer.WriteStartElement("item");
				writer.WriteStartElement("key");
				keySerializer.Serialize(writer, key);
				writer.WriteEndElement();
				writer.WriteStartElement("value");
				TValue value = this[key];
				valueSerializer.Serialize(writer, value);
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
		}

		#endregion

		#region ICloneable Member

		public object Clone() {
			var result = new serializableDictionary<TKey, TValue>();

			foreach (var item in this) {
				result.Add(item.Key, item.Value);
			}

			return result;
		}

		#endregion
	}
}