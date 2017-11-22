using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMLHelper.ElementExtraction;
using AMLHelper.View;
namespace AMLHelper.Controller
{
    abstract class AbstractTabStrategy
    {
        /// <summary>
        /// Erstellt das neue TabPanel, je nach Art des Elements.
        /// </summary>
        /// <param name="caexElement">Element, welches im Tab angezeigt werden soll</param>
        public TabPanel createTabPanel(CAEXElement caexElement)
        {
            TabPanel _tabPanel = new TabPanel();
            //Danke an Mark H. (http://stackoverflow.com/a/4478535) für eine elegante Lösung.
            var @switch = new Dictionary<Type, Action> {
                { typeof(InstanceElement), () => _tabPanel = CreateInstanceTabPanel((InstanceElement)caexElement) },
                { typeof(InternalElementElement), () => _tabPanel = CreateInternalElementTabPanel((InternalElementElement)caexElement) },
                { typeof(InterfaceElement), () => _tabPanel = CreateInterfaceTabPanel((InterfaceElement)caexElement) },
            };

            if (@switch.ContainsKey(caexElement.GetType()))
            {
                @switch[caexElement.GetType()]();
                _tabPanel.DataContext = caexElement;
                return _tabPanel;
            }
            return null;
        }
        abstract public TabPanel CreateInstanceTabPanel(InstanceElement caexElement);

        abstract public TabPanel CreateInternalElementTabPanel(InternalElementElement caexElement);

        abstract public TabPanel CreateInterfaceTabPanel(InterfaceElement caexElement);
    }
}
