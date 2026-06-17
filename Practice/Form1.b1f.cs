using System;
using System.Collections.Generic;
using System.Xml;
using SAPbouiCOM.Framework;

namespace Practice
{
    [FormAttribute("Practice.Form1", "Form1.b1f")]
    class Form1 : UserFormBase
    {
        public Form1()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.EditText0.KeyDownAfter += new SAPbouiCOM._IEditTextEvents_KeyDownAfterEventHandler(this.EditText0_KeyDownAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_5").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_6").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_7").Specific));
            this.Button1.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button1_PressedAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText EditText0;

        private void EditText0_KeyDownAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;

        private void Button1_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oFrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("SQLSET");
            oFrm.Close();

        }

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oFrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("SQLSET");

            SAPbouiCOM.EditText oedtusername, oedtpass;
            SAPbouiCOM.ComboBox ocmbtriger;
            //assign a field in defined object
            oedtusername = (SAPbouiCOM.EditText)oFrm.Items.Item("Item_1").Specific;
            oedtpass = (SAPbouiCOM.EditText)oFrm.Items.Item("Item_3").Specific;
            ocmbtriger = (SAPbouiCOM.ComboBox)oFrm.Items.Item("Item_5").Specific;
            //recordset
            string strcheck = "Select \"Code\",\"U_SerName\",\"U_SerPass\",\"U_TriCont\" from \"@SR_OOBJ\"";
            SAPbobsCOM.Recordset orsdata = (SAPbobsCOM.Recordset)Global.ocomp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            SAPbobsCOM.Recordset orsoper = (SAPbobsCOM.Recordset)Global.ocomp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            orsdata.DoQuery(strcheck);//execute a query in recordset
            //if data exist or not
            if(orsdata.RecordCount>0)
            {
                strcheck = "Update \"@SR_OOBJ\" set \"U_SerName\"='" + oedtusername.Value.ToString() + "',\"U_SerPass\"='" + oedtpass.Value.ToString() + "',\"U_TriCont\"='" + ocmbtriger.Selected.Value.ToString() + "' where \"Code\"='" + orsdata.Fields.Item("Code").Value.ToString() +"'";
                orsoper.DoQuery(strcheck);
                Application.SBO_Application.SetStatusBarMessage("Data updated successfully", SAPbouiCOM.BoMessageTime.bmt_Short, false);
            }
            else
            {
                string strins = "INSERT INTO [dbo].[@SR_OOBJ] ([Name] ,[U_SerName],[U_SerPass],[U_TriCont]) VALUES ('' ,'" + oedtusername.Value.ToString() + "' ,'" + oedtpass.Value.ToString() + "','"+ ocmbtriger.Selected.Value.ToString()+"')";
                orsoper.DoQuery(strins);
                Application.SBO_Application.SetStatusBarMessage("Data saved successfully", SAPbouiCOM.BoMessageTime.bmt_Short, false);
            }
        }
    }
}