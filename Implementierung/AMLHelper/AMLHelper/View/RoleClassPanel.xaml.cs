using AMLHelper.ElementExtraction;
using System.Windows;
using System.Windows.Controls;
using AMLEngineExtensions;
using CAEX_ClassModel;
using AMLHelper.Model;

namespace AMLHelper.View
{
    /// <summary>
    /// Interaction logic for RoleClassPanel.xaml
    /// </summary>
    public partial class RoleClassPanel : UserControl
    {
        private InternalElementElement _parent;

        public InternalElementElement Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public RoleClassPanel()
        {
            InitializeComponent();
        }

        private void ShowPath_Checked(object sender, RoutedEventArgs e)
        {
            var changesBackup = FileInstance.NumberOfChangesMade;
            var checkBox = (CheckBox)sender;
            var internalElement = (InternalElementElement)checkBox.DataContext;
            foreach (SupportedRoleElement roleElement in internalElement.RoleClasses)
                roleElement.Name = roleElement.CompletePath;
            FileInstance.NumberOfChangesMade = changesBackup;
        }

        private void ShowPath_Unchecked(object sender, RoutedEventArgs e)
        {
            var changesBackup = FileInstance.NumberOfChangesMade;
            CheckBox checkBox = (CheckBox)sender;
            InternalElementElement internalElement = (InternalElementElement)checkBox.DataContext;
            foreach (SupportedRoleElement roleElement in internalElement.RoleClasses)
                roleElement.Name = roleElement.RoleName;
            FileInstance.NumberOfChangesMade = changesBackup;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            SupportedRoleElement roleElement = (SupportedRoleElement)checkBox.DataContext;
            roleElement.IsSelected = (bool) checkBox.IsChecked;
            SupportedRoleClassType type = roleElement.type;

            if (!roleElement.IsSelected)
            {
                type.Remove();
            }
            else
            {
                var caex = (InternalElementType) Parent.Caex;
                caex.Insert_SupportedRoleClass(type);
            }

            AMLHelper.Model.FileInstance.NumberOfChangesMade++;
        }
    }
}
