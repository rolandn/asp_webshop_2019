using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webshop_2019.model
{
    public class ExceptionDBAccess: Exception
    {
        public ExceptionDBAccess(string msgDetail):base(msgDetail)
        {

        }

    }
}