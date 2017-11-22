using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml;
using AMLHelper.Controller;
using AMLHelper.Model;
using CAEX_ClassModel;
using MessageBox = System.Windows.Forms.MessageBox;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace AMLHelper.View
{

    /// <summary>
    /// Interaktionslogik für PluginWindow.xaml
    /// </summary>
    public partial class PluginWindow : Window
    {
        private readonly AMLPlugin _plugin;
        private static PluginWindow _mainWindow;
        
        private FileInstance _currentFile;
        public FileInstance CurrentFile
        {
            get
            {
                return _currentFile;
            }
            set
            {
                _currentFile = value;
            }
        }
        /// <summary>
        /// Erstellt ein neues PluginWindow mit Verweis auf die AMLPlugin Klasse, von der es erstellt wurde.
        /// </summary>
        /// <param name="plugin">AMLPlugin, das dieses PluginWindow erstellt.</param>
        public PluginWindow(AMLPlugin plugin)
        {
            _mainWindow = this;
            InitializeComponent();
            _plugin = plugin;
            Tree.TabController = TabController;

            //Hier werden die EventHandler hinzugefügt:
            MenuPanel.openMenuItem.Click += openMenuItem_Click;
            MenuPanel.saveMenuItem.Click += saveMenuItem_Click;
            MenuPanel.saveAsMenuItem.Click += saveAsMenuItem_Click;
            MenuPanel.closeMenuItem.Click += closeMenuItem_Click;
            MenuPanel.newHierarchyItem.Click += Tree.AddEmptyHierarchy;
            MenuPanel.restoreTab.Click += Tree.TabController.Restore_Tab;
            MenuPanel.aboutMenuItem.Click += aboutMenuItem_Click;
            MenuPanel.firstStepsMenuItem.Click += firstStepsMenuItem_Click;

            MenuPanel.DataContext = TabController;
            Tree.RestoreTab.DataContext = TabController;
        }
        /// <summary>
        /// Gibt die Instanz des PluginWindows zurück. Es kann immer nur ein PluginWindow existieren.
        /// </summary>
        /// <returns>Instanz des PluginWindows</returns>
        public static PluginWindow GetInstance()
        {
            return _mainWindow;
        }
        /// <summary>
        /// Lädt eventuell vorher schon in Verbindung mit diesem Projekt geöffnete Tabs und initialisiert die TreeView
        /// </summary>
        public void Init()
        {
            ResponseTrigger.MarkBusy();
            CurrentFile = FileInstance.GetInstance();
            if (CurrentFile.IsFileSet())
            {
          
                Tree.BuildTree();

                //"Speichern", "Speichern als", "Neue Instanzhierarchie anlegen" und Kontextmenü freigeben.
                MenuPanel.saveMenuItem.IsEnabled = true;
                MenuPanel.saveAsMenuItem.IsEnabled = true;
                MenuPanel.newHierarchyItem.IsEnabled = true;
                Tree.EnableContextMenu();

            }
            ResponseTrigger.JobFinished();

        }
        /// <summary>
        /// Speichert das derzeit geöffnete AMLDocument am CurrentFile.AMLFilePath
        /// </summary>
        /// <seealso cref="CurrentFile"/>
        public void Save()
        {
            ResponseTrigger.MarkBusy();
            _currentFile.Document.SaveToFile(CurrentFile.AmlFilePath, true);
            FileInstance.NumberOfChangesMade = 0; //Änderungen auf 0 setzen
            ResponseTrigger.JobFinished();
        }

        /// <summary>
        /// Methode für Aktionen, die vor dem Schließen des Plugins ausgeführt werden müssen.
        /// Es werden die geöffneten Tabs gespeichert.
        /// </summary>
        public void close_Plugin()
        {
            var fi = FileInstance.GetInstance();
            // speichere Tabs
            if (fi.AmlFilePath != null)
            {
                var handler = new ConfigurationHandler(TabController);
                handler.SaveConfiguration();
            }
            FileInstance.Reset();
            InstanceIEPanel.GlobalInternalLinksActive = true; //Internal Links resetten
            _mainWindow = null;
        }


        /// <summary>
        /// EventHandler für das ÖffnenMenüItem
        /// Zeigt einen "Datei-Öffnen"-Dialog und lädt die ausgewählte .aml Datei.
        /// </summary>
        /// <param name="sender">Auslöser des Events</param>
        /// <param name="e">Argumente zum Event</param>
        private void openMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var fi = FileInstance.GetInstance();

             if (fi.IsFileSet() && FileInstance.NumberOfChangesMade > 0) {
                    var dialog = new SaveDialog();
                    dialog.ShowDialog();
                    var ch = dialog._choice;

                    if (ch == SaveDialog.Choice.Cancel) {
                        return;
                    }
                 if (ch == SaveDialog.Choice.Save) {
                     Save();
                 }
             }

            var openFileDialog = new OpenFileDialog
            {
                Filter = "AutomationML Dateien (*.aml)|*.aml|Alle Dateien (*.*)|*.*"
            };
            //Filter
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (fi.IsFileSet() && openFileDialog.FileName.Equals(fi.AmlFilePath))
                {
                    MessageBox.Show("Diese Datei ist bereits geöffnet.");
                    return;
                }

                ResponseTrigger.MarkBusy();

                try
                {
                    var tempDoc = CAEXDocument.LoadFromFile(openFileDialog.FileName);
                }
                catch (XmlException)
                {
                    ResponseTrigger.JobFinished();
                    System.Windows.MessageBox.Show("Fehler beim Laden der Datei.\nIst die Datei eine gültige AML-Datei?", "Fehler beim Öffnen", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    return;
                }
                
                // speichere Tabs
                if (fi.AmlFilePath != null)
                {
                    var handler = new ConfigurationHandler(TabController);
                    handler.SaveConfiguration();
                }
                fi.AmlFilePath = openFileDialog.FileName;
                CurrentFile = fi; //CurrentFile setzen, falls diese nicht schon vorher gesetzt wurde.
                CurrentFile.ReloadCaexDocument(); //neues CAEXDoc laden
                _plugin.AMLFilePath = openFileDialog.FileName;
                TabController.CloseAllTabs();
                TabController.ResetHistory();
                Init();
                ResponseTrigger.JobFinished();
            }

        }

        /// <summary>
        /// EventHandler für das SpeichernMenüItem. Ruft die save() Methode zum Speichern des aktuellen AML Documents auf.
        /// </summary>
        /// <param name="sender">Auslöser des Events</param>
        /// <param name="e">Argumente zum Event</param>
        private void saveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }



        /// <summary>
        /// EventHandler für das SpeichernAlsMenüItem
        /// Öffnet einen "Speichern Unter"-Dialog. Wird ein Dateipfad ausgewählt so wird die derzeit geöffnete AML Datei dort gespeichert
        /// und der Pfad in CurrentFile geändert.
        /// </summary>
        /// <param name="sender">Auslöser des Events</param>
        /// <param name="e">Argumente zum Event</param>
        private void saveAsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "AutomationML Dateien (*.aml)|*.aml|Alle Dateien(*.*) | *.* "
            };
            //Filter für .aml Dateien anlegen
            if (saveFileDialog.ShowDialog() == true)
            {
                //_plugin.AMLFilePath = saveFileDialog.FileName;
                CurrentFile.AmlFilePath = saveFileDialog.FileName;
                Save();
            }
        }

        /// <summary>
        /// "Über das Plugin"-Fenster öffnen.
        /// </summary>
        /// <param name="sender">Auslöser des Events</param>
        /// <param name="e">Argumente zum Event</param>
        private void aboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new About();
            aboutWindow.Show();
        }

        /// <summary>
        /// "Erste Schritte"-Fenster öffnen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void firstStepsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var firstSteps = new FirstSteps();
            firstSteps.Show();
        }

        /// <summary>
        /// EventHandler für das closeMenüItem. Schließt das Fenster.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            close_Plugin();
        }

        /// <summary>
        /// Diese MEthode wird beim Schließen des Fensters aufgerufen. Der Benutzer wird durch einen Dialog gefragt, ob der das Programm wirklich schließen will
        /// und ob seine Änderungen gespeichert werden sollen oder nicht.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {  

            //2 Unterschiedliche DIalogtypen sind möglich, je nachdem ob es Änderungen gibt, oder nicht.
            if (FileInstance.NumberOfChangesMade > 0 && FileInstance.GetInstance().IsFileSet()) {
                var dialog = new SaveDialog();
                dialog.ShowDialog();
                var ch = dialog._choice;

                switch (ch)
                {
                    case SaveDialog.Choice.Cancel:
                        e.Cancel = true; 
                        break;

                    case SaveDialog.Choice.Save:
                        Save();
                        goto case SaveDialog.Choice.DontSave; //Da es keinen Case-Fallthrough in C# gibt.

                    case SaveDialog.Choice.DontSave:
                        close_Plugin();
                        break;
                }
            } else
            {
                //Tritt ein wenn es keine Änderungen gibt.
                if (System.Windows.MessageBox.Show("Soll das Plugin wirklich geschlossen werden?", "Wirklich schließen?", MessageBoxButton.YesNo, 
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    close_Plugin();
                    e.Cancel = false;
                } else
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Lässt prüfen, ob das CAEX-Dokument valide ist und zeigt, sofern es nicht der Fall ist, eine Meldung.
        /// </summary>
        private void CheckIfValidAndShow()
        {
            if (!FileInstance.GetInstance().IsCaexValid())
            {
                if (System.Windows.MessageBox.Show("Die Datei hat Fehler. Fortfahren?", "Fehlerhafte Datei", MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.No)
                {
                }
            }
        }

        /// die nachfolgenden Methoden sind EventHandler für die vorhandenen Tastaturkürzel
        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Tree.AddEmptyHierarchy(sender, e);
        }

        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            openMenuItem_Click(null, null);
        }

        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            saveMenuItem_Click(null, null);
        }

        private void SaveAsCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            saveAsMenuItem_Click(null, null);
        }

        private void CloseCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Window_Closing(null, new CancelEventArgs());
        }

    }
}
