using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using AMLHelper.ElementExtraction;

namespace AMLHelper.Model
{
    class TreeViewModel : INotifyPropertyChanged
    {


        private ObservableCollection<CAEXElement> _treeList;
        public ObservableCollection<CAEXElement> TreeList
        {
            get { return _treeList; }
            set
            {
                _treeList = value;
                NotifiyPropertyChanged("TreeList");
            }
        }

        public TreeViewModel()
        {
            _treeList = new ObservableCollection<CAEXElement>();
        }

        public void DeleteAllNodes() {
                TreeList.Clear();
        }

        /// <summary>
        /// Entfernt das angegebene Element aus dem Baum. Der Baum wird dabei rekursiv durchlaufen.
        /// </summary>
        /// <param name="caex">Element, dass aus dem Baum entfernt werden soll.</param>
        public void RemoveItemFromTree(CAEXElement caex)
        {
            if (TreeList.Contains(caex))
            {
                TreeList.Remove(caex);
            }
            else
            {
                foreach (CAEXElement child in TreeList)
                {
                    RemoveItemFromTree(child, caex);
                }
            }
        }
        /// <summary>
        /// Entfernt das gegebene Element aus dem Baum. Durchsucht den Baum nach dem Element rekursiv.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="item"></param>
        private void RemoveItemFromTree(CAEXElement parent, CAEXElement item)
        {
            if (parent.ChildElements.Contains(item))
            {
                parent.ChildElements.Remove(item);
            }
            else
            {
                foreach (CAEXElement child in parent.ChildElements)
                {
                    RemoveItemFromTree(child, item);
                }
            }

        }

        public void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
                //TODO: Memoryleak beheben der auftritt wenn sehr oft neue Dateien geladen werden.
                //Dabei muss jede existierende Observable Collection gelöscht werden.
        }
        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void NotifiyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
        #endregion OnPropertyChanged
}
