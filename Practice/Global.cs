using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Global
    {
        //---> We can define a globally using variable's.
        public static SAPbobsCOM.Company ocomp; // Varible for company 
        public static int i;
        public static GlobalFunction objFun = new GlobalFunction();
        public static string strcol="";
        public static string GblStrCardcode = "";
        public static bool strpostkey = false;

    }
}
