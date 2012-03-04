using System;

namespace updateSystemDotNet.Core.updateActions {
#pragma warning disable

	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
	public sealed class administrationEditorAttribute : Attribute {
		private readonly string _category;
		private readonly string _description;
		private readonly string _editorTypeName;
		private readonly string _imageName;

		public administrationEditorAttribute(string category, string simageName, string description, string seditorTypeName) {
			_category = category;
			_imageName = simageName;
			_description = description;
			_editorTypeName = seditorTypeName;
		}

		public string Category {
			get { return _category; }
		}

		public string imageName {
			get { return _imageName; }
		}

		public string Description {
			get { return _description; }
		}

		public string editorTypeName {
			get { return _editorTypeName; }
		}
	}

#pragma warning enable
}