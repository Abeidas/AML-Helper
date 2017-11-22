///////////////////////////////////////////////////////////
//  CAEXObjectCollapsiblePanel.cs
//  Implementation of the Class CAEXObjectCollapsiblePanel
//  Generated by Enterprise Architect
//  Created on:      29-Jan-2016 11:58:54
//  Original author: kelln_000
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using AMLHelperPlugin.View;
namespace AMLHelperPlugin.View {
	/// <summary>
	/// Ein Panel, dass sich auf ein CAEXObject bezieht und dieses je nach konkretem
	/// Typ unterschiedlich darstellt.
	/// </summary>
	public abstract class CAEXObjectCollapsiblePanel : CollapsiblePanel {

		/// <summary>
		/// EventHandler f�r alle OnClick Ereignisse der Tabs.
		/// </summary>
		protected EventHandler EventHandler;

		public CAEXObjectCollapsiblePanel(){

		}

		~CAEXObjectCollapsiblePanel(){

		}

		/// 
		/// <param name="element"></param>
		public CAEXObjectCollapsiblePanel(CAEXElement element){

		}

	}//end CAEXObjectCollapsiblePanel

}//end namespace View