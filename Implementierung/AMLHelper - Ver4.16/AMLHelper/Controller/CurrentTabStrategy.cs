using System.Windows.Controls;
using System.Windows.Input;
using AMLHelper.ElementExtraction;

namespace AMLHelper.Controller
{
    public class CurrentTabStrategy
    {
        readonly TabController _tabController;
        public CurrentTabStrategy(TabController tabController)
        {
            _tabController = tabController;
        }

        public void ListViewItem_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var listView = (ListView)sender;
            if (listView.SelectedItem != null)
            {
                var clickedElement = (CAEXElement)listView.SelectedItem;
                _tabController.ChangeCurrentTab(clickedElement); //öffnet das ausgewähle Element in dem aktuellen Tab
            }
            e.Handled = true;
        }

        /// <summary>
        /// Methode, die beim Mittelmausklick auf Listenelementen aufgerufen wird.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ListViewItem_WheelClick(object sender, MouseButtonEventArgs e)
        {
            if (e != null && e.ChangedButton == MouseButton.Middle && e.ButtonState == MouseButtonState.Pressed)
            {
                var listView = (ListView)sender;
                if (listView.SelectedItem != null)
                {
                    var clickedElement = (CAEXElement)listView.SelectedItem;
                    _tabController.CreateNewTab(clickedElement); //öffnet das ausgewähle Element in neuem Tab
                }

                e.Handled = true;
            }

        }
    }
}
