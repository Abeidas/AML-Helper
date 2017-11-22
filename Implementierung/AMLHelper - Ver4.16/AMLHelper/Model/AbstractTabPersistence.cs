///////////////////////////////////////////////////////////
//  AbstractTabPersistence.cs
//  Implementation of the Class AbstractTabPersistence
//  Generated by Enterprise Architect
//  Created on:      30-Jan-2016 10:51:19
//  Original author: Max
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using AMLHelper.Controller;
using CAEX_ClassModel;

namespace AMLHelper.Model {
	/// <summary>
	/// Erm�glicht es ge�ffnete Tabs zu speichern und wieder zu laden.
	/// </summary>
	public abstract class AbstractTabPersistence {

		public TabController MTabController;

	    /// <summary>
        /// L�dt eine Liste von Tabs.
        /// </summary>
        public abstract List<string> LoadOldTabs(string list);

        /// <summary>
        /// Speichert die ge�ffneten Tabs.
        /// </summary>
        /// 
        public abstract bool SaveCurrentTabs(string filePath);

        /// <summary>
        /// Liefert die f�r die Tab-Zuordnung generierte ID.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract string GetIdentifier(CAEXObject obj);

	}//end AbstractTabPersistence

}//end namespace Model