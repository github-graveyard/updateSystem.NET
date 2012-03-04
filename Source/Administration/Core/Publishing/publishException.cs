using System;

namespace updateSystemDotNet.Administration.Core.Publishing {
	internal sealed class publishException : Exception {
		public publishException(string message, IPublishProvider provider)
			: base(message) {
			Provider = provider;
		}

		public IPublishProvider Provider { get; private set; }

	}
}
