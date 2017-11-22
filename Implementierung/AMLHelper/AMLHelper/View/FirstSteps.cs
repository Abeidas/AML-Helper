using System.Diagnostics;
using System.Windows.Forms;

namespace AMLHelper.View
{
    /// ggf. erweitern um Hilfe zu anderen Dingen wie Internal Links, Role classes
    public partial class FirstSteps : Form
    {
        public FirstSteps()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.automationml.org/o.red.c/erste-schritte.html");
        }
    }
}
