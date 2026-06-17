using System;
using System.Collections.Generic;
using System.Text;
using SAPbouiCOM.Framework;

namespace Practice
{
    class Menu
    {
        //public void AddMenuItems()
        //{
        //    SAPbouiCOM.Menus oMenus = null;
        //    SAPbouiCOM.MenuItem oMenuItem = null;

        //    oMenus = Application.SBO_Application.Menus;

        //    SAPbouiCOM.MenuCreationParams oCreationPackage = null;
        //    oCreationPackage = ((SAPbouiCOM.MenuCreationParams)(Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams)));
        //    oMenuItem = Application.SBO_Application.Menus.Item("43520"); // moudles'

        //    oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_POPUP;
        //    oCreationPackage.UniqueID = "Practice";
        //    oCreationPackage.String = "Test";
        //    oCreationPackage.Enabled = true;
        //    oCreationPackage.Position = -1;

        //    oMenus = oMenuItem.SubMenus;

        //    try
        //    {
        //        //  If the manu already exists this code will fail
        //        oMenus.AddEx(oCreationPackage);
        //    }
        //    catch (Exception e)
        //    {

        //    }

        //    try
        //    {
        //        // Get the menu collection of the newly added pop-up item
        //        oMenuItem = Application.SBO_Application.Menus.Item("Practice");
        //        oMenus = oMenuItem.SubMenus;

        //        // Create s sub menu
        //        oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
        //        oCreationPackage.UniqueID = "Practice.Form1";
        //        oCreationPackage.String = "Form1";
        //        oMenus.AddEx(oCreationPackage);
        //    }
        //    catch (Exception er)
        //    { //  Menu already exists
        //        Application.SBO_Application.SetStatusBarMessage("Menu Already Exists", SAPbouiCOM.BoMessageTime.bmt_Short, true);
        //    }
        //}

            public void BasicStart() // -->Define a method to call basic functionalities as Company conenction,creation of menu and Table structure

        {
            CompanyConnection(); //1)Company connection
                                 //2) to create a menu
            string struser = "Select 1 from OUSR where \"SUPERUSER\"='Y' and \"USERID\"='" + Global.ocomp.UserSignature.ToString() + "'";
            SAPbobsCOM.Recordset oRs = (SAPbobsCOM.Recordset)Global.ocomp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            oRs.DoQuery(struser);
            if(oRs.RecordCount==1)
            {
                CreateMainMenu("3328", "DB", "AddonNameDB Creation", 11, 1, false);
            }


            CreateMainMenu("43520", "SSM", "Addon Management", 11,2,true); //Parent1
            CreateMainMenu("SSM", "SSMS", "Setup", 0, 2, false);//parent 2 step
            CreateMainMenu("SSMS", "VEHM", "Addon Setup", 0, 1, false);  //setup(No UDO)

            CreateMainMenu("SSM", "MAS", "Master", 1, 2, false);//parent 2 step
            CreateMainMenu("MAS", "MASRC", "Master Screen", 0, 1, false);  //setup(No UDO)
            CreateMainMenu("SSM", "Doc", "Document", 2, 2, false);//parent 2 step
            CreateMainMenu("Doc", "DocTy", "Document Screen", 0, 1, false);  //setup(No UDO)

            CreateMainMenu("43545", "REPITM", "Item Stock Report", 10, 1, false);  //setup(No UDO)

            //CreateMainMenu("SSM", "SSMT", "Transaction", 1, 2, false);
            //CreateMainMenu("SSMT", "VHTN", "Vehicle Tranaction", 0, 1, false); //Transaction UDO

            //CreateMainMenu("SSM", "SSMR", "Reports", 2, 2, false);
            //CreateMainMenu("SSMR", "VHTR", "Vehicle Details", 0, 1, false); // reports

            //udt,udf and udo:
            //  DataStructure objDS = new DataStructure();
            // objDS.CreateUD();
        }

        private void CompanyConnection()
        {
            
                try
                {
                    string sErrorMsg;
                    string cookie;
                    string connStr;
                    // Global.ocomp.
                    Global.ocomp = new SAPbobsCOM.Company();
                    cookie = Global.ocomp.GetContextCookie();
                    //    Global.oCompany = new SAPbobsCOM.Company();
                    //   cookie =Global.oCompany.GetContextCookie();
                    connStr = Application.SBO_Application.Company.GetConnectionContext(cookie);
                    Global.ocomp.SetSboLoginContext(connStr);
                    ////   if (Global.CF.IsSAPHANA())
                    ////  {
                    ////   Global.oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;
                    //// }
                    //// else
                    //// {
                    //Global.ocomp.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2019;
                    // }
                    // Global.oCompany.Connect();
                    Global.ocomp = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany(); // Reassign the ocomp with the session we conencted with sap b1
                    // sErrorMsg = Global.oCompany.GetLastErrorDescription();
                    Global.i = 5;
                    Application.SBO_Application.StatusBar.SetText("Basic Addon Connected Successfully", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                }
                catch
                {
                    Application.SBO_Application.MessageBox(Global.ocomp.GetLastErrorDescription().ToString(), 1, "OK", "", "");
                }
            }
        public void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.BeforeAction && pVal.MenuUID == "VEHM")
                {
                    Form1 obj1 = new Form1();
                    obj1.Show();
                    SAPbouiCOM.Form oFrm1 = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("SQLSET");
                    string strcheck = "Select \"U_SerName\",\"U_SerPass\",\"U_TriCont\" from \"@SR_OOBJ\"";
                    //define an object
                    SAPbouiCOM.EditText oedtusername, oedtpass;
                    SAPbouiCOM.ComboBox ocmbtriger;
                    //recordset
                    SAPbobsCOM.Recordset orsdata = (SAPbobsCOM.Recordset)Global.ocomp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    orsdata.DoQuery(strcheck);//execute a query in recordset
                    if (orsdata.RecordCount > 0) //already exist in the table
                    {
                        oFrm1.Freeze(true);
                        ((SAPbouiCOM.Button)oFrm1.Items.Item("Item_6").Specific).Caption = "Update";
                        //assign a field in defined object
                        oedtusername = (SAPbouiCOM.EditText)oFrm1.Items.Item("Item_1").Specific;
                        oedtpass = (SAPbouiCOM.EditText)oFrm1.Items.Item("Item_3").Specific;
                        ocmbtriger = (SAPbouiCOM.ComboBox)oFrm1.Items.Item("Item_5").Specific;

                        //assign a values to fields:
                        oedtusername.Value = orsdata.Fields.Item("U_SerName").Value.ToString();
                        oedtpass.Value = orsdata.Fields.Item("U_SerPass").Value.ToString();
                        ocmbtriger.Select(orsdata.Fields.Item("U_TriCont").Value.ToString(), SAPbouiCOM.BoSearchKey.psk_ByValue);
                        oFrm1.Freeze(false);
                    }

                }
                else if(pVal.BeforeAction && pVal.MenuUID == "DocTy")
                {
                    Doc oDoc = new Doc();
                    oDoc.Show();
                    SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("SR_OTRN"); //form defining assigin
                    string ocmbvalue; //string type variable declaration
                    SAPbouiCOM.ComboBox ocmb; // combo box declaring 
                    SAPbouiCOM.EditText oedt, oedt2;// edit text declaration
                    SAPbouiCOM.Matrix omatatt = (SAPbouiCOM.Matrix)ofrm.Items.Item("Item_14").Specific;  

                    //====================================================================================================================================
                    //defining==================================================
                    SAPbouiCOM.DBDataSource oDBH = (SAPbouiCOM.DBDataSource)ofrm.DataSources.DBDataSources.Item("@SR_OTRN");   //DEFINE  DATASOURCES.
                    SAPbouiCOM.DBDataSource oDBL = (SAPbouiCOM.DBDataSource)ofrm.DataSources.DBDataSources.Item("@SR_TRN1");   //DEFINE  DATASOURCES.
                    ocmb = (SAPbouiCOM.ComboBox)ofrm.Items.Item("Item_1").Specific; //assign/define a combo box                                                                              //1 step do generate series:
                    Global.objFun.LoadComboBoxSeries(ocmb, "SR_OTRN");  //  passing Parameter - ocmb is combo box in which to load a data of series, UDO ID .
                                                                       // STEP - 2 TO GENERATE A DOCNUM .
                                                                       // as we need a combo box of series selected value and udo id
                                                                       //to get va;ue from series
                    ocmbvalue = ocmb.Selected.Value;
                    long docno = ofrm.BusinessObject.GetNextSerialNumber(ocmbvalue, "SR_OTRN"); // TO GENERATE A VALUE OF DOCNUM BASED ON SERIES
                    //SET THE VALUE TO DOCNUM FIELD
                    oDBH.SetValue("DocNum", 0, docno.ToString()); // only set the value in string.
                    oedt = (SAPbouiCOM.EditText)ofrm.Items.Item("Item_12").Specific; //assign / define a edittext
                    oedt.Active = true;
                    oedt.String = "W";
                   // Global.objFun.SetNewLine(omatatt)
                }
                else if (pVal.BeforeAction && pVal.MenuUID == "MASRC")
                {
                    MasterNew objmas = new MasterNew();
                    objmas.Show();
                    SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FrmUOM"); //form defining as=nd assigning
                                                                                                               //form into Add mode.
                    if (ofrm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                    {
                        SAPbouiCOM.DBDataSource ods = (SAPbouiCOM.DBDataSource)ofrm.DataSources.DBDataSources.Item("@SR_OUOM");
                        ods.SetValue("Code", 0, Global.objFun.GetCodeGeneration("[@SR_OUOM]").ToString());
                       string str1 = "SELECT T0.[UomEntry], T0.[UomCode] FROM OUOM T0";
                       SAPbouiCOM.ComboBox ocmb = (SAPbouiCOM.ComboBox)ofrm.Items.Item("Item_6").Specific;   //object defining- Define a combo box
                      Global.objFun.setComboBoxValue(ocmb, str1);
                        // define & assign a form Add mode.
                    }
                }
                if (pVal.BeforeAction && pVal.MenuUID == "DB")
                {
                    //verify the user:
                    string struser = "Select 1 from OUSR where \"SUPERUSER\"='Y' and \"USERID\"='" + Global.ocomp.UserSignature.ToString() + "'";
                    SAPbobsCOM.Recordset oRs = (SAPbobsCOM.Recordset)Global.ocomp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    oRs.DoQuery(struser);
                    if (oRs.RecordCount == 1)
                    {
                        int msgvalue = Application.SBO_Application.MessageBox(" The database structure has been modified. In order to resume the process, all open windows will be closed. Do you want to continue adding the user-defined field?", 2, "Postpone", "Yes", "No");
                        if (msgvalue == 2)
                        {
                            Application.SBO_Application.SetStatusBarMessage("Please wait DB intialization inprogress ", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                            DataStructure obj = new DataStructure();
                            obj.CreateUD();
                            Application.SBO_Application.SetStatusBarMessage("DB was created successfully", SAPbouiCOM.BoMessageTime.bmt_Short, false);

                        }
                        else if (msgvalue == 1)
                        {
                            Application.SBO_Application.SetStatusBarMessage("Now user are working , will retry after sometinmes", SAPbouiCOM.BoMessageTime.bmt_Short, false);
                        }
                    }
                }
                //Find Mode
                else if (!pVal.BeforeAction && pVal.MenuUID == "1281")
                {
                    SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = ofrm.UniqueID.ToString();
                    switch (formtype)
                    {
                        case "SR_OTRN":
                            {
                                ofrm.Items.Item("Item_2").Enabled = true;
                                break;
                            }
                    }
                }
                //Add Form Mode Menu
                else if (!pVal.BeforeAction && pVal.MenuUID == "1282")
                {
                    // on;ly one form in a addon -> string FormTypeex=Application.SBO_Application.Forms.GetForm()//
                    //Multiple form then following steps to make dynamic :
                    SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = ofrm.UniqueID.ToString();
                    switch (formtype)
                    {
                        case "FrmUOM":
                            {
                                //This part need to write a code of Loading or opening a form by click a User defined menu's.
                                ofrm.Mode = SAPbouiCOM.BoFormMode.fm_ADD_MODE;
                                if (ofrm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                                {
                                    SAPbouiCOM.DBDataSource ods = (SAPbouiCOM.DBDataSource)ofrm.DataSources.DBDataSources.Item("@SR_OUOM");
                                    ods.SetValue("Code", 0, Global.objFun.GetCodeGeneration("[@SR_OUOM]").ToString());
                                    string str1 = "SELECT T0.[UomEntry], T0.[UomCode] FROM OUOM T0";
                                    SAPbouiCOM.ComboBox ocmb = (SAPbouiCOM.ComboBox)ofrm.Items.Item("Item_6").Specific;   //object defining- Define a combo box
                                    Global.objFun.setComboBoxValue(ocmb, str1);
                                    // string str1 = "SELECT T0.[PrcCode], T0.[PrcName] FROM OPRC T0";
                                    //   SAPbouiCOM.ComboBox ocmb = (SAPbouiCOM.ComboBox)ofrm.Items.Item("Item_3").Specific;   //object defining- Define a combo box
                                    //  Global.objFun.setComboBoxValue(ocmb, str1);
                                    // define & assign a form Add mode.
                                }
                                break;

                            }
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "");
            }
        }

        public void CreateMainMenu(string ParentMenuID, string MenuID, string MenuName, int Position, int imenutype, bool flgimg) // POP UP- PARENT
        {
            try
            {
                SAPbouiCOM.Menus oMenus = null; // Define a variable to "menus"
                SAPbouiCOM.MenuItem oMenuItem = null; // Define a variable to MenuItem

                oMenus = Application.SBO_Application.Menus;  // Assign a SAP menu

                SAPbouiCOM.MenuCreationParams oCreationPackage = null;   //Define a variable to menu creating parameter
                oCreationPackage = ((SAPbouiCOM.MenuCreationParams)(Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams)));
                oMenuItem = Application.SBO_Application.Menus.Item(ParentMenuID); // "43520" moudles'  //assign a Parent menu




                switch (imenutype)
                {
                    case 2:
                        {
                            oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_POPUP;
                            break;
                        }
                    case 1:
                        {
                            oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                            break;
                        }
                    case 3:
                        {
                            oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_SEPERATOR;
                            break;
                        }
                }

                oCreationPackage.UniqueID = MenuID;
                oCreationPackage.String = MenuName;
                oCreationPackage.Enabled = true;
                oCreationPackage.Position = Position;  //postion is integer and it start from 0 value

                //string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath).ToString();
                string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath).ToString();
                //string Img = string.Concat(path, @"\BANKREC1.png");
                //oCreationPackage.Image = Img;
                if (flgimg == true)
                {
                    if (MenuID == "SSM")
                    {
                        string Bank = string.Concat(path, @"\BANKREC1.png");
                        oCreationPackage.Image = Bank;
                    }
                    else if (MenuID == "pay")
                    {
                        string Pay = string.Concat(path, @"\BANKREC.png");
                        oCreationPackage.Image = Pay;
                    }

                }
                oMenus = oMenuItem.SubMenus;

                try
                {
                    //  If the menu already exists this code will fail
                    oMenus.AddEx(oCreationPackage);
                }
                catch (Exception ex)
                {

                }
            }
            catch
            {

            }
        }

        //public void CreateMainMenu(string ParentMenuID, string MenuID, string MenuName, int Position)
        //{
        //    try
        //    {
        //        SAPbouiCOM.Menus oMenus = null;
        //        SAPbouiCOM.MenuItem oMenuItem = null;

        //        oMenus = Application.SBO_Application.Menus;

        //        SAPbouiCOM.MenuCreationParams oCreationPackage = null;
        //        oCreationPackage = ((SAPbouiCOM.MenuCreationParams)(Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams)));
        //        oMenuItem = Application.SBO_Application.Menus.Item(ParentMenuID); // "43520" moudles'

        //        oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_POPUP;
        //        oCreationPackage.UniqueID = MenuID;
        //        oCreationPackage.String = MenuName;
        //        oCreationPackage.Enabled = true;
        //        oCreationPackage.Position = Position;

        //        //string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath).ToString();

        //        //string Img = string.Concat(path, @"\BANKREC1.png");
        //        //oCreationPackage.Image = Img;


        //        oMenus = oMenuItem.SubMenus;

        //        try
        //        {
        //            //  If the menu already exists this code will fail
        //            oMenus.AddEx(oCreationPackage);
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }
        //    catch
        //    {

        //    }
        //}


        private void CreateMenuItem(SAPbouiCOM.BoMenuType mType, string ParentMenuId, string MenuId, string MenuName, int position)  // CHILD (STRING & SEPARATOR)
        {
            SAPbouiCOM.Menus Menu = null;
            SAPbouiCOM.MenuItem MenuItem = null;
            Menu = Application.SBO_Application.Menus;
            //string rootPath = System.Windows.Forms.Application.StartupPath;
            //rootPath = rootPath.Remove(rootPath.Length - 9, 9);

            SAPbouiCOM.MenuCreationParams CreationPara = null;
            CreationPara = (SAPbouiCOM.MenuCreationParams)(Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams));
            MenuItem = Application.SBO_Application.Menus.Item(ParentMenuId);

            try
            {
                Menu = MenuItem.SubMenus;
                CreationPara.Type = mType;
                CreationPara.UniqueID = MenuId;
                CreationPara.String = MenuName;
                CreationPara.Position = position;
                CreationPara.Enabled = true;
                Menu.AddEx(CreationPara);
            }
            catch (Exception ex)
            {
                // Application.SBO_Application.MessageBox(ex.Message, 1, "Ok", "", "");
            }
        }


    }
}
