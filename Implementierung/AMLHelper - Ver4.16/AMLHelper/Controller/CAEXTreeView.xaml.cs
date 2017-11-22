using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AMLEngineExtensions;
using AMLHelper.ElementExtraction;
using AMLHelper.Model;

namespace AMLHelper.Controller
{
    /// <summary>
    /// Interaktionslogik für CAEXTreeView.xaml
    /// Bietet Methoden an, um mit dem TreeView zu interagieren.
    /// </summary>
    public partial class CaexTreeView : UserControl
    {
        public TabController TabController;
        private List<CAEXElement> _itemsToOpen;
        private ConfigurationHandler _handler;
        private List<string> _names;
        private int _numberOfHierarchy; // fortlaufende Nummer der leeren Hierarchien
        private readonly TreeViewModel _model;

        /// <summary>
        /// Variable, die angibt, ob man sich im Suchvorgang befindet
        /// </summary>
        private bool isInSearchMode;


        /// <summary>
        /// Erstellt eine leere Baumansicht
        /// </summary>
        public CaexTreeView()
        {
            InitializeComponent();
            _model = (TreeViewModel)DataContext;
        }

        /// <summary>
        /// Baut den Baum auf.
        /// </summary>
        public void BuildTree()
        {
            //Diese Variablen werden für das Wiederherstellen der Tabs benötigt.
            _handler = new ConfigurationHandler(TabController);
            _itemsToOpen = new List<CAEXElement>();
            _names = _handler.LoadConfiguration();


            _model.DeleteAllNodes();     //Da der Baum eventuell vorher Elemente beeinhaltete

            var file = FileInstance.GetInstance().Data;
            foreach (var ih in file.InstanceHierarchies())
            {
                var root = new InstanceElement(ih); //Jedes InstanceElement baut selbst seinen Baum auf.          
                _model.TreeList.Add(root);
            }


            ResetSearch();
            

            //Zum Wiederherstellen der Tabs
            TraverseTree(node => {
                CheckIfToLoadAndAdd(node);
                return true;
            });

            

            foreach (var caex in _itemsToOpen)
            {
                TabController.CreateNewTab(caex);
            }
            FileInstance.NumberOfChangesMade = 0;
        }

        // prüft, ob das Objekt in der letzten Sitzung geöffnet war
        private void CheckIfToLoadAndAdd(CAEXElement item)
        {
            var obj = item.Caex;
            if (_names != null && _names.Contains(_handler.GetIdentifier(obj)))
            {
                _itemsToOpen.Add(item); // ItemsToOpen merkt sich alle Items, die aus der gespeicherten Konfiguration zu öffnen sind.
            }
        }

        /// <summary>
        /// Methode, die aufgerufen wird, wenn im Kontextmenü des Baumes die Option "In neuem Tab öffnen" ausgewählt wurde.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenInNewTabClick(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                var contextMenu = menuItem.Parent as ContextMenu;
                if (contextMenu != null)
                {
                    var item = contextMenu.PlacementTarget as TreeViewItem;
                    if (item != null)
                    {
                        var caex = (CAEXElement)item.DataContext;
                        TabController.CreateNewTab(caex);
                    }
                }
            }
        }
        /// <summary>
        /// Methode, die aufgerufen wird, wenn im Kontextmenü des Baumes die Option "Element entfernen" ausgewählt wurde.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveElementClick(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                var contextMenu = menuItem.Parent as ContextMenu;
                if (contextMenu != null)
                {
                    var item = contextMenu.PlacementTarget as TreeViewItem;
                    if (item != null)
                    {                   
                        RemoveElement((CAEXElement)item.DataContext);
                    }
                }
            }
        }

        public void RemoveElement(CAEXElement element)
        {
            RecursivelyCloseTabsOnDelete(element);
            var caex = element.Caex;
            caex.Remove(); //Und schließlich aus dem CAEXDocument
            _model.RemoveItemFromTree(element); //Das Element aus der Anzeige im TreeView entfernen
            FileInstance.NumberOfChangesMade++;
        }

        /// <summary>
        /// Methode, die aufgerufen wird, wenn im Kontextmenü des Baumes die Option "Alle Elemente löschen" ausgewählt wurde.
        /// </summary>
        /// <param name="caex"></param>
        private void RecursivelyCloseTabsOnDelete(CAEXElement caex)
        {
            if (caex.Tab != null)
            {
                //falls momentan geöffnet
                TabController.CloseTabFor(caex, false);
            }

            if (caex.ChildElements == null) return;
            foreach (var subCaex in caex.ChildElements.ToArray())
            {
                //falls Subelemente momentan geöffnet sind
                RecursivelyCloseTabsOnDelete(subCaex);
            }
        }

        private void RemoveAllElementsClick(object sender, RoutedEventArgs e)
        {
            if (!FileInstance.GetInstance().IsFileSet())
            {
                return;
            }

            if (MessageBox.Show("Möchten Sie wirklich alle Elemente löschen? Dies kann nicht rückgängig gemacht werden", "Alle löschen?", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (CAEXElement caex in Tree.Items)
                {
                    caex.Caex.Remove();
                }
                _model.DeleteAllNodes();
                TabController.CloseAllTabs();
                TabController.lastClosed.Clear();
                FileInstance.NumberOfChangesMade++;
            }
        }

        /// <summary>
        /// Methode, die aufgerufen wird, wenn im Kontextmenü des Baumes die Option "Im aktuellen Tab öffnen" ausgewählt wurde.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenInCurrentTabClick(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                var contextMenu = menuItem.Parent as ContextMenu;
                if (contextMenu != null)
                {
                    var item = contextMenu.PlacementTarget as TreeViewItem;
                    if (item != null)
                    {
                        var caex = (CAEXElement)item.DataContext;
                        TabController.ChangeCurrentTab(caex);
                    }
                }
            }
        }

        /// <summary>
        /// Methode, die beim Doppelklick auf Baumelemente aufgerufen wird.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoubleClickOnElement(object sender, MouseButtonEventArgs e)
        {
            var item = (TreeViewItem)sender;
            var caex = (CAEXElement)item.DataContext;

            if (item.IsSelected)
            {
                if (!TabController.IsEmpty)
                {
                    TabController.ChangeCurrentTab(caex);
                }
                else
                {
                    TabController.CreateNewTab(caex);
                }

            }

            e.Handled = true;
        }

        /// <summary>
        /// Methode, die beim Mittelmausklick auf Baumelementen aufgerufen wird.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WheelOnElement(object sender, RoutedEventArgs e)
        {
            var mouseEvent = e as MouseButtonEventArgs;
            if (mouseEvent == null || mouseEvent.ChangedButton != MouseButton.Middle ||
                mouseEvent.ButtonState != MouseButtonState.Pressed) return;

            var item = (TreeViewItem)sender;

            var caex = (CAEXElement)item.DataContext;

            TabController.CreateNewTab(caex);
            e.Handled = true;
        }

        /// <summary>
        /// Führt eine Suche aus.
        /// </summary>
        private ObservableCollection<CAEXElement> DoSearch(string searchline)
        {
            isInSearchMode = true;
            var results = new ObservableCollection<CAEXElement>();

            if (!string.IsNullOrEmpty(searchline) && Tree != null && Tree.Items != null)
            {
                TraverseTree(element => {
                    if (element != null && element.Caex.Name.Exists() && element.Caex.Name.Value.ToLower().Contains(searchline.ToLower()))
                    {
                        results.Add(element);
                    }
                    
                    return true;
                });

            }

            return results;
        }

        /// <summary>
        /// Wandert den gesamten Baum durch (mit iterativer Tiefensuche), und führt auf jedem Knoten (d.h. jedem CAEXElement) die Operation aus
        /// </summary>
        /// <param name="operation">Eine Operation, die auf jedem CAEXElement ausgeführt werden soll, und zurückgibt, ob der Baum weiter durchlaufen werden soll</param>
        private void TraverseTree(Func<CAEXElement, bool> operation)
        {
            if (Tree == null || Tree.Items == null || operation == null)
            {
                return;
            }

            var stack = new Stack<CAEXElement>();

            foreach (CAEXElement item in Tree.Items)
            {
                stack.Push(item);

                while (stack.Count > 0)
                {
                    var element = stack.Pop();

                    if (!operation(element))
                    {
                        //Wanderung abbrechen
                        return;
                    }

                    if (element.ChildElements != null)
                    {
                        foreach (var child in element.ChildElements)
                        {
                            stack.Push(child);
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Zeige Suchergebnisse
        /// </summary>
        /// <param name="results"></param>
        private void ShowSearchResults(IReadOnlyCollection<CAEXElement> results)
        {
            if (Resultview.controller == null || Resultview.treeView == null)
            {
                Resultview.controller = TabController;
                Resultview.treeView = this;
            }
            Resultview.SearchResultsBinding.ItemsSource = results;
            Resultview.Resultscount.Text = results.Count + " gefunden";
            Tree.Visibility = Visibility.Hidden;
            CleanSearchboxButton.Visibility = Visibility.Visible;
            Resultview.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Methode, die den Resultview updated (z.B. nach dem Löschen eines Elements).
        /// </summary>
        public void UpdateSearchResult()
        {
            isInSearchMode = true;
            ShowSearchResults(DoSearch(TextBox.Text));
        }

        /// <summary>
        /// Suche beginnen, sobald sich der Inhalt der Textbox ändert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;

            if (textbox != null && textbox.IsSelectionActive)
            {
                if (string.IsNullOrEmpty(textbox.Text))
                {
                    Resultview.Visibility = Visibility.Hidden;
                    CleanSearchboxButton.Visibility = Visibility.Hidden;
                    Tree.Visibility = Visibility.Visible;
                    return;
                }
                if (!FileInstance.GetInstance().IsFileSet())
                {
                    Resultview.Resultscount.Text = "Kein Dokument geöffnet.";
                    Tree.Visibility = Visibility.Hidden;
                    CleanSearchboxButton.Visibility = Visibility.Visible;
                    Resultview.Visibility = Visibility.Visible;
                    return;
                }
				else if (_model.TreeList.Count == 0)
                {
                    Resultview.Resultscount.Text = "Modell enthält keine Elemente.";
                    Tree.Visibility = Visibility.Hidden;
                    CleanSearchboxButton.Visibility = Visibility.Visible;
                    Resultview.Visibility = Visibility.Visible;
                    return;
                }
                var searchline = textbox.Text;
                var results = DoSearch(searchline);
                ShowSearchResults(results);
            }

        }

        /// <summary>
        /// Löscht den als Default angezeigten Text, sodass eine Eingabe leichter möglich ist.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TextBox.Text == "Suche...")
            {
                TextBox.Text = "";
            }
        }

        /// <summary>
        /// Setzt den Text der Suche, im Falle einer leeren Eingabe, wieder auf
        /// den Default Text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_LostFocus(object sender, EventArgs e)
        {
            if (TextBox.Text != "") return;

            TextBox.Text = "Suche...";
            Resultview.Visibility = Visibility.Hidden;
            CleanSearchboxButton.Visibility = Visibility.Hidden;
            Tree.Visibility = Visibility.Visible;
            isInSearchMode = false;
        }

        /// <summary>
        /// Stellt zuletzt geschlossenen Tab wieder her.
        /// </summary>
        private void RestoreLastTab(object sender, RoutedEventArgs e)
        {
            TabController.Restore_Tab(sender, e);
        }

        /// <summary>
        /// Erstellt eine neue, leere Instanzhierarchie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddEmptyHierarchy(object sender, RoutedEventArgs e)
        {
            if (!FileInstance.GetInstance().IsFileSet())
            {
                return;
            }
            var hierarchy = FileInstance.GetInstance().Document.CAEXFile.New_InstanceHierarchy("InstanceHierarchy" + _numberOfHierarchy++);
            var instance = new InstanceElement(hierarchy);
            _model.TreeList.Add(instance);
            FileInstance.NumberOfChangesMade++;
            if (isInSearchMode)
            {
                UpdateSearchResult();
            }
        }

        /// <summary>
        /// Eventhandler für Löschbutton der Suchleiste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CleanSearchTextBox(object sender, MouseButtonEventArgs e)
        {
            if (TextBox.IsFocused)
                TextBox.Text = "";
            else
                TextBox.Text = "Suche...";

            Resultview.Visibility = Visibility.Hidden;
            CleanSearchboxButton.Visibility = Visibility.Hidden;
            Tree.Visibility = Visibility.Visible;
            isInSearchMode = false;
        }

        /// <summary>
        /// Menüeinträge (neue IH, Tab wiederherstellen, alle Tabs löschen) aktivieren.
        /// </summary>
        public void EnableContextMenu()
        {
            NewInstanceHierachy.IsEnabled = true;
            //this.restoreTab.IsEnabled = true;
            DeleteAllTabs.IsEnabled = true;
        }

        /// <summary>
        /// Setzt die Suche zurück, einschließlich Textbox und Suchergebnisse.
        /// </summary>
        private void ResetSearch()
        {
            Resultview.Visibility = Visibility.Hidden;
            CleanSearchboxButton.Visibility = Visibility.Hidden;
            Tree.Visibility = Visibility.Visible;
            TextBox.IsEnabled = false;
            TextBox.IsEnabled = true; // let it loose its focus <-> but does not work 
            TextBox.Text = "Suche...";
            if (Resultview.SearchResultsBinding != null && Resultview.SearchResultsBinding.ItemsSource != null)
            {
                ((ObservableCollection<CAEXElement>)Resultview.SearchResultsBinding.ItemsSource).Clear();
            }
            isInSearchMode = false;
        }
    }
}
