using System;

namespace updateSystemDotNet.Administration.Core.Publishing {
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	internal sealed class publishProviderDescriptionAttribute : Attribute {
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
