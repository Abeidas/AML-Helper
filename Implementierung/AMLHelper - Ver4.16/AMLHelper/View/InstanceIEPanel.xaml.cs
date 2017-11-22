using System.Windows;
using System.Windows.Controls;
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

        public InstanceIEPanel()
        {
            InitializeComponent();
            SystemLibBox.ItemsSource = FileInstance.SysLib;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (SystemLibBox.SelectedItem == null)
            {
                return;
            }

            var sucl = (SystemUnitFamilyType) SystemLibBox.SelectedItem;
            var ie = (InternalElementType) sucl.CreateClassInstance();
            var ih = (InstanceHierarchyType) Hierarchie.Caex;
            

            foreach (InternalElementType internalElement in sucl.InternalElement)
            {
                foreach (SupportedRoleClassType srcType in internalElement.SupportedRoleClass)
                {
                    var test = ie.SupportedRoleClass.Append();
                    test.Insert_Element(srcType);
                    test.RoleReference = srcType.RoleReference;
                }
            }
            ih.Insert_InternalElement(ie);
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
            children.Move(index, newIndex);
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            var parent = (InstanceElement)DataContext;
            var children = parent.ChildElements;
            var index = ExistingInternalElements.SelectedIndex;
            var newIndex = index - 1 < 0 ? children.Count - 1 : index - 1; //Underflow verhindern, vom Ende der Liste beginnen
            children.Move(index, newIndex);
        }

        private void useInternalLinks_Checked(object sender, RoutedEventArgs e)
        {
            upButton.IsEnabled = true;
            downButton.IsEnabled = true;
        }

        private void useInternalLinks_Unchecked(object sender, RoutedEventArgs e)
        {
            upButton.IsEnabled = false;
            downButton.IsEnabled = false;
        }
    }
}
