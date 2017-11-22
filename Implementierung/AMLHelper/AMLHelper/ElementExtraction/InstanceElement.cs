using System.Collections.ObjectModel;
using CAEX_ClassModel;
namespace AMLHelper.ElementExtraction
{
    /// <summary>
    /// Repräsentiert die Instanz einer CAEX-Struktur, das der ganzen Struktur übergeordnete Element
    /// </summary>
    public class InstanceElement : CAEXElement
    {

        public InstanceElement(InstanceHierarchyType instance)
        {
            Name = instance.Name.Value;
            Caex = instance;
            OriginalName = instance.Name.Value;
            NameChanged = false;
            ChildElements = new ObservableCollection<CAEXElement>();
            ParentElements = null;
            BuildTree(instance);
        }

        private void BuildTree(InstanceHierarchyType ih)
        {
            foreach (InternalElementType ie in ih.InternalElement)
            {
                ChildElements.Add(new InternalElementElement(ie, this));
            }
        }
    }//end InstanceElement

}//end namespace ElementExtraction
