///////////////////////////////////////////////////////////
//  History.cs
//  Implementation of the Interface History
//  Generated by Enterprise Architect
//  Created on:      30-Jan-2016 10:51:20
//  Original author: kelln_000
///////////////////////////////////////////////////////////

using AMLHelper.ElementExtraction;
using System.ComponentModel;

namespace AMLHelper.Model {

	/// <summary>
	/// Diese Schnittstelle ordnet Elemente in einem Verlauf an, �hnlich wie bei einem
	/// (Web-) Browser.
	/// </summary>
	public interface IHistory : INotifyPropertyChanged {

        /// <summary>
        /// Variable, die �ber ein Binding f�r die IsEnabled-Eigenschaft des Backward_Buttons
        /// zust�ndig ist.
        /// </summary>
        bool backwardButton_enable { get; }

        /// <summary>
        /// Variable, die �ber ein Binding f�r die IsEnabled-Eigenschaft des Forward_Buttons
        /// zust�ndig ist.
        /// </summary>
        bool forwardButton_enable { get; }

		/// <summary>
		/// F�gt ein Element zur Historie hinzu und setzt dieses als das aktuell betrachtete
		/// </summary>
		/// <param name="element"></param>
		void AddElementToHistory(CAEXElement element);

		/// <summary>
		/// Gibt das n�chste Element in der Historie zur�ck oder null wenn dieses nicht
		/// exisitiert. Falls es existiert wird der index Zeiger auf dieses bewegt und
        /// es wird als neues derzeitiges Element akzeptiert
		/// </summary>
        CAEXElement GoToNextElement();

        /// <summary>
        /// Gibt das n�chste Element in der Historie zur�ck. null wenn dieses nicht
        /// exisitiert. Ver�ndert den index des aktuell betrachteten Elements nicht
        /// </summary>
        CAEXElement PeekNextElement();

        /// <summary>
        /// Gibt das vorherige Element zur�ck und gibt null zur�ck, falls es dieses nicht gibt.
        /// Falls es existiert wird der index Zeiger auf dieses bewegt und
        /// es wird als neues derzeitiges Element akzeptiert
        /// </summary>
        CAEXElement GoToPreviousElement();

        /// <summary>
        /// Gibt das vorherige Element zur�ck. Gibt null zur�ck, falls es dieses nicht gibt.
        /// Ver�ndert den index des aktuell betrachteten Elements nicht
        /// </summary>
        CAEXElement PeekPreviousElement();
    }//end History

}//end namespace Model