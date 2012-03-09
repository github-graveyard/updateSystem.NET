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
namespace updateSystemDotNet.Administration.Core.Publishing {
	internal sealed class publishResult {

		/// <summary>Gibt den Fehler zurück der beim Publishing aufgetreten ist. Nur wenn !<see cref="Successful"/></summary>
		public Exception Error { get; set; }

		/// <summary>Gibt True zurück wenn der Publishvorgang erfolgreich ausgeführt wurde, andernfalls False.</summary>
		public bool Successful { get { return Error == null; }}

		/// <summary>Gibt den Provider zurück, zu welchem dieses Result gehört.</summary>
		public IPublishProvider Provider { get; set; }

	}
}
