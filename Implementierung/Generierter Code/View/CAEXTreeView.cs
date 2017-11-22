///////////////////////////////////////////////////////////
//  CAEXTreeView.cs
//  Implementation of the Class CAEXTreeView
//  Generated by Enterprise Architect
//  Created on:      30-Jan-2016 10:51:20
//  Original author: Dennis
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using AMLHelperPlugin.Controller;
namespace AMLHelperPlugin.View {
	/// <summary>
	/// Repr�sentiert die Baumstruktur der CAEXElemente.
	/// </summary>
	public class CAEXTreeView : TreeView {

		private static CAEXTreeView EINZELST�CK;
		public AMLHelperPlugin.Controller.CAEXTreeView m_CAEXTreeView;

		public CAEXTreeView(){

		}

		/// <summary>
		/// Privater Konstruktor um Instanziierung zu verhindern.
		/// </summary>
		/// <param name="caex"></param>
		private CAEXTreeView(CAEXTab caex){

		}

		~CAEXTreeView(){

		}

		/// <summary>
		/// Gibt das TreePanel zur�ck sofern es existiert. Andernfalls wird eine neue
		/// Instanz angelegt und zur�ckgegeben.
		/// </summary>
		public static CAEXTreeView GetTreePanel(){

			return null;
		}

		/// <summary>
		/// Wird aufgerufen wenn eine Suche ausgef�hrt wird. Filtert die Baumstruktur nach
		/// dem eingegebenen Suchbegriff.
		/// </summary>
		/// <param name="search"></param>
		public void OnSearch(String search){

		}

	}//end CAEXTreeView

}//end namespace View