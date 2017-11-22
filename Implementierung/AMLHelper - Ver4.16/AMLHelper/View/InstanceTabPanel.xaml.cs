using System.Windows.Controls;
using AMLHelper.ElementExtraction;
using AMLHelper.Controller;

namespace AMLHelper.View
{
    /// <summary>
    /// Interaction logic for InstanceTabPanel.xaml
    /// </summary>
    public partial class InstanceTabPanel : UserControl
    {
        public InstanceTabPanel(InstanceElement instance, TabController tabController)
        {
            InitializeComponent();
            IEPanel.Hierarchie = instance;
            DataContext = instance;
            //IEPanel.AddButton.DataContext = instance;
            this.IEPanel.SetTabHolder(tabController);
        }
    }
}
