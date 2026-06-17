using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Practice
{
    [FormAttribute("Practice.CopyFromSQ", "CopyFromSQ.b1f")]
    class CopyFromSQ : UserFormBase
    {
        public CopyFromSQ()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_4").Specific));
            this.EditText0.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.EditText0_LostFocusAfter);
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_0").Specific));
            this.Grid0.DoubleClickAfter += new SAPbouiCOM._IGridEvents_DoubleClickAfterEventHandler(this.Grid0_DoubleClickAfter);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.EditText EditText0;

        private void EditText0_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.EditText oedt = (SAPbouiCOM.EditText)ofrm.Items.Item("Item_4").Specific;
            string strdocno = oedt.Value.ToString();
            SAPbouiCOM.Grid ogrd = (SAPbouiCOM.Grid)ofrm.Items.Item("Item_0").Specific;  //ASSIGNA GIRD TO LOAD VALUES
            string strquery="";
            if (strdocno != "")
            {
                switch (Global.strcol)
                {
                    case "DocNum":
                        {
                            strquery = "SELECT 'N' AS \"SELECT\", T0.DOCENTRY,T0.[DocNum] , T0.[CardCode], T0.[CardName], T0.[NumAtCard], T0.[DocDate], T0.[DocTotal] FROM OQUT T0 WHERE T0.[CANCELED] ='N' and  T0.[DocStatus] ='O' and T0.[DocNum] ='" + strdocno + "'"; //TO QUERY DEFINE STRING AND PASS THE QUERY
                            break;
                        }

                    case "CardCode":
                        {
                            strquery = "SELECT 'N' AS \"SELECT\", T0.DOCENTRY,T0.[DocNum] , T0.[CardCode], T0.[CardName], T0.[NumAtCard], T0.[DocDate], T0.[DocTotal] FROM OQUT T0 WHERE T0.[CANCELED] ='N' and  T0.[DocStatus] ='O' and T0.[CardCode] ='" + strdocno + "'"; //TO QUERY DEFINE STRING AND PASS THE QUERY
                            break;
                        }

                    case "CardName":
                        {
                            strquery = "SELECT 'N' AS \"SELECT\", T0.DOCENTRY,T0.[DocNum] , T0.[CardCode], T0.[CardName], T0.[NumAtCard], T0.[DocDate], T0.[DocTotal] FROM OQUT T0 WHERE T0.[CANCELED] ='N' and  T0.[DocStatus] ='O' and T0.[CardName] ='" + strdocno + "'"; //TO QUERY DEFINE STRING AND PASS THE QUERY
                            break;
                        }

                    case "NumAtCard":
                        {
                            strquery = "SELECT 'N' AS \"SELECT\", T0.DOCENTRY,T0.[DocNum] , T0.[CardCode], T0.[CardName], T0.[NumAtCard], T0.[DocDate], T0.[DocTotal] FROM OQUT T0 WHERE T0.[CANCELED] ='N' and  T0.[DocStatus] ='O' and T0.[NumAtCard] ='" + strdocno + "'"; //TO QUERY DEFINE STRING AND PASS THE QUERY
                            break;
                        }
                }
            }
            else
            {
                 strquery = "SELECT 'N' AS \"SELECT\", T0.DOCENTRY,T0.[DocNum] , T0.[CardCode], T0.[CardName], T0.[NumAtCard], T0.[DocDate], T0.[DocTotal] FROM OQUT T0 WHERE T0.[CANCELED] ='N' and  T0.[DocStatus] ='O' and T0.[CardCode] ='" + Global.GblStrCardcode + "'"; //TO QUERY DEFINE STRING AND PASS THE QUERY

            }



            ogrd.DataTable.ExecuteQuery(strquery);

            ogrd.Columns.Item("SELECT").Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            ogrd.Columns.Item("DOCENTRY").Editable = false;
            SAPbouiCOM.EditTextColumn oedtcol = (SAPbouiCOM.EditTextColumn)ogrd.Columns.Item("DOCENTRY");  // conversion from grid column to edittext beause to set a linked button.
            oedtcol.LinkedObjectType = "23";
            ogrd.Columns.Item("DocNum").Editable = false;
            ogrd.Columns.Item("CardCode").Editable = false;
            ogrd.Columns.Item("CardName").Editable = false;
            ogrd.Columns.Item("NumAtCard").Editable = false;
            ogrd.Columns.Item("DocDate").Editable = false;
            ogrd.Columns.Item("DocTotal").Editable = false;
            ogrd.AutoResizeColumns();


        }

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.Grid Grid0;

        private void Grid0_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Grid ogrd = (SAPbouiCOM.Grid)ofrm.Items.Item("Item_0").Specific;  //ASSIGNA GIRD TO LOAD VALUES
            Global.strcol = "";
            Global.strcol = pVal.ColUID;
        

        }

        private SAPbouiCOM.Button Button0;

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("SR_CFSQ");
            SAPbouiCOM.Grid ogrd = (SAPbouiCOM.Grid)ofrm.Items.Item("Item_0").Specific;
            string strsqdocentry = "";
            //to get the select docentry need to create FOR loop
            for (int i = 0; i <= ogrd.Rows.Count - 1; i++)
            {

                //pass the condition to check the column is selected or not

                if (ogrd.DataTable.GetValue("SELECT", i).ToString() == "Y") //GET THE VALUE OF SELECT AS Y THEN IT SELECTED
                {
                    //('2','3')
                    if (strsqdocentry == "") // to form the selected docentry in a proper parameter format which supports to sql query. eg select * from table where col in('2','3','5')
                    {
                        strsqdocentry = "'" + ogrd.DataTable.GetValue("DOCENTRY", i).ToString() + "'";
                    }
                    else
                    {
                        strsqdocentry = strsqdocentry + ",'" + ogrd.DataTable.GetValue("DOCENTRY", i).ToString() + "'";
                    }
                }

            }
            string strqry = "SELECT T0.[ItemCode], T0.[Dscription], T0.[OpenQty], T0.[Price], T0.[OpenQty]*T0.[Price] AS TOTAL,WhsCode,T1.OnHand FROM QUT1 T0 left join OITM T1 ON T0.ItemCode=T1.ItemCode WHERE T0.[DocEntry] IN (" + strsqdocentry + ") ";
            //EXECUTION OF QUERY , DECLARE A RECORD SET
            SAPbobsCOM.Recordset ors = (SAPbobsCOM.Recordset)Global.ocomp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            ors.DoQuery(strqry); //WILL CALL THE RECORDSET AND TO PASS THE STRING WHERE DECLARED THE QUERY.

            //PARENT FORM/ MAIN SCREEN
            SAPbouiCOM.Form pform = Application.SBO_Application.Forms.Item("SR_OTRN"); // DEFINE A FORM
            SAPbouiCOM.Matrix omat = (SAPbouiCOM.Matrix)pform.Items.Item("Item_6").Specific;//define matrix
            SAPbouiCOM.DBDataSource oDBH = (SAPbouiCOM.DBDataSource)pform.DataSources.DBDataSources.Item("@SR_OTRN");   //DEFINE  DATASOURCES.1
            SAPbouiCOM.DBDataSource oDBL = (SAPbouiCOM.DBDataSource)pform.DataSources.DBDataSources.Item("@SR_TRN1");   //DEFINE  DATASOURCES.1
            //to pass the selected data, need to generate a FOR Loop.
            omat.FlushToDataSource(); // move the data from matrix to dbdatasource
            omat.Clear();// clear or remove from matrix
            oDBL.Clear(); // clear or remove from dbdatasource(in backend table)
            double dbltotal=0.0;
            for (int irow = 1; irow <= ors.RecordCount; irow++) //ToString load a data from record set to dbdatasource
            {
                oDBL.InsertRecord(irow - 1);
                oDBL.SetValue("LineId", irow - 1,irow.ToString());
                oDBL.SetValue("U_ItmCode", irow - 1, ors.Fields.Item("ItemCode").Value.ToString());
                oDBL.SetValue("U_Desc", irow - 1, ors.Fields.Item("Dscription").Value.ToString());
                oDBL.SetValue("U_Qty", irow - 1, ors.Fields.Item("OpenQty").Value.ToString());
                oDBL.SetValue("U_Prc", irow - 1, ors.Fields.Item("Price").Value.ToString());
                oDBL.SetValue("U_TotPrc", irow - 1, ors.Fields.Item("TOTAL").Value.ToString());
                oDBL.SetValue("U_Typ", irow - 1, ors.Fields.Item("WhsCode").Value.ToString());
                oDBL.SetValue("U_InStk", irow - 1, ors.Fields.Item("OnHand").Value.ToString());
                dbltotal = dbltotal + Convert.ToDouble(ors.Fields.Item("TOTAL").Value.ToString());
                //to move recordset
                ors.MoveNext();
            }
            omat.LoadFromDataSource();
            oDBH.SetValue("U_Total", 0, dbltotal.ToString());
            Application.SBO_Application.SetStatusBarMessage("Data imported successfully", SAPbouiCOM.BoMessageTime.bmt_Short, false);

            ofrm.Close();
        }
    }
}
