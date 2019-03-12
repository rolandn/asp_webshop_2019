using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.BusinessLayer;
using WebApplication1.DBAL;
using System.Web.Security;


namespace WebApplication1.PresentationLayer
{
    public partial class PageInscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        /**
        * Méthode exécutée quand on clique sur le bouton Continuer ...
        * ... qui ajoute un élève dans la base de données
*/
        protected void BContinuer_Click(object sender, EventArgs e)
        {
            string hashedPass;  

            try
            {
                hashedPass = Tools.HashPassword(TBPassword.Text);

                Client client = new Client();
                client.Nom = TBNom.Text;
                client.Prenom = TBPrenom.Text;
                client.Adresse = TBAdresse.Text;
                client.Email = TBEmail.Text;
                client.Password = hashedPass;
                              
                ((FabriqueDAO)Session["FabriqueDAO"]).getInstClientDAO().Ajouter(client);

                new Tools().RedirigerMessage("Votre inscription est un succès!");
               
            }
            catch (ExceptionDBAccess ex)
            {
                new Tools().RedirigerErreurSQL("AjouterClient", "Bcontinuer_Click()",
                ex.Message,
                "Problème de base de données lors de l'ajout de client!");
            }
            catch (ExceptionMetier ex)
            {
                new Tools().RedirigerMessage(ex.Message);
            }
            catch (Exception ex)
            {
                new Tools().RedirigerErreurGen("AjouterClient", "Bcontinuer_Click()",
                ex.Message,
                "Problème inattendu lors de l'ajout du client!");
            }
        }
    }

}
