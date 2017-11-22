///////////////////////////////////////////////////////////
//  ConfigurationManager.cs
//  Implementation of the Class ConfigurationManager
//  Generated by Enterprise Architect
//  Created on:      30-Jan-2016 10:51:20
//  Original author: Max
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using AMLHelperPlugin.Model;
using AMLHelperPlugin.Controller;
namespace AMLHelperPlugin.Controller {
	/// <summary>
	/// Diese Klasse stellt Methoden zum Laden und Speichern der Projektdatei zur
	/// Verf�gung. In der Projektdatei werden die zuletzt ge�ffneten Tabs, sowie
	/// weitere Einstellungsm�glichkeiten gespeichert.
	/// </summary>
	public class ConfigurationManager {

		public AMLHelperPlugin.Model.AbstractTabPersistence m_AbstractTabPersistence;
		public AMLHelperPlugin.Controller.AMLHelper m_AMLHelper;

		public ConfigurationManager(){

		}

		~ConfigurationManager(){

		}

		/// <summary>
		/// L�dt eine Konfigurationsdatei vom spezifizierten Pfad.
		/// </summary>
		/// <param name="path"></param>
		public bool LoadConfguration(String path){

			return false;
		}

		/// <summary>
		/// Speichert eine Konfigurationsdatei von dem angegebenen Pfad.
		/// </summary>
		/// <param name="path"></param>
		public bool SaveConfiguration(String path){

			return false;
		}

	}//end ConfigurationManager

}//end namespace Controller