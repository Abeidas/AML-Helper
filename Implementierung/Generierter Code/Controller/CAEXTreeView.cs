///////////////////////////////////////////////////////////
//  CAEXTreeView.cs
//  Implementation of the Class CAEXTreeView
//  Generated by Enterprise Architect
//  Created on:      30-Jan-2016 10:51:20
//  Original author: beidas
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using AMLHelperPlugin.View;
using AMLHelperPlugin.ElementExtraction;
using AMLHelperPlugin.Model;
using AMLHelperPlugin.Controller;
namespace AMLHelperPlugin.Controller {
	/// <summary>
	/// Bietet Methoden zur Verwaltung des CAEXTreeView - Panels.
	/// </summary>
	public class CAEXTreeView {

		private TreeView tree;
		public AMLHelperPlugin.View.PluginWindow m_PluginWindow;
		/// <summary>
		/// 1
		/// </summary>
		public AMLHelperPlugin.ElementExtraction.CAEXTab m_CAEXTab;
		public AMLHelperPlugin.Model.ConcreteHistory m_ConcreteHistory;
		public AMLHelperPlugin.Controller.TreeEventHandler m_TreeEventHandler;

		public CAEXTreeView(){

		}

		~CAEXTreeView(){

		}

		/// <summary>
		/// Baut den Tree aus den CAEXObject Knoten auf.
		/// </summary>
		/// <param name="amlFilePath"></param>
		public void BuildTree(string amlFilePath){

		}

		/// 
		/// <param name="path"></param>
		public bool SaveTree(string path){

			return false;
		}

	}//end CAEXTreeView

}//end namespace Controller