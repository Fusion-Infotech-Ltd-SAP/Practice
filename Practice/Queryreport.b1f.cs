using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice
{
    [FormAttribute("Practice.Queryreport", "Queryreport.b1f")]
    class Queryreport : UserFormBase
    {
        public Queryreport()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_0").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_1").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.Button1.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button1_PressedAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.Grid Grid0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;

        private void Button1_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form Frmreport = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item(pVal.FormUID);
            Frmreport.Close();
            //throw new System.NotImplementedException();

        }
    }
}
