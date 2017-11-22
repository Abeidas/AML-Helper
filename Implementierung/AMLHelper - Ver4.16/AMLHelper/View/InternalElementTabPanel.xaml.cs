using AMLHelper.Controller;
using System.Windows;
using System.Windows.Controls;

namespace AMLHelper.View
{
    /// <summary>
    /// Interaction logic for InternalElementTabPanel.xaml
    /// </summary>
    public partial class InternalElementTabPanel : UserControl
    {
        public InternalElementTabPanel(TabController tabController)
        {
            InitializeComponent();
            this.InterfacePanel.setTabHolder(tabController);
            this.IEPanel.SetTabHolder(tabController);
        }

        /// <summary>
        /// Methode, die die Scrollbar automatisch auf die richtige Größe einstellt,
        /// um mit dynamischen Größen arbeiten zu können.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outerBorder_transferHeight(object sender, RoutedEventArgs e)
        {
            contentScrollView.MaxHeight = outerBorder.ActualHeight;
        }
    }
}
