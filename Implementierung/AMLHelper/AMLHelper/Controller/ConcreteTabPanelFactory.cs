using System.Collections.Specialized;
using System.Windows;
using AMLHelper.ElementExtraction;
using AMLHelper.View;
using CAEX_ClassModel;
using System.Windows.Controls;
using System.Windows.Media;
using System;
using System.Drawing;

namespace AMLHelper.Controller
{
    public class ConcreteTabPanelFactory : AbstractTabPanelFactory
    {
        private const int MaxTabPanelsCached = 32;

        private readonly TabController _tabController;

        private readonly CurrentTabStrategy _tabStrategy;

        /// <summary>
        /// Essentiell ein LRU-Cache, um die Wartezeiten bei Vor- und Zurückklicks zu verkürzen
        /// </summary>
        private readonly OrderedDictionary _cache;

        public ConcreteTabPanelFactory(TabController tabController, CurrentTabStrategy tabStrategy)
        {
            _tabController = tabController;
            _tabStrategy = tabStrategy;
            _cache = new OrderedDictionary(MaxTabPanelsCached);
        }

        public new TabPanel CreateTabPanel(CAEXElement caexElement)
        {
            var cached = (TabPanel)_cache[caexElement];
            if (cached != null)
            {
                //gecachetes Panel an den "neuesten" Index verschieben
                _cache.Remove(caexElement);
                _cache.Add(caexElement, cached);
            }
            else
            {
                //neues Panel erstellen und in Cache einfügen
                ResponseTrigger.MarkBusy();
                cached = base.CreateTabPanel(caexElement);
                _cache.Add(caexElement, cached);
                if (_cache.Count > MaxTabPanelsCached) //aufpassen, dass Cache nicht zu groß wird
                {
                    //am längsten nicht angefordertes Element aus dem Cache löschen
                    _cache.RemoveAt(0);
                }
                ResponseTrigger.JobFinished();
            }
            return cached;
        }

        public override TabPanel CreateInstanceTabPanel(InstanceElement instanceElement)
        {
            var tabPanel = new TabPanel();
            var instanceTabPanel = new InstanceTabPanel(instanceElement, _tabController);
            tabPanel.frameForPanel.Content = instanceTabPanel;
            //Listener und ItemsSource festlegen
            instanceTabPanel.IEPanel.ExistingInternalElements.ItemsSource = instanceElement.ChildElements;            
            instanceTabPanel.IEPanel.ExistingInternalElements.PreviewMouseDoubleClick += _tabStrategy.ListViewItem_DoubleClick;
            instanceTabPanel.IEPanel.ExistingInternalElements.MouseDown += _tabStrategy.ListViewItem_WheelClick;
            return tabPanel;
        }

        public override TabPanel CreateInterfaceTabPanel(InterfaceElement interfaceElement)
        {
            var tabPanel = new TabPanel();

            AddPath(tabPanel, interfaceElement);

            var interfaceClass = (InterfaceClassType)interfaceElement.Caex;
            var interfaceTabPanel = new InterfaceTabPanel();
            ResponseTrigger.MarkBusy();
            foreach (AttributeType attribute in interfaceClass.Attribute)
            {
                var attributeElement = new AttributeElement(attribute);
                var attributePanel = new AttributePanel {DataContext = attributeElement};

                interfaceTabPanel.attributeStack.Children.Add(attributePanel);
                LoadAttributesRecursively(attributePanel, attribute);
            }
            ResponseTrigger.JobFinished();
            tabPanel.frameForPanel.Content = interfaceTabPanel;
            return tabPanel;
        }

        public override TabPanel CreateInternalElementTabPanel(InternalElementElement internalElement)
        {
            var tabPanel = new TabPanel();

            AddPath(tabPanel, internalElement);

            var internalElementTabPanel = new InternalElementTabPanel(_tabController);
            internalElementTabPanel.IEPanel.ExistingsInternalElements.ItemsSource = internalElement.InternalElements;
            internalElementTabPanel.InterfacePanel.ExistingInterfaces.ItemsSource = internalElement.Interfaces;
            internalElementTabPanel.RoleClassPanel.ExistingSupportedRoleClasses.ItemsSource = internalElement.RoleClasses;
            internalElementTabPanel.RoleClassPanel.Parent = internalElement;
            tabPanel.frameForPanel.Content = internalElementTabPanel;
            internalElementTabPanel.IEPanel.ExistingsInternalElements.PreviewMouseDoubleClick += _tabStrategy.ListViewItem_DoubleClick;
            internalElementTabPanel.InterfacePanel.ExistingInterfaces.PreviewMouseDoubleClick += _tabStrategy.ListViewItem_DoubleClick;

            internalElementTabPanel.IEPanel.ExistingsInternalElements.MouseDown += _tabStrategy.ListViewItem_WheelClick;
            internalElementTabPanel.InterfacePanel.ExistingInterfaces.MouseDown += _tabStrategy.ListViewItem_WheelClick;

            var ie = (InternalElementType)internalElement.Caex;

            ResponseTrigger.MarkBusy();

            if (_tabController.OnDemandLoading)
            {
                #region OnDemandLoading
                internalElementTabPanel.DataContext = internalElement;
                internalElementTabPanel.AttributeStack.IsEnabled = false;
                internalElementTabPanel.expander3.IsExpanded = false;
                internalElementTabPanel.expander3.DataContext = internalElementTabPanel;
                internalElementTabPanel.expander3.Expanded += _tabController.loadAttributesLazily; //Eventhandler für on demand loading von Attributen hinzufügen
                #endregion OnDemandLoading
            }
            else
            {
                foreach (AttributeType attr in ie.Attribute)
                {
                    var attrPanel = new AttributePanel();
                    var attrElement = new AttributeElement(attr);
                    attrPanel.DataContext = attrElement;
                    internalElementTabPanel.AttributeStack.Children.Add(attrPanel);
                    LoadAttributesRecursively(attrPanel, attr);
                }
            }
            ResponseTrigger.JobFinished();
            return tabPanel;
        }

        private void AddPath(TabPanel tabPanel, CAEXElement internalElement)
        {
            var path = new Label {Content = "Pfad:"};
            tabPanel.PathContainer.Children.Add(path);

            if (internalElement.ParentElements.Count > 5)
            {
                var dotdotdot = new Label {Content = "..."};
                var seperator = new Label {Content = ">"};
                tabPanel.PathContainer.Children.Add(dotdotdot);
                tabPanel.PathContainer.Children.Add(seperator);
            }

            int count = internalElement.ParentElements.Count;
            int begin = (count > 5) ? count - 5 : 0;
            int labelCount = 0; 
            
            for (var i = begin; i < count && (labelCount < 5); i++)
            {
                var parent = internalElement.ParentElements[i];
                var label = new Label
                {
                    DataContext = parent,
                    Foreground = new SolidColorBrush(Colors.Blue)
                };
                label.MouseEnter += Label_OnMouseEnter;
                label.MouseLeave += Label_OnMouseLeave;
                label.MouseLeftButtonDown += Label_OnMouseClick;

                var cm = new ContextMenu();
                var openInNew = new MenuItem {Header = "In neuem Tab öffnen"};
                //  openInNew.Icon = new Bitmap(Properties.Resources.Open_In_New_Tab);
                openInNew.Click += OpenInNew_OnMouseClick;
                var openInCurrent = new MenuItem {Header = "Im aktuellen Tab öffnen"};
                //    openInCurrent.Icon = Properties.Resources.Open_In_Current_Tab; 
                openInCurrent.Click += OpenInCurrent_OnMouseClick;
                cm.Items.Add(openInNew);
                cm.Items.Add(openInCurrent);
                label.ContextMenu = cm;

                if (parent.Caex.Name.Exists())
                {
                    if (labelCount == 0)
                        label.Content = parent.Caex.Name.Value;
                    else
                    {
                        var seperator = new Label {Content = ">"};
                        tabPanel.PathContainer.Children.Add(seperator);
                        label.Content = parent.Caex.Name.Value;
                    }
                }
                else
                {
                    if (labelCount == 0)
                        label.Content = "unbenanntes Element";
                    else
                    {
                        var seperator = new Label {Content = ">"};
                        tabPanel.PathContainer.Children.Add(seperator);
                        label.Content = "unbenanntes Element";
                    }
                }

                label.ToolTip = "Klicken Sie auf \"" + label.Content + "\" um es in diesem Tab zu öffnen.";
                tabPanel.PathContainer.Children.Add(label);
                labelCount++;
            }
            tabPanel.PathBorder.ToolTip = "Klicken Sie auf einen Namen, um das entsprechende Elternelement zu öffnen.";
            tabPanel.PathBorder.Visibility = Visibility.Visible;
        }

        private void OpenInNew_OnMouseClick(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            var toOpen = (CAEXElement)item.DataContext;
            _tabController.CreateNewTab(toOpen);
        }

        private void OpenInCurrent_OnMouseClick(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            if (item != null)
            {
                var toOpen = (CAEXElement)item.DataContext;
                _tabController.ChangeCurrentTab(toOpen, true);
            }
        }

        private void Label_OnMouseEnter(object sender, EventArgs e)
        {
            var label = sender as Label;
            label.FontWeight = FontWeights.Bold;
        }

        private void Label_OnMouseLeave(object sender, EventArgs e)
        {
            var label = sender as Label;
            label.FontWeight = FontWeights.Normal;
        }

        private void Label_OnMouseClick(object sender, EventArgs e)
        {
            var item = sender as Label;
            if (item != null)
            {
                var toOpen = (CAEXElement)item.DataContext;
                _tabController.ChangeCurrentTab(toOpen, true);
            }
        }

        private void LoadAttributesRecursively(AttributePanel attrPanel, AttributeType parent)
        {
            if (parent.Attribute == null || parent.Attribute.Count == 0)
                return;

            foreach (AttributeType child in parent.Attribute)
            {
                var _attributeElement = new AttributeElement(child);
                var _attributePanel = new AttributePanel();
                _attributePanel.DataContext = _attributeElement;
                _attributePanel.Margin = new Thickness(20, 5, 0, 0);
                attrPanel.AttributeChildContainer.Children.Add(_attributePanel);
                LoadAttributesRecursively(_attributePanel, child);
            }
        }
    }
}
