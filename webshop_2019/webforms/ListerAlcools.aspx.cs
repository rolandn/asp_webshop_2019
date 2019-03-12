using webshop_2019.classesMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webshop_2019.classesMetier;
using webshop_2019.model;

namespace webshop_2019.webforms
{
    public partial class ListerAlcools : System.Web.UI.Page
    {
        static string MotifHTML;
        /**
        * Constructeur statique. Il n'est exécuté qu'une seule fois. Il charge le motif HTML
*/
        static ListerAlcools()
        {
            MotifHTML = Tools.ChargerMotifHTML("motifBouteille.html");
        }
        /**
        * Méthode exécutée au chargement qui crée la page listant les professeurs*/

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("CPHContenu");

                List<BouteilleALister> liste = new List<BouteilleALister>();
                liste = ((FabriqueDAO)Session["FabriqueDAO"]).getInstBouteilleAListerDAO().ListerTous();
                if (liste.Count == 0)
                {
                    new Tools().RedirigerMessage(
                    "Il n'y a aucune bouteille dans la base de données!");
                    return;
                }
                while (liste.Count > 0)
                {
                    cph.Controls.Add(new LiteralControl(
                                string.Format(MotifHTML,
                                liste[0].Gout,          //0
                                liste[0].DegréAlcool,   //1
                                liste[0].Provenance,    //2    
                                liste[0].Nom,           //3
                                liste[0].Image,         //4
                                liste[0].PrixU,        //5
                                liste[0].IDBout,
                                liste[0].QtéStock)));

                                liste.RemoveAt(0);
                }

            }
            catch (ExceptionDBAccess ex)
            {
                new Tools().RedirigerErreurSQL("ListerAlcools", "Page_load()",
                ex.Message, "Problème de base de données lors du listage des alcools!");
            }
            catch (Exception ex)
            {
                new Tools().RedirigerErreurGen("ListerAlcool", "Page_load()",
                ex.Message,
                "Problème inattendu lors du listage des alcools!");
            }
        }
    }


}
    
