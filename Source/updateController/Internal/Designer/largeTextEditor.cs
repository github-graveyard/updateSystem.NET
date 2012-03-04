using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace updateSystemDotNet.Internal.Designer {
	internal class largeTextEditor : UITypeEditor {
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
			var control = new TextBox();
			control.Multiline = true;
			control.Size = new Size(300, 100);
			control.ScrollBars = ScrollBars.Vertical;
			control.WordWrap = true;
			control.BorderStyle = BorderStyle.None;
			control.Text = (string) value;

			var service = (IWindowsFormsEditorService) context.GetService(typeof (IWindowsFormsEditorService));
			if (service != null) {
				service.DropDownControl(control);
			}

			return control.Text;
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
			return UITypeEditorEditStyle.DropDown;
		}
	}
}