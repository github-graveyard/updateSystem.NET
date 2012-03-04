using System;
using updateSystemDotNet.Administration.Core.updateLog.Responses;

namespace updateSystemDotNet.Administration.Core.updateLog {
	internal sealed class updateLogException : Exception {
		public updateLogException(string message, defaultResponse response)
			: base(message) {
			Response = response;
		}
		public defaultResponse Response { get; private set; }
	}
}
