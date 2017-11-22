using AMLHelper.Controller;
using AMLHelper.ElementExtraction;
using System.Windows;
using System.Windows.Controls;

namespace AMLHelper.View
{
    /// <summary>
    /// Interaction logic for InterfacePanel.xaml
    /// </summary>
    public partial class InterfacePanel : UserControl
    {
        private TabController tabController;

        public InterfacePanel()
        { 
            InitializeComponent();
        }

        public void setTabHolder(TabController tabController)
        {
            this.tabController = tabController;
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
                    if (this.ExistingInterfaces.SelectedItem != null)
                    {
                        CAEXElement clickedElement = (CAEXElement)this.ExistingInterfaces.SelectedItem;
                        tabController.CreateNewTab(clickedElement); //öffnet das ausgewähle Element in neuem Tab
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
                    if (this.ExistingInterfaces.SelectedItem != null)
                    {
                        CAEXElement clickedElement = (CAEXElement)this.ExistingInterfaces.SelectedItem;
                        tabController.ChangeCurrentTab(clickedElement, true); //öffnet das ausgewähle Element im aktuellen Tab
                    }
                }
            }
        }
    }
}
