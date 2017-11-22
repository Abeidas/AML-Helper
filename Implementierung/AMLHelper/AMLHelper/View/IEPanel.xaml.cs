using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using AMLHelper.ElementExtraction;
using AMLHelper.Controller;

namespace AMLHelper.View
{
    /// <summary>
    /// Interaction logic for IEPanel.xaml
    /// </summary>
    /// Bind suggestions to the toolbar
    public partial class IEPanel : UserControl
    {
        private TabController _tabController;
        public IEPanel()
        {
            InitializeComponent();
        }

        public void SetTabHolder(TabController tabController)
        {
            _tabController = tabController;
        }

        /// <summary>
        /// Methode, die aufgerufen wird, wenn im Kontextmenü der Liste die Option "In neuem Tab öffnen" ausgewählt wurde.
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
                    if (ExistingsInternalElements.SelectedItem != null)
                    {
                        var clickedElement = (CAEXElement)ExistingsInternalElements.SelectedItem;
                        _tabController.CreateNewTab(clickedElement); //öffnet das ausgewähle Element in neuem Tab
                    }
                }
            }
        }

        /// <summary>
        /// Methode, die aufgerufen wird, wenn im Kontextmenü der Liste die Option "Im aktuellen Tab öffnen" ausgewählt wurde.
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
                    if (ExistingsInternalElements.SelectedItem != null)
                    {
                        var clickedElement = (CAEXElement)ExistingsInternalElements.SelectedItem;
                        _tabController.ChangeCurrentTab(clickedElement); //öffnet das ausgewähle Element im aktuellen Tab
                    }
                }
            }
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            var parent = (InternalElementElement)DataContext;
            var children = parent.InternalElements;
            var index = ExistingsInternalElements.SelectedIndex;
            var newIndex = (index + 1)%children.Count; //Overflow verhindern, vom Anfang der Liste beginnen. 
            if (index == -1 || newIndex == -1) return;
            children.Move(index, newIndex);
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            var parent = (InternalElementElement)DataContext;
            var children = parent.InternalElements;
            var index = ExistingsInternalElements.SelectedIndex;
            var newIndex = index-1 < 0 ? children.Count-1 : index-1; //Underflow verhindern, vom Ende der Liste beginnen
            if (index == -1 || newIndex == -1) return;
            children.Move(index, newIndex);
        }

        private void useInternalLinks_Checked(object sender, RoutedEventArgs e)
        {
            upButton.IsEnabled = true;
            downButton.IsEnabled = true;
            var parent = (InternalElementElement) DataContext;
            var test = parent.InternalElements;
        }

        private void useInternalLinks_Unchecked(object sender, RoutedEventArgs e)
        {
            upButton.IsEnabled = false;
            downButton.IsEnabled = false;
        }
    }
}
