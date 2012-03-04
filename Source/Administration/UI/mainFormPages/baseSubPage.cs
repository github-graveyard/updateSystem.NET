namespace updateSystemDotNet.Administration.UI.mainFormPages {
	internal class baseSubPage : basePage {

		/// <summary>Ein Argument mit spezifischen Daten welches der Page mitgegeben wird.</summary>
		public object Argument { get; set; }

		/// <summary>Die Page von welcher diese Angezeigt wird.</summary>
		public basePage parentPage { get; set; }

		public override bool hideFromNavigation {
			get { return true; }
		}

		public override System.Windows.Forms.TreeNode Node {
			get {
				base.Node.ImageKey = (pageSymbol == null ? parentPage.Id : Id);
				base.Node.SelectedImageKey = (pageSymbol == null ? parentPage.Id : Id);
				base.Node.Tag = this;
				return base.Node;
			}
		}

	}
}