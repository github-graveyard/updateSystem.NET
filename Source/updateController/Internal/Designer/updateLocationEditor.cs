using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using updateSystemDotNet.Internal.UI;

namespace updateSystemDotNet.Internal.Designer {
	internal sealed class updateLocationEditor : UITypeEditor {
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
			var service = (IWindowsFormsEditorService)context.GetService(typeof(IWindowsFormsEditorService));
			if (service != null) {
				var instance = (updateController)context.Instance;
				var vEditor = new updateLocationControl((string) value, instance);
				service.DropDownControl(vEditor);
				return vEditor.Value;
			}
			return value;
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
			return UITypeEditorEditStyle.DropDown;
		}
	}
}
