using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CAEX_ClassModel;
namespace AMLHelper.ElementExtraction
{
    /// <summary>
    /// Repräsentiert ein internes Element aus einer CAEX-Struktur, im AMLHelper
    /// </summary>
    public class InternalElementElement : CAEXElement
    {
        /// <summary>
        /// Die durch dieses interne Element implementierten Interfaces
        /// </summary>
        private ObservableCollection<InterfaceElement> _interfaces;

        /// <summary>
        /// Die durch dieses interne Element implementierten Interfaces
        /// </summary>
        public ObservableCollection<InterfaceElement> Interfaces
        {
            get { return _interfaces; }
            set
            {
                if (value == _interfaces) return;
                _interfaces = value;
                OnPropertyChanged("Interfaces");
            }
        }

        /// <summary>
        /// Die diesem internen Element untergeordneten internen Elemente
        /// </summary>
        private ObservableCollection<InternalElementElement> _internalElements;

        /// <summary>
        /// Die diesem internen Element untergeordneten internen Elemente
        /// </summary>
        public ObservableCollection<InternalElementElement> InternalElements
        {
            get { return _internalElements; }
            set
            {
                if (value == _internalElements) return;
                _internalElements = value;
                OnPropertyChanged("InternalElements");
            }
        }

        /// <summary>
        /// Die diesem internen Element untergeordneten role Classes
        /// </summary>
        private ObservableCollection<SupportedRoleElement> _roleClasses;

        public ObservableCollection<SupportedRoleElement> RoleClasses
        {
            get { return _roleClasses; }
            set
            {
                if (value == _roleClasses) return;
                _roleClasses = value;
                OnPropertyChanged("RoleClasses");
            }
        }

        public void AddChild(CAEXElement child) 
        {
            
            var @switch = new Dictionary<Type, Action> {
                { typeof(InternalElementElement), () => {InternalElements.Add((InternalElementElement)child); ChildElements.Add(child);} },
                { typeof(InterfaceElement), () => {_interfaces.Add((InterfaceElement)child); ChildElements.Add(child);} },
                { typeof(SupportedRoleElement), () => _roleClasses.Add((SupportedRoleElement)child)},
            };

            if (@switch.ContainsKey(child.GetType()))
            {
                @switch[child.GetType()]();
            }

  
        }

        public InternalElementElement(InternalElementType internalElement, CAEXElement parent)
        {
            Name = internalElement.Name.Value;
            OriginalName = internalElement.Name.Value;
            NameChanged = false;
            Caex = internalElement;
            ParentElements = new ObservableCollection<CAEXElement>();
            ChildElements = new ObservableCollection<CAEXElement>();
            _internalElements = new ObservableCollection<InternalElementElement>();
            _interfaces = new ObservableCollection<InterfaceElement>();
            _roleClasses = new ObservableCollection<SupportedRoleElement>();
            if (parent.ParentElements != null)
            {
                foreach (CAEXElement ancestor in parent.ParentElements)
                {
                    ParentElements.Add(ancestor);
                }
            }
            ParentElements.Add(parent);
            CreateTree(internalElement);
        }

        private void CreateTree(InternalElementType internalElement)
        {
            foreach(InternalElementType ie in internalElement.InternalElement) {
                AddChild(new InternalElementElement(ie, this));
            }
            foreach (InterfaceClassType interf in internalElement.ExternalInterface)
            {
                InterfaceElement interfaceElement = new InterfaceElement(interf);
                foreach (CAEXElement ancestor in ParentElements)
                {
                    interfaceElement.ParentElements.Add(ancestor);
                }
                interfaceElement.ParentElements.Add(this);
                AddChild(interfaceElement);
            }
            foreach (SupportedRoleClassType role in internalElement.SupportedRoleClass)
            {
                AddChild(new SupportedRoleElement(role, true));
            }
            /*try
            {
                var sysUnitPath = internalElement.RefBaseSystemUnitPath.Value;
                var sysUnitIE = (SystemUnitClassType)FileInstance.getInstance().Data.FindFastByPath(sysUnitPath);

                foreach (SupportedRoleClassType role in sysUnitIE.SupportedRoleClass)
                {
                    AddChild(new SupportedRoleElement(role, false));
                }
            }
            catch (NullReferenceException e)
            {
                
            }
            */
            
        }
    }//end InternalElement

}//end namespace ElementExtraction