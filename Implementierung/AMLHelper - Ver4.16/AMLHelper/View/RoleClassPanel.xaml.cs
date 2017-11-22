using AMLHelper.ElementExtraction;
using System.Windows;
using System.Windows.Controls;
using AMLEngineExtensions;
using CAEX_ClassModel;

namespace AMLHelper.View
{
    /// <summary>
    /// Interaction logic for RoleClassPanel.xaml
    /// </summary>
    public partial class RoleClassPanel : UserControl
    {
        public RoleClassPanel()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            InternalElementElement internalElement = (InternalElementElement)checkBox.DataContext;
            foreach (SupportedRoleElement roleElement in internalElement.RoleClasses)
                roleElement.Name = roleElement.CompletePath;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            InternalElementElement internalElement = (InternalElementElement)checkBox.DataContext;
            foreach (SupportedRoleElement roleElement in internalElement.RoleClasses)
                roleElement.Name = roleElement.RoleName;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            SupportedRoleElement roleElement = (SupportedRoleElement)checkBox.DataContext;
            roleElement.IsSelected = (bool) checkBox.IsChecked;
            if (!roleElement.IsSelected)
            {
                SupportedRoleClassType type = roleElement.type;
                type.Remove();
            }
            else
            {

            }

            AMLHelper.Model.FileInstance.NumberOfChangesMade++;
        }
    }
}
