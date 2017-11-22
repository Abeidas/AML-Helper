using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using CAEX_ClassModel;
using CAEX_ClassModel.Validation;

namespace AMLHelper.Model
{
    /// <summary>
    /// Diese Klasse speichert eine Referenz auf das derzeit geöffnete CAEXDocument und den Dateipfad der AML Datei.
    /// </summary>
    public class FileInstance
    {
        /// <summary>
        /// Instanz, die die derzeit geöffnete Datei repräsentiert
        /// </summary>
        private static FileInstance _currentInstance;

        /// <summary>
        /// Pfad der momentan geöffneten AML Datei
        /// </summary>
        private string _amlFilePath;
        /// <summary>
        /// Anzahl der Änderungen an der geladenen Instanz die seit dem letzten Speichern oder dem Laden, 
        /// falls noch nie gespeichert wurde, gemacht wurden
        /// </summary>
        public static int NumberOfChangesMade;
        public static ObservableCollection<SystemUnitFamilyType> SysLib;
        public CAEXDocument Document { get; private set; }
        public CAEXFileType Data { get { return Document.CAEXFile; }}
        public string AmlFilePath {
            get { return _amlFilePath; } 
            set {
                if (_amlFilePath == null || !(_amlFilePath.Equals(value))) {
                    _amlFilePath = value;
                    NumberOfChangesMade = 0;
                    // reload?
                    
                }
            }
        }

        /// <summary>
        /// Diese Methode lädt alle Bibliotheken, die sich in der .aml Datei befinden 
        /// und schreibt diese in eine ObservableCollection, die dann von UI Elementen als 
        /// ItemsSource verwendet werden kann.
        /// </summary>
        public void LoadLibraries()
        {
            SysLib = new ObservableCollection<SystemUnitFamilyType>();
            foreach (SystemUnitClassLibType sucl in Data.SystemUnitClassLib)
            {
                foreach (SystemUnitFamilyType suc in sucl.SystemUnitClass)
                {
                    SysLib.Add(suc);
                    LoadLibsRecursively(suc);
                }
            }
        }

        /// <summary>
        /// Subroutine, die genutzt wird um für die AML-Datei benötigte Bibliotheken vollständig rekursiv zu laden
        /// </summary>
        private void LoadLibsRecursively(SystemUnitFamilyType suft)
        {
            foreach (SystemUnitFamilyType childSuc in suft.SystemUnitClass)
            {
                SysLib.Add(childSuc);
                LoadLibsRecursively(childSuc);
            }
        }
        
        /// <summary>
        /// Lädt das CAEXDocument vom Dateipfad. (Private, da Einzelstück)
        /// </summary>
        /// <param name="filepath">Der Pfad zu einer gültigen AML Datei</param>
        /// <exception cref="SchemaConformanceException">Falls die Datei nicht gültig ist.</exception>
        private FileInstance(string filepath) {
            AmlFilePath = filepath;
            Document = CAEXDocument.LoadFromFile(filepath);
        }

        /// <summary>
        /// Übernimmt das CAEXDoc.
        /// </summary>
        /// <param name="newDoc"></param>
        private FileInstance(CAEXDocument newDoc)
        {
            Document = newDoc;
        }

        /// <summary>
        /// Alternativer Konstruktor, der nur eine leere Datei anlegt. (Private, da Einzelstück)
        /// </summary>
        /// <exception cref="SchemaConformanceException">Falls die Datei nicht gültig ist.</exception>
        private FileInstance()
        {

        }

        /// <summary>
        /// Gibt die Instanz von FileInstance zurück und setzt den Pfad.
        /// Dokument wird neu geladen!
        /// Methode zum Erhalt des Einzelstücks.
        /// </summary>
        /// <param name="filepath">Der Pfad zu einer gültigen AML Datei</param>
        /// <exception cref="SchemaConformanceException">Falls die Datei nicht gültig ist.</exception>
        public static FileInstance GetInstanceAndSetPath(string filepath)
        {
            if (_currentInstance == null)
            {
                _currentInstance = new FileInstance(filepath);
                _currentInstance.AmlFilePath = filepath;
                _currentInstance.Document = CAEXDocument.LoadFromFile(filepath);
                NumberOfChangesMade = 0;
                return _currentInstance;
            }
            _currentInstance.AmlFilePath = filepath;
            _currentInstance.Document = CAEXDocument.LoadFromFile(filepath);
            NumberOfChangesMade = 0;
            return _currentInstance;
        }

        /// <summary>
        /// Gibt Instanz.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static FileInstance GetInstanceAndSetDoc(CAEXDocument doc)
        {
            if (_currentInstance == null)
            {
                _currentInstance = new FileInstance(doc);
                NumberOfChangesMade = 0;
                return _currentInstance;
            }
            _currentInstance.Document = doc;
            NumberOfChangesMade = 0;
            return _currentInstance;
        }

        /// <summary>
        /// Gibt die Instanz von FileInstance zurück.
        /// Methode zum Erhalt des Einzelstücks.
        /// </summary>
        public static FileInstance GetInstance()
        {
            if (_currentInstance != null) return _currentInstance;
            _currentInstance = new FileInstance();
            return _currentInstance;
        }

        /// <summary>
        /// Lädt das CAEXDocument erneut vom AMLFilePath
        /// </summary>
        /// <exception cref="SchemaConformanceException">Falls die Datei nicht gültig ist.</exception>
        public bool ReloadCaexDocument() {
            CAEXDocument tempDoc;
            try
            {
                tempDoc = CAEXDocument.LoadFromFile(AmlFilePath);
            }
            catch (XmlException)
            {
                return false;
            }

            Document = tempDoc;
            NumberOfChangesMade = 0;
            LoadLibraries(); //SystemUnitClassLibrary laden, da diese auch vom CAEXDocument abhängt.
            return true;
        }

        /// <summary>
        /// Setzt die FileInstance zurück. Nötig, damit diese, da statisch, beim Schließen des Plugins,
        /// aber nicht Schließen des AML Editors gelöscht wird. 
        /// </summary>
        public static void Reset()
        {
            NumberOfChangesMade = 0;
            SysLib = null;
            _currentInstance = null;
        }

        /// <summary>
        /// Prüft, ob bereits eine AML-Datei (und damit Dokument und Pfad) geladen ist.
        /// </summary>
        /// <returns></returns>
        public bool IsFileSet()
        {
            return (_currentInstance != null && Document != null && _amlFilePath != null);
        }

        /// <summary>
        /// Prüft, ob das CAEX-Dokument valide ist (prüft nicht alle Fehler).
        /// </summary>
        /// <returns></returns>
        public bool IsCaexValid()
        {
            if (!IsFileSet())
            {
                return true;
            }

            var valid = true;
            Document.Tables.UpdateAllTables();
            IEnumerable<ValidationElement> idsNames = Document.ValidateIDsAndNames();
            IEnumerable<ValidationElement> refs = Document.ValidateReferences();

            foreach (var isValidated in idsNames)
            {
                if (!string.IsNullOrEmpty(isValidated.ValidatedAttribute))
                {
                    valid = false;
                }
            }

            foreach (var isValidated in refs)
            {
                if (!string.IsNullOrEmpty(isValidated.ValidatedAttribute))
                {
                    valid = false;
                }
            }

            return valid;

        }

    }//end FileInstance

}//end namespace Model
