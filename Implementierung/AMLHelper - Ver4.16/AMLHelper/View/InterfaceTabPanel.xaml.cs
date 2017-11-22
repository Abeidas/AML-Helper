using System.Windows;
using System.Windows.Controls;

namespace AMLHelper.View
{
    /// <summary>
    /// Interaction logic for InterfaceTabPanel.xaml
    /// </summary>
    public partial class InterfaceTabPanel : UserControl
    {
        public InterfaceTabPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Methode, die die Scrollbar automatisch auf die richtige Größe einstellt,
        /// um mit dynamischen Größen arbeiten zu können.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void border_transferHeight(object sender, RoutedEventArgs e)
        {
            attributeLabel.MaxHeight = border.ActualHeight;
        }
    }
}
