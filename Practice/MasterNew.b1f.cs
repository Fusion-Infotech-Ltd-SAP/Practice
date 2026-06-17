using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Practice
{
    [FormAttribute("Practice.MasterNew", "MasterNew.b1f")]
    class MasterNew : UserFormBase
    {
        public MasterNew()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_2").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button0_ClickBefore);
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_6").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.DataAddBefore += new DataAddBeforeHandler(this.Form_DataAddBefore);

        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText2;

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

            SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FrmUOM");
        //    ofrm.Mode = SAPbouiCOM.BoFormMode.fm_ADD_MODE;
            if (ofrm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                SAPbouiCOM.DBDataSource ods = (SAPbouiCOM.DBDataSource)ofrm.DataSources.DBDataSources.Item("@HLB_OUOM");
                ods.SetValue("Code", 0, Global.objFun.GetCodeGeneration("[@HLB_OUOM]").ToString());


            }
            // throw new System.NotImplementedException();

            }

        private void Form_DataAddBefore(ref SAPbouiCOM.BusinessObjectInfo pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form ofrm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FrmUOM");
            if (ofrm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                SAPbouiCOM.DBDataSource ods = (SAPbouiCOM.DBDataSource)ofrm.DataSources.DBDataSources.Item("@HLB_OUOM");
                ods.SetValue("Code", 0, Global.objFun.GetCodeGeneration("[@HLB_OUOM]").ToString());
            }
                //  throw new System.NotImplementedException();

            }

        private void Button0_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
          //  throw new System.NotImplementedException();

        }
    }
}
