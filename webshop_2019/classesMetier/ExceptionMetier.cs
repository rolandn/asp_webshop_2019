using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webshop_2019.classesMetier
{
    public class ExceptionMetier: Exception
    {
        public ExceptionMetier(string origine): base(origine)
        {

        }

    }
}