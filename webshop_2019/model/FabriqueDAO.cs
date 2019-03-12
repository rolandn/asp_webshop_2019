using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webshop_2019.model
{
    public class FabriqueDAO
    {
        private SqlConnection Conn = null;

        public FabriqueDAO()
        {
            createConnection();
        }

        public void createConnection()
        {
		    try
            {
                if(Conn==null)
                {
                    Conn = new SqlConnection("Integrated security=true;" +
                                "user id=Denis;" +
                                "password=zob;" +
                                "Data Source=DENIS-LP;" +
                                "Initial Catalog=exotic_shop;");
                    Conn.Open();
                }          
            }
		    catch(Exception e)

            {
                throw new ExceptionDBAccess(e.Message);

            }
        }

        /**
         * methode qui fournit l'instance des classes métierDAO
         * @return
         */
        public AlcoolDAO getInstBouteilleDAO()
        {
            return new AlcoolDAO(Conn);
        }
        public ClientDAO getInstClientDAO()
        {
            return new ClientDAO(Conn);
        }
        
        public CommandeDAO getInstCommandeDAO()
        {
            return new CommandeDAO(Conn);
        }
        public ProduitDAO getInstProduitDAO()
        {
            return new ProduitDAO(Conn);
        }
        public Ligne_CmdDAO getInstLigne_CmdDAO()
        {
            return new Ligne_CmdDAO(Conn);
        }
        public BouteilleAListerDAO getInstBouteilleAListerDAO()
        {
            return new BouteilleAListerDAO(Conn);
        }
        
    }
}