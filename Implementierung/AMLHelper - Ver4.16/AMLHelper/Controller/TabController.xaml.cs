using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AMLHelper.ElementExtraction;
using AMLHelper.Model;
using AMLHelper.View;
using CAEX_ClassModel;
using System;

namespace AMLHelper.Controller
{
    /// <summary>
    /// Interaction logic for TabHolder.xaml
    /// </summary>
    public partial class TabController : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Die zuletzt geschlossenen Tabs und die Stelle im TabView, an der sie geschlossen wurden
        /// </summary>
        public List <Tuple <Tab, int>> lastClosed;

        /// <summary>
        /// Maximale Anzahl von Tabs, die wiederhergestellt werden kann
        /// </summary>
        public const int MAXIMUM_TABS_RESTORABLE = 10;

        /// <summary>
        /// Einzelstück?
        /// </summary>
        public static TabController instance;

        /// <summary>
        /// Die Fabrik zum Erstellen der Tabs
        /// </summary>
        AbstractTabPanelFactory panelFactory;


        /// <summary>
        /// Die Strategie, wie auf Eingaben auf der Elementliste reagiert wird
        /// </summary>
        CurrentTabStrategy tabStrategy;

        /// <summary>
        /// ?
        /// </summary>
        public bool OnDemandLoading = true;

        /// <summary>
        /// Gibt an, ob derzeit Tabs vorhanden sind
        /// </summary>
        public bool IsEmpty
        {
            get { return !TabView.HasItems; }
        }

        /// <summary>
        /// Gibt an, ob bereits ein Tab gelöscht wurde
        /// </summary>
        public bool hasDeletedTabs { get; set; }

        public TabController()
        {
            InitializeComponent();
            lastClosed = new List<Tuple<Tab, int>>();
            instance = this;
            tabStrategy = new CurrentTabStrategy(this);
            panelFactory = new ConcreteTabPanelFactory(this, tabStrategy);
            //this.TabView.SelectionChanged += TabView_SelectionChanged;
            
        }

        ~TabController()
        {

        }

        /// <summary>
        /// Öffnet das CAEXElement eines Baumelements in einem neuen Tab.
        /// </summary>
        /// <param name="item">Das Baumelement des zu öffnenden Elements</param>
        public void CreateNewTab(CAEXElement caexElement)
        {
            if (caexElement.Tab == null)
            {
                Tab tab = new Tab(panelFactory, caexElement);
                TabView.Items.Add(tab.TabItem);
                TabView.SelectedItem = tab.TabItem;
            }
            else
            {
                //Tab existiert schon, es wird daher zu diesem gewechselt
                TabItem newSelectedItem = caexElement.Tab.TabItem;
                TabView.SelectedItem = newSelectedItem;
            }
        }

        /// <summary>
        /// Ändert den aktuellen Tab.
        /// </summary>
        /// <param name="caexElement">Element, welches im aktuellen Tab angezeigt werden soll</param>
        public void ChangeCurrentTab(CAEXElement caexElement, bool logToHistory = true)
        {
            if (IsEmpty)
            {
                // es existiert noch gar kein TabItem, daher wird ein neuer Tab angelegt.
                CreateNewTab(caexElement);
                return;
            }

            TabItem selectedTab = (TabItem)TabView.SelectedItem;

            if (caexElement.Tab != null) //Es gibt schon einen Tab, in dem das caexElement geöffnet ist.
            {
                if (caexElement.Tab.TabItem != selectedTab) //Der Tab, in dem das caexElement geöffnet ist, ist nicht der ausgewählte Tab
                {
                    //Tab zu dem Tab wechseln, in dem das caexElement geöffnet ist
                    TabItem newSelectedItem = caexElement.Tab.TabItem;
                    TabView.SelectedItem = newSelectedItem;
                }
                //andernfalls ist das Element bereits im aktuellen Tab geöffnet, d.h. es ist nichts zu tun

            }
            else //caexElement ist noch in keinem Tab geöffnet
            {
                Tab tab = ((CAEXElement)selectedTab.DataContext).Tab;
                tab.Display(caexElement, logToHistory);
            }
        }


        public void loadAttributesLazily(object sender, RoutedEventArgs e)
        {
            var expander = (Expander)sender;
            var IETabPanel = (InternalElementTabPanel)expander.DataContext;
            var iee = (InternalElementElement)IETabPanel.DataContext;
            var ie = (InternalElementType)iee.Caex;
            if (!IETabPanel.AttributeStack.IsEnabled)
            {
                IETabPanel.AttributeStack.IsEnabled = true;

                foreach (AttributeType attr in ie.Attribute)
                {
                    var attrPanel = new AttributePanel();
                    var attrElement = new AttributeElement(attr);
                    attrPanel.DataContext = attrElement;
                    IETabPanel.AttributeStack.Children.Add(attrPanel);
                    LoadAttributesRecursively(attrPanel, attr);
                }
            }
        }

        private void LoadAttributesRecursively(AttributePanel attrPanel, AttributeType parent)
        {
            if (parent.Attribute == null || parent.Attribute.Count == 0)
                return;

            foreach (AttributeType child in parent.Attribute)
            {
                AttributeElement _attributeElement = new AttributeElement(child);
                AttributePanel _attributePanel = new AttributePanel();
                _attributePanel.DataContext = _attributeElement;
                _attributePanel.Margin = new Thickness(20, 5, 0, 0);
                attrPanel.AttributeChildContainer.Children.Add(_attributePanel);
                LoadAttributesRecursively(_attributePanel, child);
            }
        }

        public void CloseTabFor(CAEXElement element, bool save)
        {
            OnPropertyChanged("hasDeletedTabs", true);
            if (save)
            {
                int indexInTablist = TabView.Items.IndexOf(element.Tab.TabItem);
                var pair = Tuple.Create(element.Tab, indexInTablist);
                lastClosed.Add(pair);
                if (lastClosed.Count > MAXIMUM_TABS_RESTORABLE)
                {
                    lastClosed.RemoveAt(0);
                }
            }

            TabView.Items.Remove(element.Tab.TabItem);
            element.Tab.OnClosed();
        }

        #region TabRemovalRegion
        /// <summary>
        /// Schließt den Tab des übergebenen Elements.
        /// </summary>
        /// <param name="element">Element wessen Tab geschlossen werden soll</param>
        private void Remove_Tab(object sender, RoutedEventArgs e)
        {
            CAEXElement element = getBoundCAEX(sender);
            CloseTabFor(element, true);
            e.Handled = true;
        }

        /// <summary>
        /// Stellt letzten Tab wieder her.
        /// </summary>
        /// TODO: Element wurde gelöscht
        /// oder Datei neu geladen / andere geöffnet (also nicht mehr existent)
        /// -> mache Menüeintrag nicht anklickbar?
        /// Menüeintrag im Hauptmenu->Bearbeiten?
        public void Restore_Tab(object sender, RoutedEventArgs e)
        {
            if (lastClosed.Count == 0)
            {
                return;
            }
            var pair = lastClosed.Last();
            Tab toReopen = pair.Item1;

            if (toReopen == null || toReopen.CurrentlyDisplayedCaexElement.Tab != null)
            {
                return;
            }

            lastClosed.Remove(pair);

            TabView.Items.Insert(pair.Item2, toReopen.TabItem);
            TabView.SelectedItem = toReopen.TabItem;
            toReopen.OnRestore();
            toReopen = null;
            pair = null;
            if (e != null && e is RoutedEventArgs)
            {
                e.Handled = true;
            }
            
        }

        /// <summary>
        /// Schließt alle Tabs.
        /// </summary>
        private void Close_All_Tabs(object sender, RoutedEventArgs e)
        {
            CloseAllTabs();
            e.Handled = true;
        }

        /// <summary>
        /// Schließt alle Tabs.
        /// </summary>
        public void CloseAllTabs()
        {
            ResponseTrigger.MarkBusy();
            for (int i = TabView.Items.Count - 1; i >= 0; i--)
            {
                TabItem tabItem = (TabItem)TabView.Items.GetItemAt(i);
                CAEXElement element = (CAEXElement)tabItem.DataContext;
                CloseTabFor(element, i < MAXIMUM_TABS_RESTORABLE); //nur die letzten MAXIMUM_TABS_RESTORABLE Tabs müssen gespeichert werden
            }
            ResponseTrigger.JobFinished();
        }

        /// <summary>
        /// Schließt alle Tabs außer den des übergebenen Elements.
        /// </summary>
        /// <param name="notToBeClosedElement">Element, wessen Tab nicht geschlossen werden soll</param>
        private void Close_All_Tabs_Except(object sender, RoutedEventArgs e)
        {
            ResponseTrigger.MarkBusy();
            CAEXElement notToBeClosedElement = getBoundCAEX(sender);
            if (notToBeClosedElement != null)
            {
                for (int i = TabView.Items.Count - 1; i >= 0; i--)
                {
                    if (!notToBeClosedElement.Tab.TabItem.Equals(TabView.Items.GetItemAt(i)))
                    {
                        TabItem tabItem = (TabItem)TabView.Items.GetItemAt(i);
                        CAEXElement element = (CAEXElement)tabItem.DataContext;
                        CloseTabFor(element, i <= MAXIMUM_TABS_RESTORABLE); //s.o. - "+1", da ein Tab nicht geschlossen wird
                    }
                }
            }
            e.Handled = true;
            ResponseTrigger.JobFinished();
        }
        #endregion

        #region TabRearrangmentRegion
        private void TabItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed)
            {
                CAEXElement element = getBoundCAEX(sender);
                TabItem tabItem = element.Tab.TabItem;
                Cursor = Cursors.Hand;
                if (tabItem == null)
                {
                    return;
                }
                DragDrop.DoDragDrop(tabItem, tabItem, DragDropEffects.Move);
            }
        }

        private void TabItem_DragOver(object sender, DragEventArgs e)
        {
            CAEXElement element = getBoundCAEX(sender);
            TabItem targetTabItem = element.Tab.TabItem;
            TabItem movedTabItem = (TabItem)e.Data.GetData(typeof(TabItem));
            int sourceIndex = TabView.Items.IndexOf(movedTabItem);
            int targetIndex = TabView.Items.IndexOf(targetTabItem);

            TabView.Items.Remove(movedTabItem);
            TabView.Items.Insert(targetIndex, movedTabItem);

            TabView.Items.Remove(targetTabItem);
            TabView.Items.Insert(sourceIndex, targetTabItem);

            TabView.SelectedIndex = targetIndex;
            Cursor = Cursors.Hand;
        }
        #endregion

        public CAEXElement getBoundCAEX(object controlObject)
        {
            if (controlObject == null || !(controlObject is FrameworkElement))
                return null;

            FrameworkElement temp = (FrameworkElement)controlObject;
            return (CAEXElement)temp.DataContext;
        }

        public void ResetHistory()
        {
            lastClosed.Clear();
        }

        /// <summary>
        /// Methode, die beim laden des MenuItems "Geschlossenen Tab wiederherstellen" prüft,
        /// ob dieses angezeigt werden darf oder nicht. NOTIZ: Binding hat nicht funktioniert.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restoreTab_Loaded(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            item.IsEnabled = hasDeletedTabs;
        }

        #region INotifyPropertyChanged Member

        /// <summary>
        /// Tritt ein, wenn sich ein Eigenschaftswert ändert.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName, bool hasDeleted)
        {
            hasDeletedTabs = hasDeleted;
            
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion INotifyPropertyChanged Member
    }
}
///Yet to do