using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AMLPlugin.ElementExtraction;
using CAEX_ClassModel;

using AMLPluginHelper.View;
namespace AMLPlugin.View
{
    /// <summary>
    /// Interaction logic for CAEXTreeView.xaml
    /// </summary>
    public partial class CAEXTreeView : UserControl
    {
        public TabController tabController;
        public CAEXTreeView()
        {
            InitializeComponent();
        }

        public void buildTree(CAEXElement caex)
        {
            
        }

        public void BuildTree(InstanceHierarchyType root)
        {
            //TODO: Add Hierarchy first
            CAEXTreeViewItem rootItem = new CAEXTreeViewItem
            {
                Header = root.Name.Value,
                CObject = root
            };
            tree.Items.Add(rootItem);
            
            foreach (InternalElementType ie in root.InternalElement)
            {
                AddInternalElement(rootItem, ie);
            }
            
            tree.UpdateLayout();
        }

        private void AddInternalElement(CAEXTreeViewItem parent, InternalElementType ie)
        {
            //TODO: TreeViewItem erstellen
            CAEXTreeViewItem childItem = new CAEXTreeViewItem
            {
                Header = ie.Name.Value,
                CObject = ie,
                DataContext = ie
            };
            parent.Items.Add(childItem);
            foreach (InternalElementType innerNode in ie.InternalElement)
            {
                AddInternalElement(childItem, innerNode);
            }

            //treeviewitem interfaces = new treeviewitem
            //{
            //    header = "interfaces"
            //};

            //parent.items.add(interfaces);

            //foreach (interfaceclasstype innernode in ie.externalinterface)
            //{
            //    addinterface(interfaces, innernode);
            //}
            //foreach (supportedroleclasstype innernode in ie.supportedroleclass)
            //{
            //    addsupportedroleclass(childitem, innernode);
            //}
        }

        private void AddInterface(TreeViewItem parent, InterfaceClassType ei)
        {

            CAEXTreeViewItem childItem = new CAEXTreeViewItem
            {
                Header = ei.Name.Value,
                CObject = ei
            };
            parent.Items.Add(childItem);
        }

        private void AddSupportedRoleClass(TreeViewItem parent, RoleClassType rc)
        {
            CAEXTreeViewItem childItem = new CAEXTreeViewItem
            {
                Header = rc.Name.Value,
                CObject = rc
            };
            parent.Items.Add(childItem);
        }

        private void textBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (textBox.Text == "Suche...")
            {
                textBox.Text = "";
            }
        }
        private void DoubleClickOnElement(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            Example example = (Example) item.DataContext;
            if (item.IsSelected)
            {
                tabController.CreateNewTab(example);
            }
        }

        private void WheelOnElement(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            Example example = (Example)item.DataContext;
            if (item.IsSelected)
            {
                tabController.ChangeCurrentTab(example);
            }
        }
    }
}
