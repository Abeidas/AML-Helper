///////////////////////////////////////////////////////////
//  HistoryTab.cs
//  Implementation of the Class HistoryTab
//  Generated by Enterprise Architect
//  Created on:      29-Jan-2016 11:58:55
//  Original author: kelln_000
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace AMLHelperPlugin.View {
	/// <summary>
	/// Ein Tab, der sich merkt, welches Element vorher darin ge�ffnet war.
	/// </summary>
	public abstract class HistoryTab {

		public HistoryTab(){

		}

		~HistoryTab(){

		}

		/// <summary>
		/// Gibt das aktuelle Objekt in der Historie zur�ck.
		/// </summary>
		public abstract CAEXObject GetCurrentObject();

		/// <summary>
		/// Gibt das n�chste Element der Historie zur�ck. Sollte dieses nicht existieren
		/// wird null zur�ckgegeben.
		/// </summary>
		public abstract CAEXObject GetNextInHistory();

		/// <summary>
		/// Gitb das vorherige Element in der Historie zur�ck, Null falls dieses nicht
		/// existiert.
		/// </summary>
		public abstract CAEXObject GetPreviousInHistory();

		/// <summary>
		/// L�dt den Inhalt des Historie Tabs erneut.
		/// </summary>
		public void Reload(){

		}

	}//end HistoryTab

}//end namespace View