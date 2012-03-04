using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using updateSystemDotNet.Internal.UI;

namespace updateSystemDotNet.Internal.Designer {
	internal class versionEditor : UITypeEditor {
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
			var service = (IWindowsFormsEditorService) context.GetService(typeof (IWindowsFormsEditorService));
			if (service != null) {
				var instance = (updateController) context.Instance;
				var vEditor = new versionEditorControl((string) value, instance.retrieveHostVersion);
				service.DropDownControl(vEditor);
				return parseVersion(vEditor.Value);
			}
			return value;
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
			return UITypeEditorEditStyle.DropDown;
		}

		private object parseVersion(string version) {
			try {
				return new Version(version).ToString();
			}
			catch {
				return string.Empty;
			}
		}
	}
}