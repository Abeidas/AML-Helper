using System;
using System.Collections.Generic;
using AMLHelper.ElementExtraction;
using AMLHelper.View;

namespace AMLHelper.Controller
{
    public abstract class AbstractTabPanelFactory
    {
        /// <summary>
        /// Erstellt das neue TabPanel, je nach Art des Elements.
        /// </summary>
        /// <param name="caexElement">Element, welches im Tab angezeigt werden soll</param>
        public TabPanel CreateTabPanel(CAEXElement caexElement)
        {
            TabPanel tabPanel = new TabPanel();
            //Danke an Mark H. (http://stackoverflow.com/a/4478535) für eine elegante Lösung.
            var @switch = new Dictionary<Type, Action> {
                { typeof(InstanceElement), () => tabPanel = CreateInstanceTabPanel((InstanceElement)caexElement) },
                { typeof(InternalElementElement), () => tabPanel = CreateInternalElementTabPanel((InternalElementElement)caexElement) },
                { typeof(InterfaceElement), () => tabPanel = CreateInterfaceTabPanel((InterfaceElement)caexElement) }
            };

            if (!@switch.ContainsKey(caexElement.GetType())) return null;

            @switch[caexElement.GetType()]();
            tabPanel.DataContext = caexElement;
            return tabPanel;
        }
        public abstract TabPanel CreateInstanceTabPanel(InstanceElement caexElement);

        public abstract TabPanel CreateInternalElementTabPanel(InternalElementElement caexElement);

        public abstract TabPanel CreateInterfaceTabPanel(InterfaceElement caexElement);
    }
}
