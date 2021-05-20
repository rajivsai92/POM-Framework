using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Utilities
{
    public class ExceptionHandler
    {

        public static string ReturnExceptionMessage(string pagename, string methodname, Exception ex)
        {

            if(ex.InnerException==null)
            {
                return "At " + pagename + ".cs--> " + methodname + " method <br> ExceptionMSG:" + ex.Message;

            }
            else
            {
                return "At " + pagename + ".cs--> " + methodname + " method <br> Inner Exception :" + ex.InnerException + "<br> ExceptionMSG:" + ex.Message;

            }
        }
    }
}
