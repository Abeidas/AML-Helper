using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AMLEngineExtensions;
using AMLHelper.Controller;
using AMLHelper.ElementExtraction;
using AMLHelper.Model;
using CAEX_ClassModel;

namespace AMLHelper.View
{
    /// <summary>
    ///     Interaction logic for InstanceIEPanel.xaml
    /// </summary>
    public partial class InstanceIEPanel : UserControl
    {
        private TabController _tabController;
        public InstanceElement Hierarchie { get; set; }
        public static bool GlobalInternalLinksActive = true;

        public InstanceIEPanel()
        {
            InitializeComponent();
            SystemLibBox.ItemsSource = FileInstance.SysLib;
            if (!GlobalInternalLinksActive)
            {
                useInternalLinks.IsEnabled = false;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (SystemLibBox.SelectedItem == null)
            {
                return;
            }

            var sucl = (SystemUnitFamilyType) SystemLibBox.SelectedItem;
            var ie = (InternalElementType) sucl.CreateClassInstance();
            var hierachy = (InstanceHierarchyType) Hierarchie.Caex;
            
            hierachy.Insert_InternalElement(ie);
            var iee = new InternalElementElement(ie, Hierarchie); //neues IEE anlegen für das IE das wir adden wollen
            
            
            Hierarchie.ChildElements.Add(iee);
        }
        
        public void SetTabHolder(TabController tabController)
        {
            _tabController = tabController;
        }

        /// <summary>
        ///     Methode, die aufgerufen wird, wenn im Kontextmenü der Liste die Option "In neuem Tab öffnen" ausgewählt wurde.
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
                    if (ExistingInternalElements.SelectedItem != null)
                    {
                        var clickedElement = (CAEXElement) ExistingInternalElements.SelectedItem;
                        _tabController.CreateNewTab(clickedElement); //öffnet das ausgewähle Element in neuem Tab
                    }
                }
            }
        }

        /// <summary>
        ///     Methode, die aufgerufen wird, wenn im Kontextmenü der Liste die Option "Im aktuellen Tab öffnen" ausgewählt wurde.
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
                    if (ExistingInternalElements.SelectedItem != null)
                    {
                        var clickedElement = (CAEXElement) ExistingInternalElements.SelectedItem;
                        _tabController.ChangeCurrentTab(clickedElement);
                            //öffnet das ausgewähle Element im aktuellen Tab
                    }
                }
            }
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            var parent = (InstanceElement)DataContext;
            var children = parent.ChildElements;
            var index = ExistingInternalElements.SelectedIndex;
            var newIndex = (index + 1) % children.Count; //Overflow verhindern, vom Anfang der Liste beginnen. 
            if (index == -1 || newIndex == -1) return;
            children.Move(index, newIndex);
            try
            {

                SaveOrder();
                FileInstance.NumberOfChangesMade++;
            }
            catch (Exception)
            {
                children.Move(newIndex, index);
                MessageBox.Show("Die Datei ist fehlerhaft, weshalb mit der geöffneten AML-Datei die Verwendung von Internal Links nicht möglich ist.", "Keine Internal Links möglich", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                DisableInternalLinks();
            }
            
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
                var parent = (InstanceElement)DataContext;
                var children = parent.ChildElements;
                var index = ExistingInternalElements.SelectedIndex;
                var newIndex = index - 1 < 0 ? children.Count - 1 : index - 1; //Underflow verhindern, vom Ende der Liste beginnen
                if (index == -1 || newIndex == -1) return;
                children.Move(index, newIndex);
            try
            {
                SaveOrder();
                FileInstance.NumberOfChangesMade++;
            }
            catch (Exception)
            {
                children.Move(newIndex, index);
                MessageBox.Show("Die Datei ist fehlerhaft, weshalb mit der geöffneten AML-Datei die Verwendung von Internal Links nicht möglich ist.", "Keine Internal Links möglich", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                DisableInternalLinks();
            }
            
        }

        private void DisableInternalLinks()
        {
            upButton.IsEnabled = false;
            downButton.IsEnabled = false;
            useInternalLinks.IsEnabled = false;
            GlobalInternalLinksActive = false;
            useInternalLinks.IsChecked = false;
        }

        private void SaveOrder()
        {
            var parent = (InstanceElement)DataContext; //Instanz
            var children = parent.ChildElements; //Liste, in der die IE-Kindelemente stehen
            var linksToRemove = GetAllInternalLinks();
            var linksToAdd = new Dictionary<InternalElementType, InternalLinkType>();
            for (int i = 0; i<children.Count-1; i++) 
            {
                var curElement = (InternalElementElement) children.ElementAt(i);
                var nextElement = (InternalElementElement) children.ElementAt(i + 1);

                var caex = (InternalElementType) curElement.Caex;
                var nextCaex = (InternalElementType) nextElement.Caex;

//                var link = caex.New_InternalLink(caex.Name.Value + ":" + nextCaex.Name.Value);
                
                var caexInterface = GetOrderInterface("Out", caex);
                var nextInterface = GetOrderInterface("In", caex);
                int time = DateTime.Now.Millisecond; //Für eindeutige Namen der Links...
                var link = InternalLinkType.New_InternalLink(caex, caexInterface, nextCaex, nextInterface, caex.Name.Value + ":" + nextCaex.Name.Value + time);
                linksToAdd.Add(caex, link);
            }
            //Erst die Links verändern wenn alle Links erzeigt wurden.
            foreach (InternalLinkType link in linksToRemove)
            {
                link.Remove(); //Alte Links entfernen
            }
            foreach (KeyValuePair<InternalElementType, InternalLinkType> pair in linksToAdd)
            {
                pair.Key.Insert_InternalLink(pair.Value); //Alle neuen Links hinzufügen
            }
        }

        private ExternalInterfaceType GetOrderInterface(string direction, InternalElementType parent)
        {
            foreach (InterfaceClassType extInt in parent.ExternalInterfaces())
            {
                if (extInt.Attribute.GetAttribute("Direction").Value == direction)
                {
                    return parent.findExternalInterface(extInt.Name.Value);
                }
            }
            return null;
        }

        private List<InternalLinkType> GetAllInternalLinks()
        {
            var parent = (InstanceElement)DataContext; //Instanz
            var children = parent.ChildElements; //Liste, in der die IE-Kindelemente stehen

            var list = new List<InternalLinkType>();

            foreach (var caexElement in children)
            {
                var internalElement = (InternalElementElement)caexElement;
                var caex = (InternalElementType)internalElement.Caex;
                foreach (InternalLinkType il in caex.InternalLink)
                {
                    list.Add(il);
                }
            }

            return list;
        }

        private void useInternalLinks_Checked(object sender, RoutedEventArgs e)
        {
            var backupChanges = FileInstance.NumberOfChangesMade;
            try
            {
                upButton.IsEnabled = true;
                downButton.IsEnabled = true;

                var parent = (InstanceElement)DataContext; //Instanz
                var children = parent.ChildElements; //Liste, in der die IE-Kindelemente stehen

                var list = new List<InternalLinkType>();
                var sortedList = new List<InternalElementType>();

                foreach (var caexElement in children)
                {
                    var internalElement = (InternalElementElement)caexElement;
                    var caex = (InternalElementType)internalElement.Caex;
                    foreach (InternalLinkType il in caex.InternalLink)
                    {
                        list.Add(il);
                    }
                    
                    foreach (InternalLinkType link in list)
                    {
                        var sideA = link.LinkedObjects.RefPartnerSideAElement;
                        var sideB = link.LinkedObjects.RefPartnerSideBElement;
                        if (sortedList.Contains(sideB) && !sortedList.Contains(sideA))
                        {
                            var index = sortedList.IndexOf(sideB);
                            sortedList.Insert(index, sideA);
                        }
                        else if (sortedList.Contains(sideA) && !sortedList.Contains(sideB))
                        {
                            var index = sortedList.IndexOf(sideA);
                            sortedList.Insert(index + 1, sideB);
                        }
                        else if (!sortedList.Contains(sideA) && !sortedList.Contains(sideB))
                        {
                            sortedList.Add(sideA);
                            sortedList.Add(sideB);
                        }
                    }

                }
                int realIndex = 0;
                foreach (InternalElementType ieType in sortedList)
                {
                    var index = MyIndexOf(children, ieType);
                    if (index == -1) return;
                    children.Move(index, realIndex++);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Die Datei ist fehlerhaft, weshalb mit der geöffneten AML-Datei die Verwendung von Internal Links nicht möglich ist.", "Keine Internal Links möglich", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                DisableInternalLinks();
            }
            FileInstance.NumberOfChangesMade = backupChanges;
        }

        private int MyIndexOf(ObservableCollection<CAEXElement> children, InternalElementType ieType)
        {
            if (children == null || ieType == null) return -1;
            int index = -1;
            foreach (var caexElement in children)
            {
                if (caexElement == null || caexElement.Caex == null)
                    return -1;
                var iee = (InternalElementElement) caexElement;
                index++;
                var caex = (InternalElementType) iee.Caex;
                if (!caex.RefBaseSystemUnitPath.Exists() || !ieType.RefBaseSystemUnitPath.Exists() || !caex.ID.Exists() || !ieType.ID.Exists())
                    return -1;
                if (caex.RefBaseSystemUnitPath.Value == ieType.RefBaseSystemUnitPath.Value &&
                    caex.ID.Value == ieType.ID.Value)
                {
                    return index;
                }
            }
            return -1;
        }

        private void useInternalLinks_Unchecked(object sender, RoutedEventArgs e)
        {
            upButton.IsEnabled = false;
            downButton.IsEnabled = false;
        }
    }
}
