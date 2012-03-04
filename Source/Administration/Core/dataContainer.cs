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
