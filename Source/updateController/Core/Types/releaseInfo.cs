/*
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
using System;
using System.ComponentModel;

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Klasse welche nähere Informationen über den Zustand des Releases bereitstellt.
	/// </summary>
	/// <remarks>Neu in V.:1.1</remarks>
	[Serializable]
	[TypeConverter(typeof (ExpandableObjectConverter))]
	public sealed class releaseInfo : IEquatable<releaseInfo>, IComparable<releaseInfo> {
		/// <summary>
		/// Initialisiert eine neue Instanz von <see cref="releaseInfo"/>.
		/// </summary>
		public releaseInfo()
			: this(string.Empty, releaseTypes.Final, 1) {
		}

		/// <summary>
		/// Initialisiert eine neue Instanz von <see cref="releaseInfo"/>.
		/// </summary>
		/// <param name="version">Die Versionnummer dieses Releases.</param>
		public releaseInfo(string version)
			: this(version, releaseTypes.Final, 1) {
		}

		/// <summary>
		/// Initialisiert eine neue Instanz von <see cref="releaseInfo"/>.
		/// </summary>
		/// <param name="version">Die Versionnummer dieses Releases.</param>
		/// <param name="rType">Der Zustand des Releases (Final, Beta oder Alpha).</param>
		public releaseInfo(string version, releaseTypes rType)
			: this(version, rType, 1) {
		}

		/// <summary>
		/// Initialisiert eine neue Instanz von <see cref="releaseInfo"/>.
		/// </summary>
		/// <param name="version">Die Versionnummer dieses Releases.</param>
		/// <param name="rType">Der Zustand des Releases (Final, Beta oder Alpha).</param>
		/// <param name="rStep">Der aktuelle Entwicklungsschritt des Releaes (nur relevant wenn der Zustand Alpha oder Beta ist).</param>
		public releaseInfo(string version, releaseTypes rType, int rStep) {
			if (rStep < 1)
				throw new ArgumentException("Der Releasestep muss mit einer Zahl größer oder gleich 1 initialisiert werden.");

			Type = rType;
			Step = rStep;
			Version = version;
		}

		/// <summary>
		/// Gibt den Zustand (Final, Beta oder Alpha) des Updatepaketes zurück oder legt diesen fest.
		/// </summary>
		[DefaultValue(releaseTypes.Final)]
		public releaseTypes Type { get; set; }

		private int _step;

		/// <summary>
		/// Gibt den aktuellen Entwicklungsschritt des Releases zurück oder legt diesen fest.
		/// <para>Diese Eigenschaft ist nur relevant wenn der <see cref="Type"/> den Wert Alpha oder Beta besitzt.</para>
		/// <example>1</example>
		/// </summary>
		[DefaultValue(1)]
		public int Step {
			get { return _step; }
			set {
				if (value < 1) {
					throw new ArgumentException("Der Releasestep muss größer oder gleich '1' sein.");
				}
				_step = value;
			}
		}

		private string _version;

		/// <summary>
		/// Gibt die Versionsnummer zurück oder legt diese fest.
		/// </summary>
		public string Version {
			get { return _version; }
			set {
				if (!string.IsNullOrEmpty(value)) {
					var v = new Version(value);
				}
				_version = value;
			}
		}

#pragma warning disable

		#region IEquatable<releaseType> Member

		public bool Equals(releaseInfo other) {
			if (other == null)
				return false;

			return (Version == other.Version &&
			        Type == other.Type &&
			        Step == other.Step);
		}

		public override bool Equals(object obj) {
			var t = obj as releaseInfo;
			if (t == null)
				return false;

			return Equals(t);
		}

		#endregion

		#region IComparable<releaseType> Member

		//Rückgabewerte:
		//1 wenn aktuelles Objekt > other
		//0 wenn gleichwertig
		//-1 wenn niedriger

		public int CompareTo(releaseInfo other) {
			if (other == null)
				return 1;

			if (other.Equals(this))
				return 0;

			if (new Version(Version) > new Version(other.Version))
				return 1;

			if (new Version(Version) == new Version(other.Version)) {
				if ((int) Type > (int) other.Type) {
					return 1;
				}
				else if ((int) Type == (int) other.Type) {
					if (Step > other.Step)
						return 1;
				}
			}
			return -1;
		}

		#endregion

		#region " Operatoren "

		public static bool operator >(releaseInfo v1, releaseInfo v2) {
			return v1.CompareTo(v2) > 0;
		}

		public static bool operator <(releaseInfo v1, releaseInfo v2) {
			return (v1.CompareTo(v2) < 0);
		}

		public static bool operator ==(releaseInfo v1, releaseInfo v2) {
			if (ReferenceEquals(v1, null)) {
				return ReferenceEquals(v2, null);
			}
			return v1.Equals(v2);
		}

		public static bool operator !=(releaseInfo v1, releaseInfo v2) {
			return !(v1 == v2);
		}

		#endregion

		public override int GetHashCode() {
			return base.GetHashCode();
		}

		public override string ToString() {
			return string.Format("Version: {0}, Typ: {1}, Step: {2}", Version, Type.ToString(), Step.ToString());
		}

#pragma warning enable
	}
}