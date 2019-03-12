using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.BusinessLayer;

namespace webshop_2019.model
{
    public class BouteilleAListerDAO: BaseDAO<BouteilleALister>
    {
        public BouteilleAListerDAO(SqlConnection sqlConn):base(sqlConn)
        {

        }

        public override bool Ajouter(BouteilleALister obj)
        {
            throw new NotImplementedException();
        }

        public override BouteilleALister Charger(int num)
        {
            throw new NotImplementedException();
        }

        public override List<BouteilleALister> ListerTous()
        {
            List<BouteilleALister> liste = new List<BouteilleALister>();
            try
            {
                //liste = new List<BouteilleALister>();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select gout, degré_Alcool, provenance,nom_produit,image_produit,prixU, id_bouts, qtéstock  "+
                                    "from produit inner join BOUTEILLE on id_bouts=id_produit";
                cmd.Connection = SqlConn;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                        liste.Add(new BouteilleALister(
                        Convert.ToInt32(reader["id_bouts"]),
                        Convert.ToString(reader["gout"]),
                        Convert.ToDecimal(reader["degré_Alcool"]),
                        Convert.ToString(reader["nom_produit"]),
                        Convert.ToString(reader["Provenance"]),
                        Convert.ToString(reader["image_produit"]),
                        Convert.ToDecimal(reader["PrixU"]),
                        Convert.ToInt32(reader["QtéStock"])));
                reader.Close();
            }
            catch (Exception e)
            {
                throw new ExceptionDBAccess(e.Message);
            }

            return liste;
        }

        public override bool Modifier(BouteilleALister obj)
        {
            throw new NotImplementedException();
        }

        public override bool Supprimer(int num)
        {
            throw new NotImplementedException();
        }
    }
}