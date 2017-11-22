using System.Windows.Controls;
using AMLHelper.Controller;
using AMLHelper.ElementExtraction;

namespace AMLHelper.Model
{
    /// <summary>
    /// Repräsentiert die logische Einheit eines Tabs im Plugin und verwaltet diese.
    /// </summary>
    public class Tab
    {
        /// <summary>
        /// Das GUI-Tab-Element, das diesen Tab repräsentiert
        /// </summary>
        public TabItem TabItem;

        /// <summary>
        /// Der Verlauf dieses Tabs
        /// </summary>
        public IHistory History;

        /// <summary>
        /// Das CAEXElement, das durch diesen Tab gerade dargestellt wird
        /// </summary>
        public CAEXElement CurrentlyDisplayedCaexElement;

        /// <summary>
        /// Die abstrakte Fabrik zum Erstellen der TabPanel
        /// </summary>
        private AbstractTabPanelFactory _panelFactory;

        public Tab(AbstractTabPanelFactory panelFactory, CAEXElement currentlyDisplayedCaexElement)
        {
            _panelFactory = panelFactory;
            CurrentlyDisplayedCaexElement = currentlyDisplayedCaexElement;
            History = new ConcreteHistory(currentlyDisplayedCaexElement);
            TabItem = new TabItem();

            var tabPanel = panelFactory.CreateTabPanel(currentlyDisplayedCaexElement);
            tabPanel.Backward_Button.DataContext = History;
            tabPanel.Forward_Button.DataContext = History;
            TabItem.Content = tabPanel;
            TabItem.DataContext = currentlyDisplayedCaexElement;
            currentlyDisplayedCaexElement.Tab = this;
        }

        /// <summary>
        /// Lässt diesen Tab ein anderes CAEXElement darstellen
        /// </summary>
        /// <param name="newlyDisplayedCaexElement">Das CAEXElement, das nun dargestellt werden soll</param>
        /// <param name="logToHistory">Ob die Änderung im Verlauf geloggt werden soll</param>
        public void Display(CAEXElement newlyDisplayedCaexElement, bool logToHistory = true)
        {
            var tabPanel = _panelFactory.CreateTabPanel(newlyDisplayedCaexElement);
            tabPanel.Backward_Button.DataContext = History;
            tabPanel.Forward_Button.DataContext = History;
            TabItem.Content = tabPanel;
            TabItem.DataContext = newlyDisplayedCaexElement;

            // "Referenzen richtig biegen"
            CurrentlyDisplayedCaexElement.Tab = null;
            CurrentlyDisplayedCaexElement = newlyDisplayedCaexElement;
            CurrentlyDisplayedCaexElement.Tab = this;

            if (logToHistory)
            {
                History.AddElementToHistory(newlyDisplayedCaexElement);
            }
        }

        /// <summary>
        /// Informiert diesen Tab darüber, dass er geschlossen wurde.
        /// </summary>
        public void OnClosed()
        {
            CurrentlyDisplayedCaexElement.Tab = null;
        }

        /// <summary>
        /// Informiert diesen Tab darüber, dass er wiederhergestellt wurde.
        /// </summary>
        public void OnRestore()
        {
            CurrentlyDisplayedCaexElement.Tab = this;
        }
    }
}
