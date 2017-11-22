using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAEX_ClassModel;
using AMLEngineExtensions;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private CAEXDocument myDoc;
        private string fileName;
        public Form1()
        {
            InitializeComponent();
        }

        /************************************************************/
        //Lade CAEX-Datei
        /************************************************************/

        private void btn_openCAEX_Click(object sender, EventArgs e)
        {
            myErrorListBox.Items.Clear();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                myDoc = null;
                CAEXTreeView.Nodes.Clear();
                fileName = openFileDialog.FileName;
                lbl_FileName.Text = fileName;
                myDoc = CAEXDocument.LoadFromFile(fileName);
                myShowTree(CAEXTreeView, myDoc);
            }
        }

        /************************************************************/
        //Erzeuge CAEX-Datei
        /************************************************************/
        private void btn_createCAEX_Click(object sender, EventArgs e)
        {
            myErrorListBox.Items.Clear();
            myDoc = null;
            CAEXTreeView.Nodes.Clear();
            InstanceHierarchyType IH;
            InternalElementType IE;
            InternalElementType IE2;
            InternalElementType IE3;
            InternalElementType IE4;
            InternalElementType IE5;
            AttributeType att;
            AttributeType att2;
            RoleClassLibType RCL;
            RoleClassType RC;
            SystemUnitClassLibType SUCL;
            SystemUnitClassType SUC;
            SystemUnitClassType SUC1;
            RevisionType rev;
            DateTime mydate;
            String myString;
            String myPath;
            ChangeMode ch;
            XmlDocument xmlDoc; 
            
            //initialize the CAEXDocument in case this method is called several times
            myDoc = null;

            //create a new CAEX document
            myDoc = CAEXDocument.New_CAEXDocument();

            // ***************************
            // ******** SystemUnitClass 
            // ***************************

            //create a set of SystemUnitClassLibs
            SUCL = myDoc.CAEXFile.New_SystemUnitClassLibHierarchy("MySUCLib");
            SUCL = myDoc.CAEXFile.New_SystemUnitClassLibHierarchy("MySUCLib1");
            SUCL = myDoc.CAEXFile.New_SystemUnitClassLibHierarchy("MySUCLib2");
            
            //create a new SystemUnitClass
            SUC = SUCL.New_SystemUnitClass("Class MyTank");

            //create another SystemUnitClass
            SUC1 = SUCL.New_SystemUnitClass("Class MyDeckel");

            //create a nested InternalElement within the SystemUnitClass
            IE3 = SUC.New_InternalElement("IE MyBoden");

            //create an instance of the "Deckel" within the SystemUnitClass "MyTank"
            Altova.Xml.TypeBase obj = ((SystemUnitFamilyType)SUC1).CreateClassInstance();
            IE4 = (InternalElementType)obj;
            IE4.Name.Value = "Instance IE Deckel";
            SUC1.Insert_NewInstance(obj);

            // ***************************
            // ******** RoleClasses
            // ***************************

            RCL = myDoc.CAEXFile.New_RoleClassLibHierarchy("MyRoleLib");
            RC = RCL.New_RoleClass("Deckel");

            // ***************************
            // ******** InstanceHierarchy 
            // ***************************

            //create a new InstanceHierarchy
            IH = myDoc.CAEXFile.New_InstanceHierarchy("MyHierarchy");

            //create a new InternalElement IE1
            IE = IH.New_InternalElement("IE");
            
            //***** Basic AML Extensions ****************************************************

            IE.SetRole(RC.getFullNodePath(RC.Node));            //eine AML-Extension-Methode! 
            IE.ID.Value = "GUID1";

            att = IE.New_Attribute("Gewicht");
            att.Value = "20";
            att.Unit.Value = "t";

            ((IObjectWithAttributes)IE).SetAttributeValue("Gewicht", "21");
            IE.SetAttributeValue("Masse1", "21");                               //eine AML-Extension-Methode!
            IE.SetAttributeValue("Masse2", "21", "p", "cs:string");             //eine AML-Extension-Methode!
            IE.SetAttributeValue("Masse3", "21", "10", "description", "cs:string", "cs:string");    //eine AML-Extension-Methode!
            IE.SetDescription("another description");

            myString = ((IObjectWithAttributes)IE).GetAttributeValue("Gewicht");//eine AML-Extension-Methode! 

            att = null;
            att = ((IObjectWithAttributes)IE).GetAttribute("Gewicht");

            //create a new InternalElement IE2

            IE2 = IH.New_InternalElement("IE2");

            att2 = IE.New_Attribute("Farbe");
            att2.Value = "gelb";

            var a = myDoc.CAEXFile.SystemUnitClassLib.All().Where(x => x.Name.Value == "MySUCLib");
            //now a is a list with all SystemUnitClassLibs with the name "MySUCLib"

            myString = IE.CAEXPath();                                               //eine AML-Extension-Methode! 

            IE.GetRoleName(out myPath, out myString);                           //eine AML-Extension-Methode! 

            //create a new InternalElement IE5
            
            IE5 = IE2.New_InternalElement("IE5");
            
            att2.Remove();                                                      //eine AML-Extension-Methode! 

            IE5.Remove();                                                       //eine AML-Extension-Methode! 

            IH.SetChangeMode(ChangeMode.Change);                //eine AML-Extension-Methode! 
            ch = IH.GetChangeMode();                            //eine AML-Extension-Methode! 

            //vendor specific meta information
            myDoc.CAEXFile.SetMetaInformation("WriterName", "WriterID", "WriterVendor", "www.writervendor.com", "writerVersion", "writerRelease", "LastWritingTime", "writerProjectTitle", "writerProjectID");

            //***** Navigation specific AML Extensions ****************************************************

            IE2 = null;
            IE2 = IE.Node.CreateCAEXWrapper<InternalElementType>();
            IE2=null;
            IE2 = (InternalElementType)IE.Node.CreateCAEXWrapper(); //eine AML-Extension-Methode! 

            xmlDoc = IE.Node.OwnerDocument;                     //eine AML-Extension-Methode! 

            IH = null;
            IH = IE.GetParent<InstanceHierarchyType>();         //eine AML-Extension-Methode! 

            myString = IE.GetParentNodeName();                  //eine AML-Extension-Methode! 

            IE = null;
            IE = (InternalElementType)myDoc.CAEXFile.FindFastByID("GUID1");     //ein AML-Extension-Methode
            IE = IH.FindByID<InternalElementType>("GUID1");     //eine AML-Extension-Methode! 
            IE = IH.findInternalElement("GUID1");               //keine AML-Extension, war in der AMLEngine schon enthalten

            myString = IE.CAEXPath();                                               //eine AML-Extension-Methode! 
            IE = null;
            IE = (InternalElementType)myDoc.CAEXFile.FindFastByPath(myString);    //eine AML-Extension-Methode!
            IE = null;
            IE = myDoc.CAEXFile.FindByXPath<InternalElementType>(myString);    //eine AML-Extension-Methode!

            
            //***** Specific AML Extensions ****************************************************
            
            rev = IE.New_Revision(DateTime.Now, "Peter Mustermann");      //eine AML-Extension-Methode!

            rev.SetRevisionDate(DateTime.Now);                  //eine AML-Extension-Methode! 
            mydate = rev.GetRevisionDate();                     //eine AML-Extension-Methode!     

            rev.SetAuthorName("Rainer");                        //eine AML-Extension-Methode!
            myString = rev.GetAuthorName();

            rev.SetNewVersion("1.2");                           //eine AML-Extension-Methode!
            myString = rev.GetNewVersion();

            rev.SetOldVersion("1.1");                           //eine AML-Extension-Methode!
            myString = rev.GetOldVersion();
            
            rev.OldVersion.SetValue("1.1");                     //eine AML-Extension-Methode!
            myString = rev.OldVersion.GetValue();               //eine AML-Extension-Methode!

            rev.NewVersion.SetValue("1.1");                     //eine AML-Extension-Methode!
            myString = rev.NewVersion.GetValue();               //eine AML-Extension-Methode!

            rev.Comment.SetValue("ein Kommentar");              //eine AML-Extension-Methode!
            myString = rev.Comment.GetValue();                  //eine AML-Extension-Methode!            

            myShowTree(CAEXTreeView, myDoc);           
        }

        /************************************************************/
        //Save CAEX-File
        /************************************************************/
        private void btn_SaveCAEX_Click(object sender, EventArgs e)
        {
            myErrorListBox.Items.Clear();
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                myDoc.SaveToFile(fileName, true);
                myDoc = CAEXDocument.LoadFromFile(fileName);
            }
        }

        /************************************************************/
        //Zeige CAEX-Datei
        /************************************************************/
        private void myShowTree(TreeView myTreeView, CAEXDocument doc)
        {
            foreach (InstanceHierarchyType IH in doc.CAEXFile.InstanceHierarchy)
            {
                TreeNode node = myTreeView.Nodes.Add(IH.Name.Value);
                node.Tag = IH;
                foreach (InternalElementType IE in IH.InternalElement)
                {
                    myShowInternalElement(node, IE);
                }
            }

            foreach (RoleClassLibType RL in doc.CAEXFile.RoleClassLib)
            {
                TreeNode node = myTreeView.Nodes.Add(RL.Name.Value);
                node.Tag = RL;
                foreach (RoleFamilyType RC in RL.RoleClass)
                {
                    myShowRoleClasses(node, RC);
                }
            }
        
            foreach (SystemUnitClassLibType SUCL in doc.CAEXFile.SystemUnitClassLib)
            {
                TreeNode node = myTreeView.Nodes.Add(SUCL.Name.Value);
                node.Tag = SUCL;
                foreach (SystemUnitFamilyType SUC in SUCL.SystemUnitClass)
                {
                    myShowSystemUnitClasses(node, SUC);
                }
            }

        }

        private void myShowInternalElement(TreeNode node, InternalElementType IE)
        {
            TreeNode childNode = node.Nodes.Add(IE.Name.Value);
            childNode.Tag = IE; 
            foreach (InternalElementType childIE in IE.InternalElement)
            {
                myShowInternalElement(childNode, childIE);
            }
        }

        private void myShowRoleClasses(TreeNode node, RoleFamilyType RC)
        {
            TreeNode childNode = node.Nodes.Add(RC.Name.Value);
            childNode.Tag = RC;
            foreach (RoleFamilyType childRC in RC.RoleClass)
            {
                myShowRoleClasses(childNode, childRC);
            }
        }

        private void myShowSystemUnitClasses(TreeNode node, SystemUnitFamilyType SUC)
        {
            TreeNode childNode = node.Nodes.Add(SUC.Name.Value);
            childNode.Tag = SUC;

            foreach(InternalElementType IE in SUC.InternalElement)
            {
                myShowInternalElement(childNode, IE);
            }
            foreach (SystemUnitFamilyType childSUC in SUC.SystemUnitClass)
            {
                myShowSystemUnitClasses(childNode, childSUC);
            }
        }

        private void btn_ValidateCAEXFile_Click(object sender, EventArgs e)
        {
            if (myDoc != null)
            {
                string filepath = myDoc.GetFileNamePath();
                Dictionary<string, CAEXBasicObject> IDErrorList = new Dictionary<string, CAEXBasicObject>();
                Dictionary<string, CAEXBasicObject> RefErrorList = new Dictionary<string, CAEXBasicObject>();
                int AnzIDFehler = myDoc.CheckFastMultipleIDs(ref IDErrorList);
                int AnzRefFehler = myDoc.CheckFastReferenceConsistency(ref RefErrorList);
                if (AnzIDFehler + AnzRefFehler == 0)
                {
                    MessageBox.Show("Result of CAEX Validation\nNo Errors.", "Validation Report");
                }
                else
                {
                    for (int i = 0; i < IDErrorList.Count(); i++)
                    {
                        myErrorListBox.Items.Add(IDErrorList.ElementAt(i).Key);
                    }
                    for (int i = 0; i < RefErrorList.Count(); i++)
                    {
                        myErrorListBox.Items.Add(RefErrorList.ElementAt(i).Key);
                    }
                    MessageBox.Show("Result of CAEX Validation\nNumber of Errors: " + (AnzIDFehler + AnzRefFehler).ToString() + "\nLook into the error list.", "Validation Report");
                }
            }
        }

        private void btn_EtikettCAEXFile_Click(object sender, EventArgs e)
        {
            CAEXDocument myCDoc = CAEXDocument.New_CAEXDocument();
            MetaInformation m = new MetaInformation();
            m.WriterName = "a Source Tool";
            m.WriterID = "a Source Tool";
            m.WriterVendor = "a company";
            m.WriterVendorURL = "www.acompany.com";
            m.WriterVersion = "1.0";
            m.WriterRelease = "1.0.1";
            m.LastWritingDateTime = "09.05.2012";
            m.WriterProjectTitle = "DemoProject";
            m.WriterProjectID = "DemoProject";
            myDoc.CAEXFile.SetMetaInformation(m);
        }

   }
}

