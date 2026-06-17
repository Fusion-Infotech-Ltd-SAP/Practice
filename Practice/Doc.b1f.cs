using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Practice
{
    [FormAttribute("Practice.Doc", "Doc.b1f")]
    class Doc : UserFormBase
    {
        public Doc()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_14").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.Button0_PressedBefore);
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_5").Specific));
            this.EditText0.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.EditText0_ChooseFromListBefore);
            this.EditText0.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText0_ChooseFromListAfter);
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_6").Specific));
            this.Matrix1.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.Matrix1_LostFocusAfter);
            this.Matrix1.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.Matrix1_ChooseFromListAfter);
            this.ButtonCombo0 = ((SAPbouiCOM.ButtonCombo)(this.GetItem("Item_17").Specific));
            this.ButtonCombo0.ComboSelectAfter += new SAPbouiCOM._IButtonComboEvents_ComboSelectAfterEventHandler(this.ButtonCombo0_ComboSelectAfter);
            this.ButtonCombo0.ComboSelectBefore += new SAPbouiCOM._IButtonComboEvents_ComboSelectBeforeEventHandler(this.ButtonCombo0_ComboSelectBefore);
            this.ButtonCombo0.PressedBefore += new SAPbouiCOM._IButtonComboEvents_PressedBeforeEventHandler(this.ButtonCombo0_PressedBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_22").Specific));
            this.Button1.ChooseFromListAfter += new SAPbouiCOM._IButtonEvents_ChooseFromListAfterEventHandler(this.Button1_ChooseFromListAfter);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_18").Specific));
            this.Button2.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.Button2_PressedBefore);
            this.Button2.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button2_PressedAfter);
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("btnFiUp").Specific));
            this.Button3.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button3_PressedAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);
            this.RightClickBefore += new RightClickBeforeHandler(this.Form_RightClickBefore);

        }

        private SAPbouiCOM.Matrix Matrix0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.Button Button0;

        private void Button0_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("SR_OTRN"); //form defining assigin
                                                                                                       // throw new System.NotImplementedException();
            SAPbouiCOM.DBDataSource oDB = (SAPbouiCOM.DBDataSource)ofrm.DataSources.DBDataSources.Item("@SR_OTRN");
            SAPbouiCOM.DBDataSource oDBLine = (SAPbouiCOM.DBDataSource)ofrm.DataSources.DBDataSources.Item("@SR_TRN1");
            if(ofrm.Mode==SAPbouiCOM.BoFormMode.fm_ADD_MODE || ofrm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                if (oDB.GetValue("U_CardCode", 0).ToString() == "")
                {

                    Application.SBO_Application.SetStatusBarMessage("CardCode is missing", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                    BubbleEvent = false;
                    return;

                }
                if (oDBLine.GetValue("U_ItmCode", 0).ToString() == "")
                {
                    // BubbleEvent = false;
                    Application.SBO_Application.SetStatusBarMessage("ItemCode is mandatory", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                    BubbleEvent = false;
                    return;
                }
            }
              
        }

        private SAPbouiCOM.EditText EditText0;

        private void EditText0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oform = Application.SBO_Application.Forms.Item("SR_OTRN"); // DEFINE A FORM
            SAPbouiCOM.EditText oedt = (SAPbouiCOM.EditText)oform.Items.Item("Item_5").Specific;
            SAPbouiCOM.EditText oedt2 = (SAPbouiCOM.EditText)oform.Items.Item("Item_20").Specific;
            SAPbouiCOM.ISBOChooseFromListEventArg cflEvent = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal; //Assign a cfl and call event
            string Uid = cflEvent.ChooseFromListUID;  // cfl unique id
            SAPbouiCOM.DataTable dtbCFL = cflEvent.SelectedObjects;  //temporary datatable to hold the value of which we choosen
            SAPbouiCOM.Matrix omat, omat2;//MATRIX DECLARING
            omat = (SAPbouiCOM.Matrix)oform.Items.Item("Item_6").Specific; //assign /define a matrix
            omat2 = (SAPbouiCOM.Matrix)oform.Items.Item("Item_14").Specific; //assign /define a matrix

            SAPbouiCOM.DBDataSource oDBL = (SAPbouiCOM.DBDataSource)oform.DataSources.DBDataSources.Item("@SR_TRN1");   //DEFINE  DATASOURCES.
            SAPbouiCOM.DBDataSource oDBL2 = (SAPbouiCOM.DBDataSource)oform.DataSources.DBDataSources.Item("@SR_TRN2");   //DEFINE  DATASOURCES.
            // To set the selected value to field.
            SAPbouiCOM.DBDataSource odb = (SAPbouiCOM.DBDataSource)oform.DataSources.DBDataSources.Item("@SR_OTRN");
            //set the values - we have 2 methods
            //1 methoid - to set through a DB source
          //  oedt.Value = dtbCFL.GetValue("CardCode", 0).ToString();
          //  oedt2.Value = dtbCFL.GetValue("CardName", 0).ToString();
            //1 set 
             odb.SetValue("U_CardCode", 0, dtbCFL.GetValue("CardCode", 0).ToString());
          //  odb.SetValue("U_SODocNo", 0, dtbCFL.GetValue("CardName", 0).ToString());

            //AFTER SET VALUE , NEED TO ENABLE LINE IN MATRIX.
            if (omat.VisualRowCount==0)
            {
                Global.objFun.SetNewLine(omat, oDBL, 1, "");// added the line for matrix 1
            }
            if (omat2.VisualRowCount == 0)
            {
                Global.objFun.SetNewLine(omat2, oDBL2, 1, "");// added the line for matrix 1
            }
            //  Global.objFun.SetNewLine(omat2, oDBL2, 1, "");// added the line for matrix 2
            // get value and set value is a case sentivite in field info
            if (oform.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
            {
                oform.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
            }


        }

        private SAPbouiCOM.Matrix Matrix1;

        private void Matrix1_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //   throw new System.NotImplementedException();
            SAPbouiCOM.Form oform = Application.SBO_Application.Forms.Item("SR_OTRN"); // DEFINE A FORM
            SAPbouiCOM.ISBOChooseFromListEventArg cflEvent = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal; //Assign a cfl and call event
            string Uid = cflEvent.ChooseFromListUID;  // cfl unique id
            SAPbouiCOM.DataTable dtbCFL = cflEvent.SelectedObjects;  //temporary datatable to hold the value of which we choosen
            SAPbouiCOM.Matrix omat;//MATRIX DECLARING
            omat = (SAPbouiCOM.Matrix)oform.Items.Item("Item_6").Specific; //assign /define a matrix

            SAPbouiCOM.DBDataSource oDBL = (SAPbouiCOM.DBDataSource)oform.DataSources.DBDataSources.Item("@SR_TRN1");   //DEFINE  DATASOURCES.
            // To set the selected value to field.
            SAPbouiCOM.DBDataSource odb = (SAPbouiCOM.DBDataSource)oform.DataSources.DBDataSources.Item("@SR_OTRN");
            omat.FlushToDataSource();// if the matrix existing values will be need the flush / hit/ copy  to datasource (table) from the matrix
            if (pVal.ColUID == "Col_2")
            {
                oDBL.SetValue("U_ItmCode", pVal.Row - 1, dtbCFL.GetValue("ItemCode", 0).ToString());
                oDBL.SetValue("U_Desc", pVal.Row - 1, dtbCFL.GetValue("ItemName", 0).ToString());
                oDBL.SetValue("U_InStk", pVal.Row - 1, Convert.ToDouble(dtbCFL.GetValue("OnHand", 0).ToString()).ToString());
                oDBL.SetValue("U_Typ", pVal.Row - 1,(dtbCFL.GetValue("DfltWH", 0).ToString()));
            }
            else if(pVal.ColUID=="Col_9")
            {
                oDBL.SetValue("U_Typ", pVal.Row - 1, (dtbCFL.GetValue("WhsCode", 0).ToString()));
            }
            //to pass the value from datasource to matrix:
            omat.LoadFromDataSource();
            Global.objFun.SetNewLine(omat, oDBL, pVal.Row, "Col_2"); // SET NEW LINE / NEXT  LINE
        }

        private void Matrix1_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            SAPbouiCOM.Form oform = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("SR_OTRN");
            oform.Freeze(true);
            SAPbouiCOM.DBDataSource oDBH = (SAPbouiCOM.DBDataSource)oform.DataSources.DBDataSources.Item("@SR_OTRN");   //DEFINE header DATASOURCES.
            SAPbouiCOM.DBDataSource oDBL = (SAPbouiCOM.DBDataSource)oform.DataSources.DBDataSources.Item("@SR_TRN1");   //DEFINE matrix DATASOURCES.
            SAPbouiCOM.Matrix omat;//MATRIX DECLARING
            //define temporary variable.
            double dblqty, dblprc, dbltotal, dblline = 0.0;
            omat = (SAPbouiCOM.Matrix)oform.Items.Item("Item_6").Specific; //assign /define a matrix
            //IF YOU DB DATASOURCE OPERATION , 1ST NEED TO FLUSH TO DATASOURCE FROM MATRIX

            if (pVal.ColUID == "Col_6" || pVal.ColUID == "Col_7")
            {
                omat.FlushToDataSource();
                //Get the value from Quantity
                dblqty = Convert.ToDouble(oDBL.GetValue("U_Qty", pVal.Row - 1).ToString());
                dblprc = Convert.ToDouble(oDBL.GetValue("U_Prc", pVal.Row - 1).ToString());
                dbltotal = dblprc * dblqty;
                oDBL.SetValue("U_TotPrc", pVal.Row - 1, dbltotal.ToString()); // seting the data or value using db datasource.
                                                                              //pass the value to matrix

                // TO CALCULATE THE DOC TOTAL VALUE AND SUM ALL LINE IN MATRIX THEN TO ASSIGN: 
                //FOR THIS WE CAN USE THE SAME LOST FOCUS EVENT BECAUSE OF THE TOTAL PRICE IS NOT EDITABLE
                //before loading the total value to matrix, we can read out form the datasource:through getvalue method we can read the data.

                for (int irow = 1; irow <= omat.VisualRowCount; irow++)
                {
                    dblline = dblline + Convert.ToDouble(oDBL.GetValue("U_TotPrc", irow - 1).ToString());
                }

                oDBH.SetValue("U_Total", 0, dblline.ToString());
                omat.LoadFromDataSource();

            }

            oform.Freeze(false);


        }

        private SAPbouiCOM.ButtonCombo ButtonCombo0;

        private void ButtonCombo0_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            // throw new System.NotImplementedException();
            SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("SR_OTRN");
            SAPbouiCOM.DBDataSource ODB = (SAPbouiCOM.DBDataSource)ofrm.DataSources.DBDataSources.Item("@SR_OTRN");
            // all the validation will be taken place only at the before event:
            if (ODB.GetValue("U_CardCode", 0).ToString() == "")
            {
                Application.SBO_Application.SetStatusBarMessage("CardCode is manadatory.Please select a cardcode", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                BubbleEvent = false; //it will declare the flow of process, if it is false then only will restrict.
            }

        }

        private void ButtonCombo0_ComboSelectBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //  throw new System.NotImplementedException();
            SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("SR_OTRN");
            SAPbouiCOM.DBDataSource ODB = (SAPbouiCOM.DBDataSource)ofrm.DataSources.DBDataSources.Item("@SR_OTRN");
            // all the validation will be taken place only at the before event:
            if (ODB.GetValue("U_CardCode", 0).ToString() == "")
            {
                Application.SBO_Application.SetStatusBarMessage("CardCode is manadatory.Please select a cardcode", SAPbouiCOM.BoMessageTime.bmt_Short, true);
                BubbleEvent = false; //it will declare the flow of process, if it is false then only will restrict.
            }
        }

        private void ButtonCombo0_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

            SAPbouiCOM.Form oform = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("SR_OTRN");
            SAPbouiCOM.ButtonCombo ocmb = (SAPbouiCOM.ButtonCombo)oform.Items.Item("Item_17").Specific;
            SAPbouiCOM.DBDataSource oDBH = (SAPbouiCOM.DBDataSource)oform.DataSources.DBDataSources.Item("@SR_OTRN");   //DEFINE  DATASOURCES.

            string strvalue = ocmb.Selected.Value;
            switch (strvalue)
            {
                case "B":
                    {
                        break;
                    }
                case "SQ":
                    {
                        //BASED ON SELECTED OPTION OPEN THE FORM
                        CopyFromSQ obj2 = new CopyFromSQ();
                        obj2.Show();  //DISPLAY FORM
                        SAPbouiCOM.Form afrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("SR_CFSQ");
                        SAPbouiCOM.Grid ogrd = (SAPbouiCOM.Grid)afrm.Items.Item("Item_0").Specific;  //ASSIGNA GIRD TO LOAD VALUES
                        Global.GblStrCardcode = oDBH.GetValue("U_CardCode", 0).ToString();
                        string strquery = "SELECT 'N' AS \"SELECT\", T0.DOCENTRY,T0.[DocNum] , T0.[CardCode], T0.[CardName], T0.[NumAtCard], T0.[DocDate], T0.[DocTotal] FROM OQUT T0 WHERE T0.[CANCELED] ='N' and  T0.[DocStatus] ='O' and T0.[CardCode] ='" + oDBH.GetValue("U_CardCode", 0).ToString() + "'"; //TO QUERY DEFINE STRING AND PASS THE QUERY
                        ogrd.DataTable.ExecuteQuery(strquery);
                        ogrd.Columns.Item("SELECT").Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
                        ogrd.Columns.Item("DOCENTRY").Editable = false;
                        SAPbouiCOM.EditTextColumn oedtcol = (SAPbouiCOM.EditTextColumn)ogrd.Columns.Item("DOCENTRY");  // conversion from grid column to edittext beause to set a linked button.
                
                        oedtcol.LinkedObjectType = "23"; //Added a link in grid
                        ogrd.Columns.Item("DocNum").Editable = false;
                        ogrd.Columns.Item("CardCode").Editable = false;
                        ogrd.Columns.Item("CardName").Editable = false;
                        ogrd.Columns.Item("NumAtCard").Editable = false;
                        ogrd.Columns.Item("DocDate").Editable = false;
                        ogrd.Columns.Item("DocTotal").Editable = false;
                        ogrd.AutoResizeColumns();

                        Global.strcol = "DocNum";
                        //if(Global.ocomp.DbServerType==SAPbobsCOM.BoDataServerTypes.dst_HANADB)
                        //{

                        //}
                        //else
                        //{

                        //}
                        break;
                    }
            }


        }

        private SAPbouiCOM.Button Button1;

        private void Button1_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oform = Application.SBO_Application.Forms.Item("SR_OTRN"); // DEFINE A FORM
            SAPbouiCOM.EditText oedt = (SAPbouiCOM.EditText)oform.Items.Item("Item_5").Specific;
            SAPbouiCOM.EditText oedt2 = (SAPbouiCOM.EditText)oform.Items.Item("Item_20").Specific;
            SAPbouiCOM.ISBOChooseFromListEventArg cflEvent = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal; //Assign a cfl and call event
            string Uid = cflEvent.ChooseFromListUID;  // cfl unique id
            string strsqdocentry = "";
            
            SAPbouiCOM.DataTable dtbCFL = cflEvent.SelectedObjects;  //temporary datatable to hold the value of which we choosen
            if(!dtbCFL.IsEmpty)
            {
                for (int i = 0; i <= dtbCFL.Rows.Count - 1; i++)
                {
                    if (strsqdocentry == "")
                    {
                        strsqdocentry = "'" + dtbCFL.GetValue("DocEntry", i).ToString() + "'";
                    }
                    else
                    {
                        strsqdocentry = strsqdocentry + ",'" + dtbCFL.GetValue("DocEntry", i).ToString() + "'";
                    }
                }


                string strqry = "select * from (SELECT T0.[ItemCode], T0.[Dscription], T0.[OpenQty]- (SELECT SUM(I0.[U_Qty]) FROM [dbo].[@SR_TRN1]  I0 WHERE I0.[U_BaseEntry] =T0.DocEntry AND I0.[U_BaseRow] =T0.\"LineNum\") AS \"OpenQty\", T0.[Price], T0.[OpenQty]*T0.[Price] AS TOTAL,WhsCode,T1.OnHand,T0.\"DocEntry\",T2.\"ObjType\",T0.\"LineNum\" FROM QUT1 T0 left join OITM T1 ON T0.ItemCode=T1.ItemCode inner join OQUT T2 on T0.\"DocEntry\"=T2.\"DocEntry\" WHERE T0.[DocEntry] IN (" + strsqdocentry + ") ) as A where A.OpenQty>0";
                SAPbobsCOM.Recordset ors = (SAPbobsCOM.Recordset)Global.ocomp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                ors.DoQuery(strqry); //WILL CALL THE RECORDSET AND TO PASS THE STRING WHERE DECLARED THE QUERY.

                SAPbouiCOM.Matrix omat = (SAPbouiCOM.Matrix)oform.Items.Item("Item_6").Specific;//define matrix
                SAPbouiCOM.DBDataSource oDBH = (SAPbouiCOM.DBDataSource)oform.DataSources.DBDataSources.Item("@SR_OTRN");   //DEFINE  DATASOURCES.1
                SAPbouiCOM.DBDataSource oDBL = (SAPbouiCOM.DBDataSource)oform.DataSources.DBDataSources.Item("@SR_TRN1");   //DEFINE  DATASOURCES.1
                                                                                                                            //to pass the selected data, need to generate a FOR Loop.
                omat.FlushToDataSource(); // move the data from matrix to dbdatasource
                omat.Clear();// clear or remove from matrix
                oDBL.Clear(); // clear or remove from dbdatasource(in backend table)
                double dbltotal = 0.0;
                for (int irow = 1; irow <= ors.RecordCount; irow++) //ToString load a data from record set to dbdatasource
                {
                    oDBL.InsertRecord(irow - 1);
                    oDBL.SetValue("LineId", irow - 1, irow.ToString());
                    oDBL.SetValue("U_ItmCode", irow - 1, ors.Fields.Item("ItemCode").Value.ToString());
                    oDBL.SetValue("U_Desc", irow - 1, ors.Fields.Item("Dscription").Value.ToString());
                    oDBL.SetValue("U_Qty", irow - 1, ors.Fields.Item("OpenQty").Value.ToString());
                    oDBL.SetValue("U_Prc", irow - 1, ors.Fields.Item("Price").Value.ToString());
                    oDBL.SetValue("U_TotPrc", irow - 1, ors.Fields.Item("TOTAL").Value.ToString());
                    oDBL.SetValue("U_Typ", irow - 1, ors.Fields.Item("WhsCode").Value.ToString());
                    oDBL.SetValue("U_InStk", irow - 1, ors.Fields.Item("OnHand").Value.ToString());
                    oDBL.SetValue("U_BaseEntry", irow - 1, ors.Fields.Item("DocEntry").Value.ToString());
                    oDBL.SetValue("U_BaseType", irow - 1, ors.Fields.Item("ObjType").Value.ToString());
                    oDBL.SetValue("U_BaseRow", irow - 1, ors.Fields.Item("LineNum").Value.ToString());
                    dbltotal = dbltotal + Convert.ToDouble(ors.Fields.Item("TOTAL").Value.ToString());
                    //to move recordset
                    ors.MoveNext();
                }
                omat.LoadFromDataSource();
                oDBH.SetValue("U_Total", 0, dbltotal.ToString());
                Application.SBO_Application.SetStatusBarMessage("Data imported successfully", SAPbouiCOM.BoMessageTime.bmt_Short, false);

            }

            //throw new System.NotImplementedException();

        }

        private void EditText0_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
          //  throw new System.NotImplementedException();

        }

        private SAPbouiCOM.Button Button2;

        private void Button2_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("SR_OTRN");
            SAPbouiCOM.DBDataSource oDBH = (SAPbouiCOM.DBDataSource)ofrm.DataSources.DBDataSources.Item("@SR_OTRN");
            SAPbouiCOM.DBDataSource oDBL = (SAPbouiCOM.DBDataSource)ofrm.DataSources.DBDataSources.Item("@SR_TRN1");
            SAPbouiCOM.Matrix omatrix = (SAPbouiCOM.Matrix)ofrm.Items.Item("Item_6").Specific;
            SAPbouiCOM.Matrix oAttachmat = (SAPbouiCOM.Matrix)ofrm.Items.Item("Item_14").Specific;
            SAPbouiCOM.EditText oedtitem, oedqty, oedtprc,oedtbaseno,oedtbasetype,oedtbaserow,oedtAttch;

            //TO POST THE SALES ORDER USING DI API METHOD


            SAPbobsCOM.Documents oDocSO; //SO is document type , so we define oDocSo as under document in SAPbobCom
            oDocSO = (SAPbobsCOM.Documents)Global.ocomp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
            oDocSO.CardCode = oDBH.GetValue("U_CardCode", 0).ToString();
            oDocSO.DocDueDate = DateTime.Now;
            oDocSO.DocDate = DateTime.Now;
            oDocSO.BPL_IDAssignedToInvoice = 1;
          
            //POST THE ROW LEVEL VALUES:

            for (int i = 1; i <= omatrix.VisualRowCount; i++)
            {
                oedtitem = (SAPbouiCOM.EditText)omatrix.Columns.Item("Col_2").Cells.Item(i).Specific;
                oedtprc = (SAPbouiCOM.EditText)omatrix.Columns.Item("Col_7").Cells.Item(i).Specific;
                oedqty = (SAPbouiCOM.EditText)omatrix.Columns.Item("Col_6").Cells.Item(i).Specific;
                oedtbaseno= (SAPbouiCOM.EditText)omatrix.Columns.Item("Col_1").Cells.Item(i).Specific;
                oedtbaserow = (SAPbouiCOM.EditText)omatrix.Columns.Item("Col_11").Cells.Item(i).Specific;
                oedtbasetype = (SAPbouiCOM.EditText)omatrix.Columns.Item("Col_10").Cells.Item(i).Specific;

                //lines posting
                if (oedtitem.Value.ToString() != "")//validate wheather item is there or not
                {
                    oDocSO.Lines.ItemCode = oedtitem.Value.ToString(); //item code
                    oDocSO.Lines.Quantity = Convert.ToDouble(oedqty.Value.ToString()); //quantity
                    oDocSO.Lines.Price = Convert.ToDouble(oedqty.Value.ToString()); //price

                    oDocSO.Lines.BaseEntry = Convert.ToInt32(oedtbaseno.Value.ToString());
                    oDocSO.Lines.BaseType= Convert.ToInt32(oedtbasetype.Value.ToString());
                    oDocSO.Lines.BaseLine = Convert.ToInt32(oedtbaserow.Value.ToString());
                    oDocSO.Lines.Add();
                }
                //reference

                //  oDocSO.DocumentsObject = BoObjectTypes.oQuotations;  // Specify that it's referencing a Sales Quotation
                //  oDocSO.DocumentReference = salesQuotationDocEntry
                // oDocSO.Lines.RE
                //create a small function or use a few lines coding to post in oatc - get the docno from this and psass it to "  oDocSO.AttachmentEntry"
                //ATTACHMENT POSTINGS
                SAPbobsCOM.Attachments2 oAttach = (SAPbobsCOM.Attachments2)Global.ocomp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oAttachments2);
                //  SAPbobsCOM.Attachment oAt=(SAPbobsCOM.Attachment)Global.ocomp.GetBusinessObject(SAPbobsCOM.bo)
                for (int j =1;j<=oAttachmat.VisualRowCount;j++)
                {

                    oedtAttch = (SAPbouiCOM.EditText)oAttachmat.Columns.Item("Col_0").Cells.Item(j).Specific;
                    string strfile = oedtAttch.Value.ToString();
                    oAttach.Lines.FileName = System.IO.Path.GetFileNameWithoutExtension(strfile);
                    oAttach.Lines.FileExtension = System.IO.Path.GetExtension(strfile).Substring(1);
                    oAttach.Lines.SourcePath = System.IO.Path.GetDirectoryName(strfile);
                    oAttach.Lines.Override = SAPbobsCOM.BoYesNoEnum.tYES;

                }
                int iattchdocentry=0;
                if(oAttach.Add()==0)
                {
                    iattchdocentry = Convert.ToInt32(Global.ocomp.GetNewObjectKey());
                }

                oDocSO.AttachmentEntry = iattchdocentry;
                //attachment in oatc


            }
            // after passing the all Row and header information , need to add the document of SO atlast.

            int iresult = oDocSO.Add(); // Adding the complete document
            if (iresult == 0) // success posting
            {
                string strsodoc = Global.ocomp.GetNewObjectKey().ToString();
                oDBH.SetValue("U_SODocNo", 0, strsodoc);
            }
            else
            {
                Application.SBO_Application.SetStatusBarMessage("Error in SO posting " + Global.ocomp.GetLastErrorCode().ToString() + " " + Global.ocomp.GetLastErrorDescription().ToString(), SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }


            //throw new System.NotImplementedException();

        }

        private void Button2_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //  throw new System.NotImplementedException();
            int info = 0;
            info = Application.SBO_Application.MessageBox("Do you want to post a Sales Order Document?",1, "Yes", "No");
            if(info!=1)
            {
                BubbleEvent = false;
            }

        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("SR_OTRN");
            SAPbouiCOM.DBDataSource oDBH = (SAPbouiCOM.DBDataSource)ofrm.DataSources.DBDataSources.Item("@SR_OTRN");
            if(oDBH.GetValue("U_SODocNo",0).ToString()=="")
            {
                ofrm.Mode = SAPbouiCOM.BoFormMode.fm_OK_MODE;
            }
            else
            {
                ofrm.Mode = SAPbouiCOM.BoFormMode.fm_VIEW_MODE;
                ofrm.Items.Item("Item_16").Enabled = true;
            }
            //throw new System.NotImplementedException();

        }

        private void Form_RightClickBefore(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form ofrom = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item(eventInfo.FormUID); 
            SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("SR_OTRN");
            ofrm.Menu.Add("Dup", "Duplicate", SAPbouiCOM.BoMenuType.mt_STRING, 0);
            //  throw new System.NotImplementedException();

        }

        private SAPbouiCOM.Button Button3;

        private void Button3_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
            {
                ofd.Filter = "Excel Files|*.xls;*.xlsx";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string excelPath = ofd.FileName;
                    UploadExcelToHANA(excelPath);
                }
            }

        }
        private void UploadExcelToHANA(string filePath)
        {
            // Call the Main method from ExcelToHANA class above
            //ExcelToHANA.Main(filePath);
        }
    }
}
