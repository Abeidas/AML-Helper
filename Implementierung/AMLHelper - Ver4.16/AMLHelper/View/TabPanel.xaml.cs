using AMLHelper.Controller;
using AMLHelper.ElementExtraction;
using AMLHelper.Model;
using System.Windows;
using System.Windows.Controls;

namespace AMLHelper.View
{
    /// <summary>
    /// Interaction logic for TabPanel.xaml
    /// </summary>
    public partial class TabPanel : UserControl
    {
        public TabPanel()
        {
            InitializeComponent();
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = (TabItem)TabController.instance.TabView.SelectedItem;
            Tab tab = ((CAEXElement)tabItem.DataContext).Tab;
            if (tab == null)
            {
                //sollte eigentlich nicht passieren, trotzdem error handling?
                return;
            }
            CAEXElement caex = tab.History.PeekNextElement();
            if (caex != null)
            {
                //es gibt Element die danach offen waren, also darauf ändern
                TabController.instance.ChangeCurrentTab(caex, false);
                //TODO Überprüfen ob nur auf anderen Tab geswitcht wurde und Element aus history entfernen falls ja
                tab.History.GoToNextElement();
            }
            else
            {
                //keine Elemente waren danach offen, error message? Einfach ignorieren?
                return;
            }
        }

        private void BackwardButton_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = (TabItem) TabController.instance.TabView.SelectedItem;
            Tab tab = ((CAEXElement)tabItem.DataContext).Tab;
            if (tab == null)
            {
                //sollte eigentlich nicht passieren, trotzdem error handling?
                return;
            }
            CAEXElement caex = tab.History.PeekPreviousElement();
            if (caex != null)
            {
                //es gibt Element die vorher offen waren, also darauf ändern
                TabController.instance.ChangeCurrentTab(caex, false);
                //TODO Überprüfen ob nur auf anderen Tab geswitcht wurde und Element aus history entfernen falls ja
                tab.History.GoToPreviousElement();
            }
            else
            {
                //keine Elemente waren vorher offen, error message? Einfach ignorieren?
                return;
            }
        }
    }
}
