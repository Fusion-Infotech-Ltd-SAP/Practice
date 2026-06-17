using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Practice
{
    [FormAttribute("Practice.MasterForm", "MasterForm.b1f")]
    class MasterForm : UserFormBase
    {
        public MasterForm()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_14").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_6").Specific));
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

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.ComboBox ComboBox0;
    }
}
