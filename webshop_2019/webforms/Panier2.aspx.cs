﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webshop_2019.classesMetier;
using webshop_2019.model;

namespace WebApplication1.PresentationLayer
{
    public partial class Panier2 : System.Web.UI.Page
    {
        DataTable dt;
        decimal prixTotal = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            try
            {
                List<Produit> liste = (List<Produit>)Session["Panier"];

                if (liste == null)
                {
                    new Tools().RedirigerMessage("Le panier est vide");
                }
                else
                {
                    // on charge la liste dans le Gdv +                       

                    //on crée la table et on y met les produits
                    DataTable dt = CreateTableStructure();

                    DataRow row;
                    foreach (Produit p in liste)
                    {
                        // on crée la row du tableau
                        row = dt.NewRow();
                        row["Produit #"] = p.ID_produit;
                        row["Nom Produit"] = p.Nom;
                        row["Qté"] = p.Quantité;
                        row["Prix Unitaire"] = p.PrixU;
                        row["Prix Total"] = p.Quantité * p.PrixU;

                        dt.Rows.Add(row);
                    }
                    this.GridView1.DataSource = dt;
                    this.GridView1.DataBind();

                    foreach (Produit p in liste)
                    {
                        prixTotal += p.Quantité * p.PrixU;
                    }
                    // afficher le prix dans le textBox
                    TBTotal.Text = Convert.ToString(prixTotal) + " €";

                }               

            }
            catch (ExceptionDBAccess ex)
            {
                new Tools().RedirigerErreurSQL("ChargerProduit", "Page_load()",
                ex.Message, "Problème de base de données lors du listage des alcools!");
            }
            catch (Exception ex)
            {
                new Tools().RedirigerErreurGen("ChargerProduit", "Page_load()",
                ex.Message,
                "Problème inattendu lors du chargement du panier!");
            }
        }
        // créer la structure du tableau
        private DataTable CreateTableStructure()
        {
            dt = new DataTable();

            dt.Columns.Add(CreateColumn("Produit #", System.Type.GetType("System.Int32")));
            dt.Columns.Add(CreateColumn("Nom Produit", Type.GetType("System.String")));
            dt.Columns.Add(CreateColumn("Qté", Type.GetType("System.Int32")));
            dt.Columns.Add(CreateColumn("Prix Unitaire", Type.GetType("System.Decimal")));
            dt.Columns.Add(CreateColumn("Prix Total", Type.GetType("System.Decimal")));

            return dt;
        }

        private DataColumn CreateColumn(string name, Type type)
        {
            DataColumn dc = new DataColumn();
            dc.ColumnName = name;
            dc.DataType = type;
            return dc;
        }


        protected void BCommander_Click(object sender, EventArgs e)
        {
            Client clt = new Client();

            // date et heure dans la commande
            DateTime date = new DateTime();
            date = DateTime.Now;
            String dateCmd = date.ToShortDateString();
            String hourCmd = date.ToShortTimeString();
            // état de livraison
            string livré = "Non";
            // num du client
            int numClt = (int)Session["user"];

            // on récupère le panier de la Session
            List<Produit> liste = new List<Produit>();
            liste = (List<Produit>)Session["Panier"];

            try
            {
                // on doit récupérer l'id du clt           
                clt = ((FabriqueDAO)Session["FabriqueDAO"]).getInstClientDAO().Charger(numClt);
                // générere un num de commande
                int idcmd = ((FabriqueDAO)Session["FabriqueDAO"]).getInstCommandeDAO().GénérerCmdID();

                foreach (Produit p in liste)
                {
                    prixTotal += p.Quantité * p.PrixU;
                }

                // on crée la commande et on envoie en DB
                Commande cmd = new Commande(idcmd, dateCmd, hourCmd, prixTotal, livré, numClt);
                if ((((FabriqueDAO)Session["FabriqueDAO"]).getInstCommandeDAO().Ajouter(cmd)) == false)
                    throw new Exception("problème lors de l'ajout de la commande");

                // on crée une ligne commande pour chaque produit
                foreach (Produit p in liste)
                {
                    Ligne_Cmd l_cmd = new Ligne_Cmd(idcmd, p.ID_produit, p.Quantité);
                    if ((((FabriqueDAO)Session["FabriqueDAO"]).getInstLigne_CmdDAO().Ajouter(l_cmd)) == false)
                        throw new Exception("problème lors de l'ajout de la ligne commande");
                    if ((((FabriqueDAO)Session["FabriqueDAO"]).getInstProduitDAO().ModifierStock(p, p.Quantité)) == false)
                        throw new Exception("problème lors d'ajustement du stock");
                }

                // on vide la variable session
                Session.Clear();
                // si tout va bien on revoit une page de confirmation
                new Tools().RedirigerMessage("Votre commande a bien été effectuée. En vous remerciant");
            }
            catch (ExceptionDBAccess ex)
            {
                new Tools().RedirigerErreurSQL("Problème de connexion", "Bcontinuer_Click()",
                ex.Message,
                "Problème de base de données lors du chargement de la commande!");
            }
            catch (Exception ex)
            {
                new Tools().RedirigerErreurGen("AjouterCommande", "Bcontinuer_Click()",
                ex.Message,
                "Problème inattendu lors de l'ajout de la commande!");
            }

        }
    }
}
