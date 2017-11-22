using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using CAEX_ClassModel;
using AMLEngineExtensions;
using System.IO;

namespace SplitTest
{
    public partial class Form1 : Form
    {
        private CAEXDocument myDoc;
        private CAEXDocument myDoc_Rumpf;
        private CAEXDocument myDoc_Splitter1;
        private CAEXDocument myDoc_Splitter2;
        private bool hasMerged = false;
        private string linkStart = "";
    	private string linkEnd = "";
        private string fileName = "";
        private string filePath = "";
        private static int splitCounter = 0; //(new Random()).Next(100000);
        private static int internalLinkNumber = 0;
        private string RumpfFileName="";
        private string SplitterFileName1="";
        private string SplitterFileName2="";


        public Form1()
        {
            InitializeComponent();
        }

        //*******************************************************
        //  Form events
        //*******************************************************

        private void btn_LoadCAEXFile_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                filePath = Path.GetDirectoryName(fileName);
                ShowFilesTree(filePath);
                //show all files in directory
                LoadCAEXFile(fileName);
            }
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            LoadCAEXFile(fileName);
        }

        private void btn_CreateCAEXFile_Click(object sender, EventArgs e)
        {
            //Erzeugen einer Klassenbibliothek
            myDoc = CAEXDocument.New_CAEXDocument();    
            SystemUnitClassLibType SUL = myDoc.CAEXFile.New_SystemUnitClassLibHierarchy("myClassLib");

            myDoc.CAEXFile.SetMetaInformation("SplitTest.exe", "SplitTest.exe", "ABB", "www.abb.com", "1.0", "1.0.0", DateTime.Now.ToString("yyyy-MM-dd"), "DemoProject", "DemoProject");

            //Generierung einer SystemUnit-Klasse
            SystemUnitFamilyType SUF = SUL.New_SystemUnitClass("myTankSystem");

            //Erzeugen von internen Elementen
            //ein Tank
            SUF.New_InternalElement("Tank");

            //ein Boden mit Attributen und Schnittstellen
            InternalElementType Boden = SUF.New_InternalElement("Boden");
            Boden.New_Attribute("Durchmesser");
            Boden.New_Attribute("Material");
            InterfaceClassType I1 = Boden.New_ExternalInterface("BodenAblaufStutzen");

            //eine Pumpe mit Schnittstelle und Attributen
            InternalElementType Pumpe = SUF.New_InternalElement("Pumpe");
            Pumpe.New_Attribute("Leistung");
            Pumpe.New_Attribute("Hersteller");
            InterfaceClassType I2 = Pumpe.New_ExternalInterface("PumpenEingang");
            I2.New_Attribute("Durchmesser");

            //ein Link zwischen Pumpe und Boden
            InternalLinkType L1 = SUF.New_InternalLink("Link");
            L1.RefPartnerSideA.Value = I1.CAEXPath().ToString();
            L1.RefPartnerSideB.Value = I2.CAEXPath().ToString();

            //Erzeugen einer Instanz-Hierarchie
            InstanceHierarchyType IH = myDoc.CAEXFile.New_InstanceHierarchy("myProject");
            InternalElementType IE1 = (InternalElementType)SUF.CreateClassInstance();
            IE1.Name.Value = "TankSystem1";
            
            AttributeType attr = IE1.New_Attribute("Durchmesser");
            attr.Value = "20";
            RevisionType rev = IE1.New_Revision(DateTime.Now, "Rainer");
            rev.SetNewVersion("2.0");
            rev.SetAuthorName("Rainer Drath");
            rev.SetComment("Das ist ein Kommentar");
            IH.Insert_InternalElement(IE1);
            
            //create second TankSystem
            InternalElementType newIE2 = (InternalElementType)SUF.CreateClassInstance();
            newIE2.Name.Value = "Tanksystem2";
            IH.Insert_InternalElement(newIE2);

            //create third TankSystem
            InternalElementType newIE3 = (InternalElementType)SUF.CreateClassInstance();
            newIE3.Name.Value = "Tanksystem3";
            IH.Insert_InternalElement(newIE3);

            //create fourth TankSystem
            InternalElementType newIE4 = (InternalElementType)SUF.CreateClassInstance();
            newIE4.Name.Value = "Tanksystem4";
            IH.Insert_InternalElement(newIE4);

            InterfaceClassType newintf = newIE4.New_ExternalInterface("In");
            /*
            //Mes create more internal Elements
            for (int i = 0; i < 10; i++)
            {
                InternalElementType ie = IH.New_InternalElement("Top Element " + i);
                createInternalElements(ie, 10);
            }*/
            //myShowTree(treeView1, myDoc);
            fileName = @"c:\temp\amltest.aml";
            myDoc.SaveToFile(fileName, true);
            LoadCAEXFile(fileName);
        }

        private void btnSetSplitPoint_Click(object sender, EventArgs e)
        {
            int m_SplitCounter = splitCounter +1;

            //Set maximum 2 split points
            if (splitCounter == 2)
            {
                MessageBox.Show("This software allows many splitpoints, but this test suite only two.");
                return;
            }

            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Please selecte a valid node.");
                return;
            }

            CAEXObject cObj = (CAEXObject)treeView1.SelectedNode.Tag;
            RumpfFileName = filePath + "\\Rumpf.aml";
            string SplitterFileName = filePath + "\\Splitter_" + cObj.Name.Value + ".aml";// + splitCounter.ToString() + ".aml";

            //try to set the splitpoint, it automatically validates if this is allowed
            if (cObj.SetSplitPointIfPossible(SplitterFileName, "part" + m_SplitCounter))
            {
                treeView1.SelectedNode.BackColor = Color.Beige;

                splitCounter++;

                if (splitCounter == 1) SplitterFileName1 = SplitterFileName;
                if (splitCounter == 2) SplitterFileName2 = SplitterFileName;

                lbl_split1.Text = RumpfFileName;
                lbl_Split2.Text = SplitterFileName1;
                lbl_Split3.Text = SplitterFileName2;
            }

            //second variant including type check
            //if (cObj is InternalElementType)
            //{
            //    InternalElementType IE = (InternalElementType)cObj;
            //    IE.SetSplitPoint(SplitterFileName, "part" + m_SplitCounter);
            //    treeView1.SelectedNode.BackColor = Color.Beige;
            //}

            //if (cObj is InstanceHierarchyType)
            //{
            //    InstanceHierarchyType IH = (InstanceHierarchyType)cObj;
            //    IH.SetSplitPoint(SplitterFileName, "part" + m_SplitCounter);
            //    treeView1.SelectedNode.BackColor = Color.Beige;
            //}

            //if (cObj is InterfaceClassLibType)
            //{
            //    InterfaceClassLibType ICLT = (InterfaceClassLibType)cObj;
            //    ICLT.SetSplitPoint(SplitterFileName, "part" + m_SplitCounter);
            //    treeView1.SelectedNode.BackColor = Color.Beige;
            //}


            //if (cObj is RoleClassLibType)
            //{
            //    RoleClassLibType RCLT = (RoleClassLibType)cObj;
            //    RCLT.SetSplitPoint(SplitterFileName, "part" + m_SplitCounter);
            //    treeView1.SelectedNode.BackColor = Color.Beige;
            //}

            //if (cObj is SystemUnitClassLibType)
            //{
            //    SystemUnitClassLibType SUCL = (SystemUnitClassLibType)cObj;
            //    SUCL.SetSplitPoint(SplitterFileName, "part" + m_SplitCounter);
            //    treeView1.SelectedNode.BackColor = Color.Beige;
            //}

        }

        private void btn_SplitCAEXFile_Click(object sender, EventArgs e)
        {
            //this splits the doc and saves it into a body aml file and a number of split files
            //the file names are defined while setting the splitpoints
            Dictionary<string, CAEXBasicObject> ErrorList = new Dictionary<string,CAEXBasicObject>();
            if (myDoc.SaveSplitModelParts(RumpfFileName, true, false))
            {
                //show sub documents separately in treeView1 and treeView2
                LoadCAEXFile(RumpfFileName);
                myDoc_Rumpf = CAEXDocument.LoadFromFile(RumpfFileName);
                myDoc_Rumpf.CAEXFile.UpdateCAEXObjectHashListsFastWithoutValidation();
                myShowTree(treeView2, myDoc_Rumpf);

                //load Splitter 1 if available
                if (SplitterFileName1 != "")
                {
                    myDoc_Splitter1 = CAEXDocument.LoadFromFile(SplitterFileName1);
                    myDoc_Splitter1.CAEXFile.UpdateCAEXObjectHashListsFastWithoutValidation();
                    if (myDoc_Splitter1 != null)
                    {
                        myShowTree(treeView3, myDoc_Splitter1);
                    }
                }

                //load Splitter 2
                if (SplitterFileName2 != "")
                {
                    myDoc_Splitter2 = CAEXDocument.LoadFromFile(SplitterFileName2);
                    myDoc_Splitter2.CAEXFile.UpdateCAEXObjectHashListsFastWithoutValidation();
                    if (myDoc_Splitter2 != null)
                    {
                        myShowTree(treeView4, myDoc_Splitter2);
                    }
                }

                //initialize the spliter file names for next re-use
                myDoc.DisposeCutPoints();
                SplitterFileName1 = "";
                SplitterFileName2 = "";
                splitCounter = 0;
            }
        }

        private void btnMainToContentView_Click(object sender, EventArgs e)
        {
            showAMLTextBox(myDoc);
        }
        private void btnSplit1ToContentView_Click(object sender, EventArgs e)
        {
            showAMLTextBox(myDoc_Rumpf);
        }
        private void btnSplit2ToContentView_Click(object sender, EventArgs e)
        {
            showAMLTextBox(myDoc_Splitter1);
        }
        private void btnSplit3ToContentView_Click(object sender, EventArgs e)
        {
            showAMLTextBox(myDoc_Splitter2);
        }
        private void mnuCreateLink_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Please select a node of type InternalElement");
                return;
            }

            InternalElementType IE = treeView1.SelectedNode.Tag as InternalElementType;
            if (IE == null)
            {
                MessageBox.Show("Selected Node is no InternalElement");
                return;
            }

            if (linkStart == "")
            {// set Link Start

                linkStart = IE.ID.Value;
            }
            else
            {//set Link End
                if (linkEnd == "")
                {

                    linkEnd = IE.ID.Value;
                }
                else
                {//Place Link
                    var link = IE.New_InternalLink("Link" + (internalLinkNumber++));
                    link.RefPartnerSideA.Value = linkStart;
                    link.RefPartnerSideB.Value = linkEnd;

                    IE.Insert_InternalLink(link);
                    linkStart = "";
                    linkEnd = "";
                    treeView1.Nodes.Clear();
                    myShowTree(treeView1, myDoc);
                }
            }
        }
        
        private void setSplitPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                InternalElementType IE = (InternalElementType)treeView1.SelectedNode.Tag;
                splitCounter++;
                string SplitterFileName = filePath + splitCounter + ".aml";
                IE.SetSplitPoint(SplitterFileName, "part" + splitCounter);
            }
            else
                MessageBox.Show("Please select a node of type InternalElement");
        }
        
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                CAEXBasicObject o = (CAEXBasicObject)treeView1.SelectedNode.Tag;
                o.Remove();
                treeView1.SelectedNode.Remove();
            }
            else
                MessageBox.Show("Please select a node");
            //InternalElementType IE2 = o.GetParent<InternalElementType>();

        }
        private void findAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                InternalElementType o = (InternalElementType)treeView1.SelectedNode.Tag;
                string value = o.GetAttributeValue("Durchmesser");
                if (value != "")
                    MessageBox.Show("Value of attribute Durchmesser: " + value);
                else
                    MessageBox.Show("attribute Durchmesser not found");
            }
            else
                MessageBox.Show("Please select a node");
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (linkStart == "")
            {
                mnuCreateLink.Text = "Start link";
            }
            else
            {
                if (linkEnd == "")
                {
                    mnuCreateLink.Text = "Link from " + linkStart;
                }
                else
                {
                    mnuCreateLink.Text = "Place link from " + linkStart + " to " + linkEnd;
                }
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            long ticksForMerge = 0;
            List<string> MergeComments = new List<string>();

            //this merge demonstrates how to merge
            //the mydoc.Merge() does all automatically: finding referenced files and ressolve them
            //this does not cover parent files that consider this file as merge split, in this case use alternative 2 below

            ticksForMerge = DateTime.Now.Ticks;
            myDoc.Merge(ref MergeComments);
            ticksForMerge = DateTime.Now.Ticks - ticksForMerge;

            //show the merged file in the Text Box
            //showAMLTextBox(myDoc);

            //save the merged file in a new file
            string path = filePath + "\\Rumpf1_Merged.aml";
            myDoc.SaveToFile(path, true);

            LoadCAEXFile(path);
            lbl_TimeForMerging.Text = TimeSpan.FromTicks(ticksForMerge).ToString();
            lbl_FileRequiredMerging.Text = "merged";
            updateMergeComments(MergeComments);

            myDoc.DisposeCutPoints();
            SplitterFileName1 = "";
            SplitterFileName2 = "";
            splitCounter = 0;
        }

        private void btnMerge2_Click(object sender, EventArgs e)
        {
            //this is another way of merging: handover a list of strings containing pathes to all files that should be merged
            string rootpath = fileName;
            List<string> MergeComments = new List<string>();
            ExternalizationExtensions.Merge(fileName, new string[] { "PartA.aml", "PartB.aml" }, ref MergeComments);
        }

        private void btn_repairIDError_Click(object sender, EventArgs e)
        {
            Dictionary<string, CAEXBasicObject> repairList = new Dictionary<string, CAEXBasicObject>();
            myDoc.RepairCAEXDoc(ref repairList);

            //Variant 1 - just overwrite
            //myDoc.SaveToFile(fileName, true);
            
            //Variant 2 - create repaired second file
            string repairedIDFileName = fileName + "_ID repaired.aml";
            myDoc.SaveToFile(repairedIDFileName, true);
            fileName = repairedIDFileName;

            IDErrorListBox.Items.Add("A repaired version of this file is saved in " + repairedIDFileName);

            updateErrorList(null, repairList);
            btn_repairIDError.Enabled = false;
        }


        private void btn_StandardLibrary_Click(object sender, EventArgs e)
        {
            myDoc.CAEXFile.SetMetaInformationStandardAutomationMLLibrary();
            myDoc.SaveToFile(fileName, true);
        }

        private void btn_updateHashTables_Click(object sender, EventArgs e)
        {
            listBox_PathHashTable.Items.Clear();

            Dictionary<string, CAEXObject> PathHashList = myDoc.CAEXFile.PathHashList;
            //Dictionary<string, CAEXObject> PathHashList2 = myDoc.getPathHashList2();
            foreach (string s in PathHashList.Keys)
            {
                CAEXObject cObj = PathHashList[s];
                listBox_PathHashTable.Items.Add(cObj.CAEXPath().ToString());
            }
        }

        private void treeView_Pathes_DoubleClick(object sender, EventArgs e)
        {
            fileName = Path.Combine(filePath, treeView_Pathes.SelectedNode.Text);
            LoadCAEXFile(fileName);
        }

        //*******************************************************
        //  End of Form events
        //*******************************************************

        /// <summary>
        /// this method fills the folder list with available folders which are childs of the shared folder
        /// </summary>
        private void ShowFilesTree(string filePath)
        {
            DirectoryInfo messageBox = new DirectoryInfo(filePath);
            FileInfo[] fileList = messageBox.GetFiles("*.*ml");
            treeView_Pathes.Nodes.Clear();
            foreach (FileInfo file in fileList)
            {
                treeView_Pathes.Nodes.Add(file.Name);
            }
        }

        private void updateErrorList(Dictionary<string, CAEXBasicObject> ReferenceErrorList, Dictionary<string, CAEXBasicObject> IDErrorList)
        {
            IDErrorListBox.Items.Clear();
            ReferenceErrorListBox.Items.Clear();
            string IDError="";

            if (IDErrorList != null)
                for (int i = 0; i < IDErrorList.Count(); i++)
                {
                    IDError = IDErrorList.ElementAt(i).Key;

                    if (checkBox_ShowWarnings.Checked)
                    {
                        IDErrorListBox.Items.Add(IDError);
                    }
                    else
                    {
                        if(!IDError.Contains("Warning"))
                            IDErrorListBox.Items.Add(IDError);
                    }
                }

            if (ReferenceErrorList != null)
                for (int i = 0; i < ReferenceErrorList.Count(); i++)
                {
                    ReferenceErrorListBox.Items.Add(ReferenceErrorList.ElementAt(i).Key);
                }
        }

        private void updateMergeComments(List<string> MergeCommentsList)
        {
            MergeCommentsListBox.Items.Clear();
            if (MergeCommentsList != null)
                for (int i = 0; i < MergeCommentsList.Count(); i++)
                {
                    MergeCommentsListBox.Items.Add(MergeCommentsList.ElementAt(i).ToString());
                }
        }

        private void LoadCAEXFile(string fileName)
        {
            Dictionary<string, CAEXBasicObject> IDErrorList = new Dictionary<string, CAEXBasicObject>();
            Dictionary<string, CAEXBasicObject> ReferenceErrorList = new Dictionary<string, CAEXBasicObject>();
            long referenceErrNumber = 0;
            long ticksForLoading = 0;
            long ticksForIDCheck = 0;
            long ticksForReferenceCheck = 0;
            long ticksForShowingTree = 0;
            long ticksForOverall = 0;
            long ticksOthers = 0;

            ticksForOverall = DateTime.Now.Ticks;
            myDoc = null;
            MergeCommentsListBox.Items.Clear();
            splitCounter = 0;
            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();
            treeView3.Nodes.Clear();
            treeView4.Nodes.Clear();
            ticksForLoading = DateTime.Now.Ticks;
            myDoc = CAEXDocument.LoadFromFile(fileName);
            ticksForLoading = DateTime.Now.Ticks - ticksForLoading;
            lbl_Ori.Text = fileName;
            filePath = Path.GetDirectoryName(fileName);
            btn_repairIDError.Enabled = false;

            //check routines
            //check ID and name conflicts 
            ticksForIDCheck = DateTime.Now.Ticks;
            myDoc.CAEXFile.UpdateCAEXObjectHashListsFastWithoutValidation();
            myDoc.CheckFastMultipleIDs(ref IDErrorList);
            lbl_IDErrorNumber.Text = "ID errors: " + IDErrorList.Count().ToString();
            ticksForIDCheck = DateTime.Now.Ticks - ticksForIDCheck;
            if (!hasMerged && IDErrorList.Count() > 0) btn_repairIDError.Enabled = true;

            //check reference consistency
            ticksForReferenceCheck = DateTime.Now.Ticks;
            referenceErrNumber = myDoc.CheckFastReferenceConsistency(ref ReferenceErrorList);
            lbl_ErrorNumber.Text = "reference errors: " + referenceErrNumber.ToString();
            updateErrorList(ReferenceErrorList, IDErrorList);
            ticksForReferenceCheck = DateTime.Now.Ticks - ticksForReferenceCheck;

            //statistics about the checked objects
            lbl_IENumber.Text = "IE: " + myDoc.CAEXFile.NumberOfInternalElements.ToString();
            lbl_AttributeNumber.Text = "Attr: " + myDoc.CAEXFile.NumberOfAttributes.ToString();
            lbl_InterfaceNumber.Text = "Interfaces: " + myDoc.CAEXFile.NumberOfInterfaceInstances.ToString();
            lbl_InterfaceClassNumber.Text = "Interface classes: " + myDoc.CAEXFile.NumberOfInterfaceClasses.ToString();
            lbl_RoleClassNumber.Text = "Role classes: " + myDoc.CAEXFile.NumberOfRoleClasses.ToString();
            lbl_SUCNumber.Text = "SystemUnit classes: " + myDoc.CAEXFile.NumberOfSystemUnitClasses.ToString();
            lbl_LinkNumber.Text = "Links: " + myDoc.CAEXFile.NumberOfLinks.ToString();
            lbl_numberOfAllObjects.Text = "Object count: " + myDoc.CAEXFile.NumberOfAllObjects.ToString();

            if (myDoc.CAEXFile.GetMetaInformation().Count() > 0)
            {
                MetaInformation m = myDoc.CAEXFile.GetMetaInformation().First();
                if (m != null) lbl_Source.Text = m.WriterName + " (" + m.LastWritingDateTime + ")";
            }

            ticksForShowingTree = DateTime.Now.Ticks;
            myShowTree(treeView1, myDoc);
            ticksForShowingTree = DateTime.Now.Ticks - ticksForShowingTree;

            //present consumed times
            ticksForOverall = DateTime.Now.Ticks - ticksForOverall;
            ticksOthers = ticksForOverall - ticksForLoading - ticksForIDCheck - ticksForReferenceCheck - ticksForShowingTree;

            lbl_TimeForIDCheck.Text = TimeSpan.FromTicks(ticksForIDCheck).ToString();
            lbl_TimeCheckReferences.Text = TimeSpan.FromTicks(ticksForReferenceCheck).ToString();
            lbl_TimeOthers.Text = TimeSpan.FromTicks(ticksOthers).ToString(); ;
            lbl_TimeOverall.Text = TimeSpan.FromTicks(ticksForOverall).ToString();
            lbl_TimeShowTree.Text = TimeSpan.FromTicks(ticksForShowingTree).ToString();
            lbl_TimeForLoading.Text = TimeSpan.FromTicks(ticksForLoading).ToString();
            lbl_TimeForMerging.Text = "00:00:00";
            lbl_PathHashTable.Text = "PathHashTable (" + myDoc.CAEXFile.PathHashList.Count.ToString() + " items)";
            lbl_FileRequiredMerging.Text = "not merged";
            btn_Reload.Enabled = true;
        }
        
        private void myShowTree(TreeView myTreeView, CAEXDocument doc)
        {
            myTreeView.Nodes.Clear();
            foreach (InstanceHierarchyType IH in doc.CAEXFile.InstanceHierarchy)
            {
                TreeNode node = myTreeView.Nodes.Add("Hierarchy: " + IH.Name.Value);
                node.Tag = IH;
                foreach (InternalElementType IE in IH.InternalElement)
                {
                    myShowInternalElement(node, IE);
                }
            }
            foreach (RoleClassLibType RL in doc.CAEXFile.RoleClassLib)
            {
                TreeNode node = myTreeView.Nodes.Add("RoleClassLibrary: " + RL.Name.Value);
                node.Tag = RL;
                foreach (RoleFamilyType RC in RL.RoleClass)
                {
                    myShowRoleClasses(node, RC);
                }
            }
            foreach (SystemUnitClassLibType SUCL in doc.CAEXFile.SystemUnitClassLib)
            {
                TreeNode node = myTreeView.Nodes.Add("SystemUnitClassLibrary: " + SUCL.Name.Value);
                node.Tag = SUCL;
                foreach (SystemUnitFamilyType SUC in SUCL.SystemUnitClass)
                {
                    myShowSystemUnitClasses(node, SUC);
                }
            }
            foreach (InterfaceClassLibType IFCL in doc.CAEXFile.InterfaceClassLib)
            {
                TreeNode node = myTreeView.Nodes.Add("InterfaceClassLibrary: " + IFCL.Name.Value);
                node.Tag = IFCL;
                foreach (InterfaceFamilyType IFC in IFCL.InterfaceClass)
                {
                    myShowInterfaceClasses(node, IFC); 
                }
            }
        }

        private void myShowInternalElement(TreeNode node, InternalElementType IE)
        {
            TreeNode childNode = node.Nodes.Add("IE: " + IE.Name.Value);
            childNode.Tag = IE; 

            //show Links of this InternalElement
			foreach(InternalLinkType link in IE.InternalLink)
			{
                TreeNode linkNode;
                if (link.RefPartnerSideA.Exists() && link.RefPartnerSideB.Exists())
                {
                    linkNode = childNode.Nodes.Add("<<Link>> " + link.RefPartnerSideA.Value + " -> " + link.RefPartnerSideB.Value);
                }
                else
                {
                    linkNode = childNode.Nodes.Add("<<Link>> errors in this link, see XML file");
                }
				linkNode.Tag = link;
			}

            //show ExternalInterfaces of this InternalElement
            foreach (InterfaceClassType intf in IE.ExternalInterface)
            {
                myShowInterface(childNode, intf);
            }

            //show child InternalElements
            foreach (InternalElementType childIE in IE.InternalElement)
            {
                myShowInternalElement(childNode, childIE);
            }
        }
        private void myShowRoleClasses(TreeNode node, RoleFamilyType RC)
        {
            TreeNode childNode = node.Nodes.Add("RC: " + RC.Name.Value);
            childNode.Tag = RC;
            foreach (RoleFamilyType childRC in RC.RoleClass)
            {
                myShowRoleClasses(childNode, childRC);
            }
            //show ExternalInterfaces of this RoleClass
            foreach (InterfaceClassType intf in RC.ExternalInterface)
            {
                myShowInterface(childNode, intf);
            }
        }

        private void myShowInterfaceClasses(TreeNode node, InterfaceFamilyType IC)
        {
            TreeNode childNode = node.Nodes.Add("IC: " + IC.Name.Value);
            childNode.Tag = IC;
            foreach (InterfaceFamilyType childIC in IC.InterfaceClass)
            {
                myShowInterfaceClasses(childNode, childIC);
            }
        }

        private void myShowSystemUnitClasses(TreeNode node, SystemUnitFamilyType SUC)
        {
            TreeNode childNode = node.Nodes.Add("SUC: " + SUC.Name.Value);
            childNode.Tag = SUC;
            
            //show InternalElements
            foreach (InternalElementType IE in SUC.InternalElement)
            {
                myShowInternalElement(childNode, IE);
            }
            //show ExternalInterfaces of this InternalElement
            foreach (InterfaceClassType intf in SUC.ExternalInterface)
            {
                myShowInterface(childNode, intf);
            }
            //show child SystemUnitClasses
            foreach (SystemUnitFamilyType childSUC in SUC.SystemUnitClass)
            {
                myShowSystemUnitClasses(childNode, childSUC);
            }
        }

        private void myShowInterface(TreeNode node, InterfaceClassType IC)
        {
            TreeNode childNode = node.Nodes.Add("IF: " + IC.Name.Value);
            childNode.Tag = IC;
        }

    	private static int createdElementRunningNumber = 0;

		private void createInternalElements(InternalElementType parent,int count)
		{
			for(int i=0;i<count;i++)
				parent.New_InternalElement("Element " + (++createdElementRunningNumber));

		}

		private void showAMLTextBox(CAEXDocument doc)
		{
			if (doc==null)
				return;
			string path = filePath + "View.aml";
			doc.SaveToFile(path, true);
			string content = File.ReadAllText(path);
			txtAMLContent.Text = content;
		}

        private void checkBox_ShowWarnings_CheckedChanged(object sender, EventArgs e)
        {
            LoadCAEXFile(fileName);
        }
    }
}
