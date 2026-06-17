using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM.Framework;

namespace Practice
{
    class SAPSalesOrder
    {
        public  SAPSalesOrder()
        {
            Application.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent);
            Application.SBO_Application.FormDataEvent += new SAPbouiCOM._IApplicationEvents_FormDataEventEventHandler(oApplication_FormDataEvent);
        }

        private void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {

                if (pVal.FormTypeEx == "139" && pVal.EventType != SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD)
                {
                    //define a form in 3 ways 
                    SAPbouiCOM.Form oform = Application.SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount); //1)
                    //2)
                   //                                                                                                                        SAPbouiCOM.Form oform2 = Application.SBO_Application.Forms.ActiveForm;//2 
                   //// 3 method to define a form
                   //                                                                                                                        SAPbouiCOM.Form oform3 = Application.SBO_Application.Forms.Item("139");
                   // define a form
                    if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_LOAD && pVal.BeforeAction == true)
                    {
                        //  SAPbouiCOM.Form orm = Application.SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount);
                        SAPbouiCOM.Item oNewItem = oform.Items.Add("st_1", SAPbouiCOM.BoFormItemTypes.it_STATIC); // we are going to create
                        SAPbouiCOM.Item osrc = oform.Items.Item("86");
                        oNewItem.Top = osrc.Top + 21;
                        oNewItem.Height = osrc.Height;
                        oNewItem.Width = osrc.Width;
                        oNewItem.Left = osrc.Left;


                        //property static field
                        SAPbouiCOM.StaticText ost = ((SAPbouiCOM.StaticText)(oNewItem.Specific));
                        ost.Caption = "Total value";


                        SAPbouiCOM.Item oNewItem1 = oform.Items.Add("edi", SAPbouiCOM.BoFormItemTypes.it_EDIT); // we are going to create
                        SAPbouiCOM.Item orsc1 = oform.Items.Item("46");
                        oNewItem1.Top = oNewItem.Top;
                        oNewItem1.Height = orsc1.Height;
                        oNewItem1.Width = orsc1.Width;
                        oNewItem1.Left = orsc1.Left;

                        //specific property for edit text.
                        SAPbouiCOM.EditText oedt = (SAPbouiCOM.EditText)(oNewItem1.Specific);
                        oedt.Item.Enabled = false; // to disABLE A FIELD.
                        oedt.DataBind.SetBound(true, "ORDR", "U_Total"); //TO SAVE THE VALUE IN TABLE


                        SAPbouiCOM.Item oNewItem2 = oform.Items.Add("btn", SAPbouiCOM.BoFormItemTypes.it_BUTTON_COMBO); // we are going to create
                        SAPbouiCOM.Item osrc2 = oform.Items.Item("2");
                        oNewItem2.Top = osrc2.Top;
                        oNewItem2.Height = osrc2.Height;
                        oNewItem2.Width = osrc2.Width;
                        oNewItem2.Left = osrc2.Left + osrc2.Width + 2;
                        oNewItem2.DisplayDesc = true;
                        //define item
                        SAPbouiCOM.ButtonCombo btncomb;  //edittext object varible
                        btncomb = (SAPbouiCOM.ButtonCombo)oform.Items.Item("btn").Specific; //assign the object to item
                        btncomb.ValidValues.Add("GR", "Goods Receipt");
                        btncomb.ValidValues.Add("GI", "Goods Issue");
                        btncomb.Caption = "Select";

                        SAPbouiCOM.Item oNewItemN,oNewItemN1;
                        SAPbouiCOM.Item oItem;
                        SAPbouiCOM.StaticText ostxt;
                        SAPbouiCOM.EditText oedttxt;
                        SAPbouiCOM.LinkedButton olk;
                        SAPbouiCOM.Button obtn;
                        SAPbouiCOM.ComboBox ocomb;
                        SAPbouiCOM.Folder ofd;
                        SAPbouiCOM.Grid OGRD;

                        oNewItemN = oform.Items.Add("btn1", SAPbouiCOM.BoFormItemTypes.it_BUTTON);

                        oItem = oform.Items.Item("st_1");
                      //  string str = oItem.Description;
                        oNewItemN.Left = oItem.Left;
                        oNewItemN.Width =25;
                        oNewItemN.Height =20;
                        oNewItemN.Top = oItem.Top+ oItem.Height+2;
                        oNewItemN.Visible = true;

                        SAPbouiCOM.Button btn = (SAPbouiCOM.Button)oNewItemN.Specific;
                        btn.Caption = "Get";

                        oNewItemN = oform.Items.Add("f_1", SAPbouiCOM.BoFormItemTypes.it_FOLDER);

                        oItem = oform.Items.Item("112");
                        string str = oItem.Description;
                        oNewItemN.Left = oItem.Left + oItem.Width + 3;
                        oNewItemN.Width = oItem.Width;
                        oNewItemN.Height = oItem.Height;
                        oNewItemN.Top = oItem.Top;
                        oNewItemN.Visible = true;

                        ofd = (SAPbouiCOM.Folder)oNewItemN.Specific;

                        ofd.Caption = "Optional Item";
                        ofd.GroupWith("112");
                        ofd.Pane = 200;



                        oNewItemN1 = oform.Items.Add("GRD", SAPbouiCOM.BoFormItemTypes.it_GRID);
                        oNewItemN1.Left = oform.Items.Item("38").Left;
                        oNewItemN1.Width = oform.Items.Item("38").Width;
                        oNewItemN1.Height =  oform.Items.Item("38").Height;
                        oNewItemN1.Top = oform.Items.Item("38").Top;
                        oNewItemN1.Visible = true;
                        oNewItemN1.FromPane = 200;
                        oNewItemN1.ToPane = 200;
                        OGRD = (SAPbouiCOM.Grid)oNewItemN1.Specific;
                        // SAPbouiCOM.DataTable odt;
                        oform.DataSources.DataTables.Add("DT_01"); //define datatable
                        OGRD.DataTable = oform.DataSources.DataTables.Item("DT_01"); //assign a datatable:



                    }

                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.BeforeAction == true)
                    {
                        if (pVal.ItemUID == "f_1")  //9 is key board ascii val;ue for "Tab" . So except tab remaining will be block.
                        {
                          oform.PaneLevel = 200;


                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.BeforeAction == false)
                    {
                        if (pVal.ItemUID == "btn1")  //9 is key board ascii val;ue for "Tab" . So except tab remaining will be block.
                        {
                            SAPbouiCOM.Grid oGrd = (SAPbouiCOM.Grid)oform.Items.Item("GRD").Specific;
                            //write a query:
                            string str1="Select 'N' As \"Selected\",\"ItemCode\",\"ItemName\",\"OnHand\",'0' as \"SpareQty\" from OITM where \"OnHand\">10";
                            oGrd.DataTable.ExecuteQuery(str1);
                            oGrd.Columns.Item("Selected").Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
                            oGrd.Columns.Item("Selected").Editable = true;
                            oGrd.Columns.Item("ItemCode").Editable = false;
                            oGrd.Columns.Item("ItemName").Editable = false;
                            oGrd.Columns.Item("OnHand").Editable = false;
                            oGrd.Columns.Item("SpareQty").Editable = true;
                            oGrd.AutoResizeColumns();

                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_KEY_DOWN && pVal.BeforeAction == true)
                    {
                        if (pVal.ItemUID == "edi" && pVal.CharPressed != 9)  //9 is key board ascii val;ue for "Tab" . So except tab remaining will be block.
                        {
                            Application.SBO_Application.SetStatusBarMessage("Do not change manually", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                            BubbleEvent = false;  //to hold an action /or not yet complete an action
                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_COMBO_SELECT && pVal.BeforeAction == true)
                    {
                        if (pVal.ItemUID == "btn" && oform.Mode!=SAPbouiCOM.BoFormMode.fm_OK_MODE)
                        {
                            Application.SBO_Application.SetStatusBarMessage("Add or update a document", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                            BubbleEvent = false;


                        }
                    }

                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_COMBO_SELECT && pVal.BeforeAction == false)
                    {
                        if (pVal.ItemUID == "btn")
                        {
                            SAPbouiCOM.ButtonCombo btn1 = (SAPbouiCOM.ButtonCombo)oform.Items.Item("btn").Specific;
                            string btntype = btn1.Selected.Value.ToString();
                            //   SAPbouiCOM.DataSource oDS = (SAPbouiCOM.DataSource)oform.DataSources.DBDataSources.Item("ORDR");
                            // int iDoc = Convert.ToInt32(((SAPbouiCOM.DataSource)oform.DataSources.DBDataSources.Item("ORDR"))GetValue("DocEntry", 0).ToString());
                            string strdocnum = ((SAPbouiCOM.EditText)oform.Items.Item("8").Specific).Value.ToString();
                            //Part of geting the data from sap so screen
                            string str = "SELECT T1.[DocEntry], T1.[LineNum], T1.[ItemCode], T1.[Dscription], T1.[Quantity], T1.[Price], T1.[WhsCode] FROM ORDR T0  INNER JOIN RDR1 T1 ON T0.[DocEntry] = T1.[DocEntry] WHERE T0.[DocNum]='"+ strdocnum+"'";
                            SAPbobsCOM.Recordset ors = ((SAPbobsCOM.Recordset)Global.ocomp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset));
                            ors.DoQuery(str);
                            switch (btntype)
                            {
                                case "GR":
                                    {

                                        Application.SBO_Application.ActivateMenuItem("3078"); //Active a menu to open a screen
                                                                                              //assign new form value:
                                        SAPbouiCOM.Form GRForm = Application.SBO_Application.Forms.GetFormByTypeAndCount(721, pVal.FormTypeCount);
                                        SAPbouiCOM.Matrix oMatGR = ((SAPbouiCOM.Matrix)GRForm.Items.Item("13").Specific);
                                        //mapping th fields:
                                        SAPbouiCOM.EditText oedtitem, oedtqty, oedtprice, oedtwhse;
                                        //usinga loop pass a value in the GR screen
                                        for(int i=1;i<=ors.RecordCount;i++)
                                        {
                                            ((SAPbouiCOM.EditText)oMatGR.Columns.Item("1").Cells.Item(i).Specific).Value = ors.Fields.Item("ItemCode").Value.ToString();
                                            ((SAPbouiCOM.EditText)oMatGR.Columns.Item("9").Cells.Item(i).Specific).Value = ors.Fields.Item("Quantity").Value.ToString();
                                            ((SAPbouiCOM.EditText)oMatGR.Columns.Item("10").Cells.Item(i).Specific).Value = ors.Fields.Item("Price").Value.ToString();
                                            ((SAPbouiCOM.EditText)oMatGR.Columns.Item("59").Cells.Item(i).Specific).Value = "500000";



                                            ors.MoveNext();
                                        }

                                        break;
                                    }
                                case "GI":
                                    {
                                        Application.SBO_Application.ActivateMenuItem("3079");
                                        break;
                                    }
                            }
                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_LOST_FOCUS && pVal.BeforeAction == false)
                    {
                        if (pVal.ItemUID == "38" && pVal.ColUID == "11") // condition  of object when to trigger
                        {
                            SAPbouiCOM.Matrix omat = (SAPbouiCOM.Matrix)oform.Items.Item("38").Specific; //defining & assign matrix
                            SAPbouiCOM.EditText oedttxt, oedtot;//Define a editext
                            string strcur;
                            double dbltotal = 0;

                            for (int i = 1; i <= omat.VisualRowCount - 1; i++)
                            {
                                oedttxt = (SAPbouiCOM.EditText)omat.Columns.Item("11").Cells.Item(i).Specific;  //define column as edittext

                                //  strcur = (oedttxt.Value).ToString().Substring(3);
                                //GET OR SET ANY VALUES TO EDITTEXT OR COMBOBOX / ELSE ANY OTHER ITEM IT IS NEED TO ASSIGN A STRING
                                dbltotal = dbltotal + Convert.ToDouble(oedttxt.Value.ToString());
                            }
                            oedtot = (SAPbouiCOM.EditText)oform.Items.Item("edi").Specific;
                            oedtot.Value = dbltotal.ToString();  //passing value to edittext
                        }

                        // pass the value to field 

                    }
                }
            }
            catch(Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage("Error in Itemevnt for SAP Screen - " + ex.ToString(), SAPbouiCOM.BoMessageTime.bmt_Medium, true);
            }
        }
        private static void oApplication_FormDataEvent(ref SAPbouiCOM.BusinessObjectInfo BusinessObjectInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if(BusinessObjectInfo.BeforeAction==true && BusinessObjectInfo.EventType==SAPbouiCOM.BoEventTypes.et_FORM_DATA_ADD)
            {
                switch (BusinessObjectInfo.FormTypeEx)
                {
                    case "139":
                        {
                            //logic
                            //to get a data from grid
                            //insert query or use di api service to insert into udo as defaultform or non udo

                                break;
                        }
                }
            }
           else if (BusinessObjectInfo.BeforeAction == false && BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_LOAD)
            {
                switch (BusinessObjectInfo.FormTypeEx)
                {
                    case "139":
                        {
                            //logic
                            //to get with udo or non objective table where sales order number exist or not
//if so no is exist then execute a query and pass the values to grid.


                            break;
                        }
                }
            }
        }

        }
    }
