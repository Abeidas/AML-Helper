using System.Windows;

namespace AMLHelper.View
{
    /// <summary>
    /// Interaktionslogik für BusyBox.xaml
    /// </summary>
    public partial class BusyBox : Window
    {
        public BusyBox()
        {
            InitializeComponent();
            Topmost = true;
            Show();
            //System.Windows.Threading.Dispatcher.Run();
        }
    }
}
