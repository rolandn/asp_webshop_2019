﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.PresentationLayer
{
    public partial class PageMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LMsg.Text = (string)Session["message"];
        }
    }
}