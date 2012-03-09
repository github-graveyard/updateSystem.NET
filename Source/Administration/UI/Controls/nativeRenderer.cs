#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace updateSystemDotNet.Administration.UI.Controls {
	internal enum ToolbarTheme {
		Toolbar,
		MediaToolbar,
		CommunicationsToolbar,
		BrowserTabBar,
		HelpBar
	}

	internal class nativeRenderer : ToolStripSystemRenderer {
		private const int RebarBackground = 6;
		private VisualStyleRenderer renderer;

		public nativeRenderer(ToolbarTheme theme) {
			Theme = theme;
		}

		public bool IsSupported {
			get {
				if (!VisualStyleRenderer.IsSupported) {
					return false;
				}
				return VisualStyleRenderer.IsElementDefined(VisualStyleElement.CreateElement("Menu", 7, 1));
			}
		}

		private string MenuClass {
			get { return (SubclassPrefix + "Menu"); }
		}

		private string RebarClass {
			get { return (SubclassPrefix + "Rebar"); }
		}

		private string SubclassPrefix {
			get {
				switch (Theme) {
					case ToolbarTheme.MediaToolbar:
						return "Media::";

					case ToolbarTheme.CommunicationsToolbar:
						return "Communications::";

					case ToolbarTheme.BrowserTabBar:
						return "BrowserTabBar::";

					case ToolbarTheme.HelpBar:
						return "Help::";
				}
				return string.Empty;
			}
		}

		public ToolbarTheme Theme { get; set; }

		private string ToolbarClass {
			get { return (SubclassPrefix + "ToolBar"); }
		}

		private bool EnsureRenderer() {
			if (!IsSupported) {
				return false;
			}
			if (renderer == null) {
				renderer = new VisualStyleRenderer(VisualStyleElement.Button.PushButton.Normal);
			}
			return true;
		}

		private Rectangle GetBackgroundRectangle(ToolStripItem item) {
			if (!item.IsOnDropDown) {
				return new Rectangle(new Point(), item.Bounds.Size);
			}
			Rectangle bounds = item.Bounds;
			bounds.X = item.ContentRectangle.X + 1;
			bounds.Width = item.ContentRectangle.Width - 1;
			bounds.Y = 0;
			return bounds;
		}

		private static int GetItemState(ToolStripItem item) {
			bool selected = item.Selected;
			if (item.IsOnDropDown) {
				if (item.Enabled) {
					if (!selected) {
						return 1;
					}
					return 2;
				}
				if (!selected) {
					return 3;
				}
				return 4;
			}
			if (item.Pressed) {
				if (!item.Enabled) {
					return 6;
				}
				return 3;
			}
			if (item.Enabled) {
				if (!selected) {
					return 1;
				}
				return 2;
			}
			if (!selected) {
				return 4;
			}
			return 5;
		}

		private Color GetItemTextColor(ToolStripItem item) {
			int part = item.IsOnDropDown ? 14 : 8;
			renderer.SetParameters(MenuClass, part, GetItemState(item));
			return renderer.GetColor(ColorProperty.TextColor);
		}

		private Padding GetThemeMargins(IDeviceContext dc, MarginTypes marginType) {
			Padding padding;
			try {
				NativeMethods.MARGINS margins;
				IntPtr hdc = dc.GetHdc();
				if (
					NativeMethods.GetThemeMargins(renderer.Handle, hdc, renderer.Part, renderer.State, (int) marginType, IntPtr.Zero,
					                              out margins) == 0) {
					return new Padding(margins.cxLeftWidth, margins.cyTopHeight, margins.cxRightWidth, margins.cyBottomHeight);
				}
				padding = new Padding(0);
			}
			finally {
				dc.ReleaseHdc();
			}
			return padding;
		}

		protected override void Initialize(ToolStrip toolStrip) {
			if (toolStrip.Parent is ToolStripPanel) {
				toolStrip.BackColor = Color.Transparent;
			}
			base.Initialize(toolStrip);
		}

		protected override void InitializePanel(ToolStripPanel toolStripPanel) {
			foreach (Control control in toolStripPanel.Controls) {
				if (control is ToolStrip) {
					Initialize((ToolStrip) control);
				}
			}
			base.InitializePanel(toolStripPanel);
		}

		protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e) {
			if (EnsureRenderer()) {
				e.ArrowColor = GetItemTextColor(e.Item);
			}
			base.OnRenderArrow(e);
		}

		protected override void OnRenderImageMargin(ToolStripRenderEventArgs e) {
			if (EnsureRenderer()) {
				if (e.ToolStrip.IsDropDown) {
					renderer.SetParameters(MenuClass, 13, 0);
					Padding themeMargins = GetThemeMargins(e.Graphics, MarginTypes.Sizing);
					int num = ((((e.ToolStrip.Width - e.ToolStrip.DisplayRectangle.Width) - themeMargins.Left) - themeMargins.Right) -
					           1) - e.AffectedBounds.Width;
					Rectangle affectedBounds = e.AffectedBounds;
					affectedBounds.Y += 2;
					affectedBounds.Height -= 4;
					int width = renderer.GetPartSize(e.Graphics, ThemeSizeType.True).Width;
					if (e.ToolStrip.RightToLeft == RightToLeft.Yes) {
						affectedBounds = new Rectangle(affectedBounds.X - num, affectedBounds.Y, width, affectedBounds.Height) {
						                                                                                                       	X =
						                                                                                                       		affectedBounds
						                                                                                                       			.X +
						                                                                                                       		width
						                                                                                                       };
					}
					else {
						affectedBounds = new Rectangle((affectedBounds.Width + num) - width, affectedBounds.Y, width,
						                               affectedBounds.Height);
					}
					renderer.DrawBackground(e.Graphics, affectedBounds);
				}
			}
			else {
				base.OnRenderImageMargin(e);
			}
		}

		protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e) {
			if (EnsureRenderer()) {
				Rectangle backgroundRectangle = GetBackgroundRectangle(e.Item);
				backgroundRectangle.Width = backgroundRectangle.Height;
				if (e.Item.RightToLeft == RightToLeft.Yes) {
					backgroundRectangle =
						new Rectangle((e.ToolStrip.ClientSize.Width - backgroundRectangle.X) - backgroundRectangle.Width,
						              backgroundRectangle.Y, backgroundRectangle.Width, backgroundRectangle.Height);
				}
				renderer.SetParameters(MenuClass, 12, e.Item.Enabled ? 2 : 1);
				renderer.DrawBackground(e.Graphics, backgroundRectangle);
				Rectangle imageRectangle = e.ImageRectangle;
				imageRectangle.X = (backgroundRectangle.X + (backgroundRectangle.Width/2)) - (imageRectangle.Width/2);
				imageRectangle.Y = (backgroundRectangle.Y + (backgroundRectangle.Height/2)) - (imageRectangle.Height/2);
				renderer.SetParameters(MenuClass, 11, e.Item.Enabled ? 1 : 2);
				renderer.DrawBackground(e.Graphics, imageRectangle);
			}
			else {
				base.OnRenderItemCheck(e);
			}
		}

		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e) {
			if (EnsureRenderer()) {
				e.TextColor = GetItemTextColor(e.Item);
			}
			base.OnRenderItemText(e);
		}

		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) {
			if (EnsureRenderer()) {
				int part = e.Item.IsOnDropDown ? 14 : 8;
				renderer.SetParameters(MenuClass, part, GetItemState(e.Item));
				Rectangle backgroundRectangle = GetBackgroundRectangle(e.Item);
				renderer.DrawBackground(e.Graphics, backgroundRectangle, backgroundRectangle);
			}
			else {
				base.OnRenderMenuItemBackground(e);
			}
		}

		protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e) {
			if (EnsureRenderer()) {
				string rebarClass = RebarClass;
				if (Theme == ToolbarTheme.BrowserTabBar) {
					rebarClass = "Rebar";
				}
				int state = VisualStyleElement.Rebar.Chevron.Normal.State;
				if (e.Item.Pressed) {
					state = VisualStyleElement.Rebar.Chevron.Pressed.State;
				}
				else if (e.Item.Selected) {
					state = VisualStyleElement.Rebar.Chevron.Hot.State;
				}
				renderer.SetParameters(rebarClass, VisualStyleElement.Rebar.Chevron.Normal.Part, state);
				renderer.DrawBackground(e.Graphics, new Rectangle(Point.Empty, e.Item.Size));
			}
			else {
				base.OnRenderOverflowButtonBackground(e);
			}
		}

		protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e) {
			if (e.ToolStrip.IsDropDown && EnsureRenderer()) {
				renderer.SetParameters(MenuClass, 15, 0);
				var bounds = new Rectangle(e.ToolStrip.DisplayRectangle.Left, 0, e.ToolStrip.DisplayRectangle.Width, e.Item.Height);
				renderer.DrawBackground(e.Graphics, bounds, bounds);
			}
			else {
				base.OnRenderSeparator(e);
			}
		}

		protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e) {
			if (EnsureRenderer()) {
				var item = (ToolStripSplitButton) e.Item;
				base.OnRenderSplitButtonBackground(e);
				OnRenderArrow(new ToolStripArrowRenderEventArgs(e.Graphics, item, item.DropDownButtonBounds, Color.Red,
				                                                ArrowDirection.Down));
			}
			else {
				base.OnRenderSplitButtonBackground(e);
			}
		}

		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e) {
			if (EnsureRenderer()) {
				if (e.ToolStrip.IsDropDown) {
					renderer.SetParameters(MenuClass, 9, 0);
				}
				else {
					if (e.ToolStrip.Parent is ToolStripPanel) {
						return;
					}
					if (VisualStyleRenderer.IsElementDefined(VisualStyleElement.CreateElement(RebarClass, RebarBackground, 0))) {
						renderer.SetParameters(RebarClass, RebarBackground, 0);
					}
					else {
						renderer.SetParameters(RebarClass, 0, 0);
					}
				}
				if (renderer.IsBackgroundPartiallyTransparent()) {
					renderer.DrawParentBackground(e.Graphics, e.ToolStrip.ClientRectangle, e.ToolStrip);
				}
				renderer.DrawBackground(e.Graphics, e.ToolStrip.ClientRectangle, e.AffectedBounds);
			}
			else {
				base.OnRenderToolStripBackground(e);
			}
		}

		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) {
			if (EnsureRenderer()) {
				renderer.SetParameters(MenuClass, 10, 0);
				if (e.ToolStrip.IsDropDown) {
					Region clip = e.Graphics.Clip;
					Rectangle clientRectangle = e.ToolStrip.ClientRectangle;
					clientRectangle.Inflate(-1, -1);
					e.Graphics.ExcludeClip(clientRectangle);
					renderer.DrawBackground(e.Graphics, e.ToolStrip.ClientRectangle, e.AffectedBounds);
					e.Graphics.Clip = clip;
				}
			}
			else {
				base.OnRenderToolStripBorder(e);
			}
		}

		protected override void OnRenderToolStripPanelBackground(ToolStripPanelRenderEventArgs e) {
			if (EnsureRenderer()) {
				if (VisualStyleRenderer.IsElementDefined(VisualStyleElement.CreateElement(RebarClass, RebarBackground, 0))) {
					renderer.SetParameters(RebarClass, RebarBackground, 0);
				}
				else {
					renderer.SetParameters(RebarClass, 0, 0);
				}
				if (renderer.IsBackgroundPartiallyTransparent()) {
					renderer.DrawParentBackground(e.Graphics, e.ToolStripPanel.ClientRectangle, e.ToolStripPanel);
				}
				renderer.DrawBackground(e.Graphics, e.ToolStripPanel.ClientRectangle);
				e.Handled = true;
			}
			else {
				base.OnRenderToolStripPanelBackground(e);
			}
		}

		private VisualStyleElement Subclass(VisualStyleElement element) {
			return VisualStyleElement.CreateElement(SubclassPrefix + element.ClassName, element.Part, element.State);
		}

		#region Nested type: MarginTypes

		private enum MarginTypes {
			Caption = 3603,
			Content = 3602,
			Sizing = 3601
		}

		#endregion

		#region Nested type: MenuBarItemStates

		private enum MenuBarItemStates {
			Disabled = 4,
			DisabledHover = 5,
			DisabledPushed = 6,
			Hover = 2,
			Normal = 1,
			Pushed = 3
		}

		#endregion

		#region Nested type: MenuBarStates

		private enum MenuBarStates {
			Active = 1,
			Inactive = 2
		}

		#endregion

		#region Nested type: MenuParts

		private enum MenuParts {
			BarBackground = 7,
			BarDropDownTMSchema = 4,
			BarItem = 8,
			BarItemTMSchema = 3,
			ChevronTMSchema = 5,
			DropDownTMSchema = 2,
			ItemTMSchema = 1,
			PopupBackground = 9,
			PopupBorders = 10,
			PopupCheck = 11,
			PopupCheckBackground = 12,
			PopupGutter = 13,
			PopupItem = 14,
			PopupSeparator = 15,
			PopupSubmenu = 16,
			SeparatorTMSchema = 6,
			SystemClose = 17,
			SystemMaximize = 18,
			SystemMinimize = 19,
			SystemRestore = 20
		}

		#endregion

		#region Nested type: MenuPopupCheckBackgroundStates

		private enum MenuPopupCheckBackgroundStates {
			Bitmap = 3,
			Disabled = 1,
			Normal = 2
		}

		#endregion

		#region Nested type: MenuPopupCheckStates

		private enum MenuPopupCheckStates {
			BulletDisabled = 4,
			BulletNormal = 3,
			CheckmarkDisabled = 2,
			CheckmarkNormal = 1
		}

		#endregion

		#region Nested type: MenuPopupItemStates

		private enum MenuPopupItemStates {
			Disabled = 3,
			DisabledHover = 4,
			Hover = 2,
			Normal = 1
		}

		#endregion

		#region Nested type: MenuPopupSubMenuStates

		private enum MenuPopupSubMenuStates {
			Disabled = 2,
			Normal = 1
		}

		#endregion

		#region Nested type: NativeMethods

		internal static class NativeMethods {
			// Methods
			[DllImport("uxtheme.dll")]
			public static extern int GetThemeMargins(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, int iPropId,
			                                         IntPtr rect, out MARGINS pMargins);

			// Nested Types

			#region Nested type: MARGINS

			[StructLayout(LayoutKind.Sequential)]
			public struct MARGINS {
				public int cxLeftWidth;
				public int cxRightWidth;
				public int cyTopHeight;
				public int cyBottomHeight;
			}

			#endregion
		}

		#endregion
	}
}