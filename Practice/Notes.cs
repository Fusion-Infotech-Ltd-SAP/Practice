using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Notes
    {
        //SAP b1 Addon concepts involve in the following:
        //1)Setup-Only one records and these inoformation will called in Master , transactions and also in reports.
        //2)Master- It is Essential records , it will multiple value of records. We will call these oinformation when make transaction. In combination of unique code can able prepare a report.
        //3)Transaction- To keep note on day to day enteries for finacial & stock management, we can call the master records as key information in transcation.
        //4) reports- To view a result of actives in finacial and stock management.

        //Setup-1 row of record
        //Design a screen
        //No objective:
        //Create No objective table and respective fields to it.
        //While click a menu to open need to validate that "If record exists - retrive a data from sql/hana db and pass the values to respective field. else if not exist- open blank screen.
        //While press a Add/Save/Update-"If record exists -update the value therefore maintain Code field as unique else if not exist- Inser a record. 
        //Objective Type:
        //Create UDT,UDF and UDO.
        //While click a menu to open a form "need to validate" that "If record exists -Make Form into Find mode / default open as FIND Mode , pass teh 1 value to field of Code or Docentry then press a button to "1", else NoT exist- open a blank screen in AddMode.
        //While press a Add/Update- No separate logic to Add or update , since it UDO by default it will Add or Update based on the form mode.

        //Master-Multiple records
        //Design a screen -Form Attribute or property-*object,default button, browse by,mode,uniqueid and type
        //Create a Table & UDo as Master supportive format:
        //in master Code as unique Docentry is not primary but it not allow the duplicates.
        //Browse by option , Docentry field
        //Validate a form.




    }
}
