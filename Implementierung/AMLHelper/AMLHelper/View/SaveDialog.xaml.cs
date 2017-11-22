using System.Windows;

namespace AMLHelper.View
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    partial class SaveDialog : Window
    {
        /// <summary>
        /// Enum als Repräsentation der Wahl des Benutzers.
        /// </summary>
        public enum Choice { Cancel, Save, DontSave };
        public Choice _choice;

        public SaveDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Setzt die Wahl des Benutzers auf "speichern" und schließt den Dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _choice = Choice.Save;
            Close();
        }

        /// <summary>
        /// Setzt die Wahl des Benutzers auf "nicht speichern" und schließt den Dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DontSaveButton_Click(object sender, RoutedEventArgs e)
        {
           _choice = Choice.DontSave;
           Close();
        }

        /// <summary>
        /// Setzt die Wahl des Benutzers auf "abbrechen" und schließt den Dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _choice = Choice.Cancel;
            Close();
        }
    }
}
