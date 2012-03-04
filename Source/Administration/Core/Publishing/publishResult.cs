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
