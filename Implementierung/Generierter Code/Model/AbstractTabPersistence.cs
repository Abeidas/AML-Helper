///////////////////////////////////////////////////////////
//  AbstractTabPersistence.cs
//  Implementation of the Class AbstractTabPersistence
//  Generated by Enterprise Architect
//  Created on:      30-Jan-2016 10:51:19
//  Original author: Max
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using AMLHelperPlugin.Controller;
namespace AMLHelperPlugin.Model {
	/// <summary>
	/// Erm�glicht es ge�ffnete Tabs zu speichern und wieder zu laden.
	/// </summary>
	public abstract class AbstractTabPersistence {

		public AMLHelperPlugin.Controller.TabController m_TabController;

		public AbstractTabPersistence(){

		}

		~AbstractTabPersistence(){

		}

		/// <summary>
		/// L�dt eine Liste von Tabs.
		/// </summary>
		/// <param name="filePath"></param>
		public List <Tab> LoadOldTabs(String filePath){

			return null;
		}

		/// <summary>
		/// Speichert alle derzeit ge�ffneten Tabs in einem String.
		/// </summary>
		/// <param name="filePath"></param>
		public bool SaveCurrentTabs(String filePath){

			return false;
		}

	}//end AbstractTabPersistence

}//end namespace Model