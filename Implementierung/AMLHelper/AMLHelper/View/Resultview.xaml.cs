using AMLHelper.Controller;
using AMLHelper.ElementExtraction;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AMLHelper.View
{
    /// <summary>
    /// Interaktionslogik für Resultview.xaml
    /// </summary>
    public partial class Resultview : UserControl
    {
        public TabController controller;
        public CaexTreeView treeView;

        public Resultview()
        {
            InitializeComponent();
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
                    var ListViewItem = contextMenu.PlacementTarget as ListViewItem;
                    if (ListViewItem != null)
                    {
                        controller.CreateNewTab((CAEXElement)ListViewItem.DataContext);
                    }
                }
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
                    var ListViewItem = contextMenu.PlacementTarget as ListViewItem;
                    if (ListViewItem != null)
                    {
                        controller.ChangeCurrentTab((CAEXElement)ListViewItem.DataContext, true);
                    }
                }
            }
        }

        /// <summary>
        /// Methode, die beim Mittelmausklick auf Baumelementen aufgerufen wird.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WheelOnElement(object sender, RoutedEventArgs e)
        {
            MouseButtonEventArgs mouseEvent = e as MouseButtonEventArgs;
            if (mouseEvent != null && mouseEvent.ChangedButton == MouseButton.Middle && mouseEvent.ButtonState == MouseButtonState.Pressed)
            {
                ListViewItem item = (ListViewItem)sender;

                CAEXElement caex = (CAEXElement)item.DataContext;
                controller.CreateNewTab(caex);

                e.Handled = true;
            }

        }

        /// <summary>
        /// Methode, die beim Doppelklick auf Baumelemente aufgerufen wird.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoubleClickOnElement(object sender, MouseButtonEventArgs e)
        {
            ListViewItem item = (ListViewItem)sender;
            CAEXElement caex = (CAEXElement)item.DataContext;

            if (item.IsSelected)
            {
                if (!controller.IsEmpty)
                {
                    controller.ChangeCurrentTab(caex, true);
                }
                else
                {
                    controller.CreateNewTab(caex);
                }

            }

            e.Handled = true;
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
                    var item = contextMenu.PlacementTarget as ListViewItem;
                    if (item != null)
                    {
                        CAEXElement caex = (CAEXElement)item.DataContext;
                        treeView.RemoveElement(caex);
                        treeView.UpdateSearchResult();
                    }
                }
            }
        }
    }
}
