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

namespace updateSystemDotNet.Administration.Core {
	internal sealed class dataContainer {

		public dataContainer() {
			Data = new Dictionary<string, object>();
		}

		private Dictionary<string, object> Data { get;  set; }

		public object this[string key] {
			get {
				return Data.ContainsKey(key) ? Data[key] : null;
			}
			set {
				if (Data.ContainsKey(key))
					Data[key] = value;
				else
					Data.Add(key, value);
			}
		}

		internal Dictionary<string, object> internalList { get { return Data; } }

	}
}
