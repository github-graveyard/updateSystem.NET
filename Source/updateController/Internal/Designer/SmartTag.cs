/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
#region " Usings "

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace updateSystemDotNet.Internal.Designer {
	//#region " SmartTagControlDesigner "

	//[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
	//internal class SmartTagControlDesigner<DesignerActionList_Class> : ControlDesigner where DesignerActionList_Class : DesignerActionList
	//{
	//    private DesignerActionListCreator<DesignerActionList_Class> m_ActionListCreator = new DesignerActionListCreator<DesignerActionList_Class>();

	//    public override DesignerActionListCollection ActionLists
	//    {
	//        get
	//        {
	//            return m_ActionListCreator.GetActionListCollection(this.Component);
	//        }
	//    }

	//}

	//#endregion

	//#region " SmartTagComponentDesigner "

	//[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
	//internal class SmartTagComponentDesigner<DesignerActionList_Class> : ComponentDesigner where DesignerActionList_Class : DesignerActionList
	//{
	//    private DesignerActionListCreator<DesignerActionList_Class> m_ActionListCreator = new DesignerActionListCreator<DesignerActionList_Class>();

	//    public override DesignerActionListCollection ActionLists
	//    {
	//        get
	//        {
	//            return m_ActionListCreator.GetActionListCollection(this.Component);
	//        }
	//    }

	//}

	//#endregion

	//#region " DesignerActionListCreator "

	///// <summary>
	///// Cache the action list collection for better performance. Usuallry, this class will not be used directly by you.
	///// </summary>
	//internal class DesignerActionListCreator<DesignerActionList_Class> where DesignerActionList_Class : DesignerActionList
	//{
	//    private DesignerActionListCollection m_ActionLists;

	//    public DesignerActionListCreator()
	//    { }

	//    public DesignerActionListCollection GetActionListCollection(IComponent component)
	//    {
	//        if (m_ActionLists != null)
	//        {
	//            try
	//            {
	//                m_ActionLists = new DesignerActionListCollection();
	//                Object obj = Activator.CreateInstance(typeof(DesignerActionList_Class), component);
	//                m_ActionLists.Add((DesignerActionList_Class)obj);
	//            }
	//            catch (Exception ex) { throw ex; }
	//        }

	//        return m_ActionLists;
	//    }

	//}

	//#endregion

	#region " SmartTagActionListBase "

	internal abstract class SmartTagActionListBase : DesignerActionList {
		private readonly DesignerActionItemCollection m_ActionList;
		private readonly Control m_Control;
		private readonly DesignerActionUIService m_DesignerService;

		public SmartTagActionListBase(IComponent component)
			: base(component) {
			m_DesignerService = (DesignerActionUIService) GetService(typeof (DesignerActionUIService));
			m_ActionList = new DesignerActionItemCollection();
			if (component is Control) {
				m_Control = (Control) component;
			}
			else {
				m_Control = null;
			}
		}

		/// <summary>
		/// Gets access to the Designer Action UI Serice which manages the user interface (UI) for the smart tag panel.
		/// </summary>
		public DesignerActionUIService DesignerService {
			get { return m_DesignerService; }
		}

		/// <summary>
		/// Gets the interal DesignerActionItemCollection of this class which represents a collection if Action Items to display on the smart tag panel.
		/// </summary>
		public DesignerActionItemCollection ActionList {
			get { return m_ActionList; }
		}

		/// <summary>
		/// Gets the container which sites this Component or Control.
		/// </summary>
		public IContainer Container {
			get { return Component.Site.Container; }
		}

		/// <summary>
		/// Gets this Control (if associated Components is a Control).
		/// </summary>
		public Control Control {
			get { return m_Control; }
		}

		public string Name {
			get { return Component.Site.Name; } //if it is a Control, this statemant is equal: m_Control.Name
			set {
				if (value != Name) {
					SetPropertyByName(m_Control, "Name", value);
				} //undo is available
				else {
					Component.Site.Name = value;
				} //undo will not be available in this case
			}
		}

		/// <summary>
		/// Note: This property is valid only for Controls (Not Components)
		/// </summary>
		public RightToLeft RightToLeft {
			get {
				if (m_Control != null) {
					return m_Control.RightToLeft;
				}
				else {
					return new RightToLeft();
				}
			}
			set { SetPropertyByName(m_Control, "RightToLeft", value); }
		}

		/// <summary>
		/// This property is valid only for Controls (Not Components)
		/// </summary>
		public Font Font {
			get {
				if (m_Control != null) {
					return m_Control.Font;
				}
				else {
					return null;
				}
			}
			set { SetPropertyByName(m_Control, "Font", value); }
		}

		/// <summary>
		/// This property is valid only for Controls (Not Components)
		/// </summary>
		public string Text {
			get {
				if (m_Control != null) {
					return m_Control.Text;
				}
				else {
					return null;
				}
			}
			set { SetPropertyByName(m_Control, "Text", value); }
		}

		/// <summary>
		/// Refreshes the contets of designer smart tag panel.
		/// </summary>
		public void RefreshDesigner() {
			if (m_DesignerService != null) {
				m_DesignerService.Refresh(Component);
			}
		}

		/// <summary>
		/// Hides the smart tag panel of this component.
		/// </summary>
		public void HideDesigner() {
			if (m_DesignerService != null) {
				m_DesignerService.HideUI(Component);
			}
		}

		/// <summary>
		/// Sets the specified property of specified control to the given value.
		/// Note: by means of Reflection methods, "Undo" and "Menu Updates" in IDE work properly! (donot modify control properties directly through the code, but use this method)
		/// </summary>
		/// <param name="ComponentObject">The Name of the Component.</param>
		/// <param name="propName">The Name from the Property</param>
		/// <param name="value">The Value</param>
		public void SetPropertyByName(object ComponentObject, string propName, object value) {
			if (ComponentObject == null) {
				return;
			}

			PropertyDescriptor prop = TypeDescriptor.GetProperties(ComponentObject)[propName];
			if (prop != null) {
				try {
					prop.SetValue(ComponentObject, value);
				}
				catch (Exception) {
					string sValue = (value != null) ? sValue = value.ToString() : sValue = string.Empty;
					MessageBox.Show(
						string.Format("SmartTagActionList: Cannot set {0} property to the specified value: {1}", prop.Name, sValue),
						"Error");
				}
			}
		}

		/// <summary>
		/// Clears the text of the related Control. Note: this is valid only for Controls (Not Components)
		/// </summary>
		public void ClearControlText() {
			if (m_Control != null && !string.IsNullOrEmpty(Text)) {
				Text = string.Empty;
				RefreshDesigner();
			}
		}

		/// <summary>
		/// Clears all action items.
		/// </summary>
		public void ClearActionList() {
			m_ActionList.Clear();
		}

		/// <summary>
		/// Adds a static Text item to ActionItems. Call it in GetSortedActionItems() function.
		/// </summary>
		public void AddActionText(string displayName, string category) {
			m_ActionList.Add(new DesignerActionTextItem(displayName, category));
		}

		/// <summary>
		/// Adds a Property item to ActionItems. Call it in GetSortedActionItems() function.
		/// </summary>
		/// <param name="memberName">The property name defined in your DesignerActionList (Not your control property!)</param>
		/// <param name="category">The Category for this Property.</param>
		/// <param name="description">The Description for this Property</param>
		/// <param name="displayName">The Displayname for this Property</param>
		public void AddActionProperty(string memberName, string displayName, string category, string description) {
			m_ActionList.Add(new DesignerActionPropertyItem(memberName, displayName, category, description));
		}

		/// <summary>
		/// Adds a Method item to ActionItems. Call it in GetSortedActionItems() function.
		/// </summary>
		/// <param name="memberName">The property name defined in your DesignerActionList (Not yout control property!)</param>
		/// <param name="category">The Category for this Method.</param>
		/// <param name="description">The Description for this Method.</param>
		/// <param name="displayName">The Displayname for this Mathod.</param>
		/// <param name="includeAsDesignerVerb">Set this to True if this Method should used as DesignerVerb, otherwise False.</param>
		public void AddActionMethod(string memberName, string displayName, string category, string description,
		                            bool includeAsDesignerVerb) {
			m_ActionList.Add(new DesignerActionMethodItem(this, memberName, displayName, category, description,
			                                              includeAsDesignerVerb));
		}

		/// <summary>
		/// Adds a Header (Category) item to ActionItems. Call it in GetSortedActionItems() function
		/// </summary>
		public void AddActionHeader(string displayName) {
			m_ActionList.Add(new DesignerActionHeaderItem(displayName));
		}

		/// <summary>
		/// Usually you should override DefineSortedActionItems() method to define your action items.
		/// But if you want, You can override this function to specify your smart tag action items.
		/// Call AddActionInit() and then some AddAction*() methods to add your items to ActionItems property.
		/// Finally you should return ActionItems.
		/// </summary>
		/// <returns></returns>
		public override sealed DesignerActionItemCollection GetSortedActionItems() {
			ClearActionList();
			AddActionItems();
			return m_ActionList;
		}

		/// <summary>
		/// You should Override this method to specify your smart tag action items. Call AddAction*() methods to define your action items in this method.
		/// </summary>
		public abstract void AddActionItems();
	}

	#endregion
}