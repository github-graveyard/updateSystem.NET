using System.Text;

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Klasse zum Filtern der Releasetypen während der Updatesuche.
	/// </summary>
	/// <remarks>Neu in V.: 1.1.</remarks>
	public class releaseFilterType {
		/// <summary>
		/// Initialisiert eine neue Instanz von <see cref="releaseFilterType"/>.
		/// </summary>
		public releaseFilterType() {
			checkForFinal = true;
		}

		/// <summary>
		/// Gibt zurück oder legt fest, ob nach Finalenversionen gesucht werden soll.
		/// </summary>
		public bool checkForFinal { get; set; }

		/// <summary>
		/// Gibt zurück oder legt fest, ob nach Betaversionen gesucht werden soll.
		/// </summary>
		public bool checkForBeta { get; set; }

		/// <summary>
		/// Gibt zurück oder legt fest, ob nach Alphaversionen gesucht werden soll.
		/// </summary>
		public bool checkForAlpha { get; set; }

		/// <summary>
		/// Überprüft ob der Release Type den im Filter angegebenen Werten entspricht.
		/// </summary>
		/// <param name="releaseType">Der zu prüfende Releasetype.</param>
		/// <returns>Gibt True zurück wenn der Releasetype mit dem Filter überein stimmt, andernfalls False.</returns>
		internal bool Contains(releaseTypes releaseType) {
			if (releaseType == releaseTypes.Final && checkForFinal)
				return true;
			if (releaseType == releaseTypes.Beta && checkForBeta)
				return true;
			if (releaseType == releaseTypes.Alpha && checkForAlpha)
				return true;

			return false;
		}

		/// <summary></summary>
		/// <returns></returns>
		public override string ToString() {
			if (!checkForFinal && !checkForBeta && !checkForAlpha)
				return "Kein";

			var sbValue = new StringBuilder();

			if (checkForFinal)
				sbValue.Append("Final;");
			if (checkForBeta)
				sbValue.Append("Beta;");
			if (checkForAlpha)
				sbValue.Append("Alpha;");

			return sbValue.ToString();
		}
	}
}