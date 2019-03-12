using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.BusinessLayer;
using WebApplication1.DBAL;

namespace WebApplication1.PresentationLayer
{
    public partial class PageCommande : System.Web.UI.Page
    {
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //List<Commande> liste = new List<Commande>();            
                int num = Convert.ToInt32(Session["user"]);
                List<Commande> liste = null;

                liste = ((FabriqueDAO)Session["FabriqueDAO"]).getInstCommandeDAO().chargerCmd(num);


                if (liste == null)
                {
                    new Tools().RedirigerMessage("Vous n'avez encore aucune commande");
                }
                else
                {
                    DataTable dt = CreateTableStructure();

                    DataRow row;
                    foreach (Commande c in liste)
                    {
                        row = dt.NewRow();
                        row["Commande #"] = c.IdCmd;
                        row["Date Commande"] = c.DateCmd;
                        row["Heure Commande"] = c.HeureCmd;
                        row["Montant Total"] = c.Montant;
                        row["Status Livraison"] = c.Livré;

                        dt.Rows.Add(row);
                    }
                    this.GridView1.DataSource = dt;
                    this.GridView1.DataBind();
                }
                
            }
            catch(ArgumentException arg)
            {
                new Tools().RedirigerErreurSQL("chargement du gridview", "Page_load()",
                arg.Message, "Problème de base de données lors du listage des commandes!");
            }
            catch(ExceptionMetier ex)
            {
                new Tools().RedirigerErreurSQL("ChargerCommande", "datarow()",
                ex.Message, "Problème pour générer le gridview!");
            }
            catch(Exception ex)
            {
                new Tools().RedirigerErreurSQL("ChargerCommande", "Page_load()",
                ex.Message, "Problème de base de données lors du listage des commandes!");
            }
           
        }
            // créer la structure du tableau
        private DataTable CreateTableStructure()
        {
            dt = new DataTable();

            dt.Columns.Add(CreateColumn("Commande #", System.Type.GetType("System.Int32")));
            dt.Columns.Add(CreateColumn("Date Commande", Type.GetType("System.String")));
            dt.Columns.Add(CreateColumn("Heure commande", Type.GetType("System.String")));
            dt.Columns.Add(CreateColumn("Montant Total", Type.GetType("System.Decimal")));
            dt.Columns.Add(CreateColumn("Status Livraison", Type.GetType("System.String")));

            return dt;
        }

        private DataColumn CreateColumn(string name, Type type)
        {
            DataColumn dc = new DataColumn();
            dc.ColumnName = name;
            dc.DataType = type;
            return dc;
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind(); // ou bindgridview will get the data source and bind it again
        }
        /*
        private void bindGridView()
        {


            throw new NotImplementedException();
        }*/
    }
    
}