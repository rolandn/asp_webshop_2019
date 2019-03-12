using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webshop_2019.model;

namespace webshop_2019.webforms
{
    public partial class AspectBoutique : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            /**
            * méthode exécutée à chaque chargement d'une nouvelle page.
            * La fabrique d'objets DAO est créée si la session est utilisée ...
            * ... pour la 1re fois ou si elle a expiré
            */           
            try
            {
                if (Session["FabriqueDAO"] == null)
                {
                    Session["FabriqueDAO"] = new FabriqueDAO();
                    
                    Session.Timeout = 5;
                }          
            }
            catch (ExceptionDBAccess ex)
            {
                new Tools().RedirigerErreurConnSQL("AspectEcole", "Page_Init()", ex.Message);
            }
        }

    }
 }
