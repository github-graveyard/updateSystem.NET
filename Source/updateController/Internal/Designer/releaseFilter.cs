using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Internal.UI;

namespace updateSystemDotNet.Internal.Designer {
	internal class releaseFilter : UITypeEditor {
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
			var service = (IWindowsFormsEditorService) context.GetService(typeof (IWindowsFormsEditorService));
			if (service != null) {
				var instance = (updateController) context.Instance;
				var releaseFilterControlInstance = new releaseFilterControl((releaseFilterType) value);
				service.DropDownControl(releaseFilterControlInstance);
				return releaseFilterControlInstance.Value;
			}
			return value;
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
			return UITypeEditorEditStyle.DropDown;
		}
	}
}