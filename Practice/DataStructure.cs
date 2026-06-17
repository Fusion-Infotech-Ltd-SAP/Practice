using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class DataStructure
    {
        public void CreateUD()
        {
            Global.objFun.addField("@SR_OTRN", "CardName", "CardName", SAPbobsCOM.BoFieldTypes.db_Alpha, 254, SAPbobsCOM.BoFldSubTypes.st_None, "", "", "");
            SetupForm();
           // masterForm();
        }
        public void masterForm()
        {
            Global.objFun.CreateTable("SU_OMAT", "MASTER Table", SAPbobsCOM.BoUTBTableType.bott_MasterData);
            Global.objFun.addField("@SU_OMAT", "Desc", "Description", SAPbobsCOM.BoFieldTypes.db_Alpha, 254, SAPbobsCOM.BoFldSubTypes.st_None, "", "", "");
            Global.objFun.addField("@SU_OMAT", "PrcCode", "Project Code", SAPbobsCOM.BoFieldTypes.db_Alpha, 254, SAPbobsCOM.BoFldSubTypes.st_None, "", "", "");
        }
        public void master()
        {

            string[,] findField = new string[,] { { "Code", "Code" }, { "U_Desc", "U_Desc" } };  //after udo , by default it will show field based this<-
            //MASTER CATERGORY UDO,UDT AND UDF 
            Global.objFun.CreateTable("SSSU_OMAS", "MASTER Test", SAPbobsCOM.BoUTBTableType.bott_MasterData);
            //udf for master
            Global.objFun.addField("@SSSU_OMAS", "Desc", "Description", SAPbobsCOM.BoFieldTypes.db_Alpha, 254, SAPbobsCOM.BoFldSubTypes.st_None, "", "", "");
            Global.objFun.addField("@SSSU_OMAS", "GLCode", "GL Code", SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoFldSubTypes.st_None, "", "", "");
            Global.objFun.addField("@SSSU_OMAS", "Act", "Active", SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoFldSubTypes.st_None, "1,0", "Yes,No", "0");
            Global.objFun.addField("@SSSU_OMAS", "CombMF", "Combo method 1", SAPbobsCOM.BoFieldTypes.db_Alpha, 1, SAPbobsCOM.BoFldSubTypes.st_None, "", "", "");
            Global.objFun.addField("@SSSU_OMAS", "CombMS", "Combo method 2", SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoFldSubTypes.st_None, "T,S,M,O", "Tally,SAP,Microsoft,Oracle", "S");
            Global.objFun.addField("@SSSU_OMAS", "CombMT", "Combo method 3", SAPbobsCOM.BoFieldTypes.db_Alpha, 254, SAPbobsCOM.BoFldSubTypes.st_None, "", "", "");

            Global.objFun.registerUDO("SSSU_OMAS", "Master Test UDO", SAPbobsCOM.BoUDOObjType.boud_MasterData, findField, "@SSSU_OMAS", "", "", "", "", "", "", "", "", SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoYesNoEnum.tNO, SAPbobsCOM.BoYesNoEnum.tNO, "", "", 0);
        }
        public void SetupForm()
        {
            //table
            Global.objFun.CreateTable("SR_OOBJ", "Test Objective", SAPbobsCOM.BoUTBTableType.bott_NoObjectAutoIncrement);

            Global.objFun.addField("@SR_OOBJ", "SerName", "Server Name", SAPbobsCOM.BoFieldTypes.db_Alpha, 5, SAPbobsCOM.BoFldSubTypes.st_None, "", "", "");
            Global.objFun.addField("@SR_OOBJ", "SerPass", "Server Password", SAPbobsCOM.BoFieldTypes.db_Alpha, 50, SAPbobsCOM.BoFldSubTypes.st_None, "", "", "");
            Global.objFun.addField("@SR_OOBJ", "TriCont", "Trigger Count", SAPbobsCOM.BoFieldTypes.db_Numeric, 5, SAPbobsCOM.BoFldSubTypes.st_None, "", "", "");
        }
        //  Global.objFun.addField("@SSU_MAST", "CombMS", "Combo method 2", SAPbobsCOM.BoFieldTypes.db_Alpha, 10, SAPbobsCOM.BoFldSubTypes.st_None, "T,S,M,O", "Tally,SAP,Microsoft,Oracle", "S");

    }
}
