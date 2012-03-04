using System.ComponentModel;
using System.ComponentModel.Design;

namespace updateSystemDotNet.Internal.Designer {
	/// <summary>
	/// Abgeleitete Klasse für Designersupport im Visual Studio Designer
	/// </summary>
	internal class ControllerDesigner : ComponentDesigner {
		public override void Initialize(IComponent component) {
			base.Initialize(component);
			ActionLists.Add(new ControllerActionList(component));
		}
	}
}