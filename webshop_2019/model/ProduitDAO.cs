using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.BusinessLayer;

namespace webshop_2019.model
{
    public class ProduitDAO:BaseDAO<Produit>
    {
        public ProduitDAO(SqlConnection sqlConn):base(sqlConn)
        {

        }

        public override bool Ajouter(Produit obj)
        {
            return false;
        }

        public override Produit Charger(int num)
        {
            Produit prod = null;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = "chargerProduit";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Connection = SqlConn;
                sqlCmd.Parameters.Add("@numProduit", SqlDbType.Int).Value = num;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.Read())

                    prod = new Produit(Convert.ToInt32(reader["ID_produit"]),
                                    Convert.ToString(reader["nom_produit"]),
                                    Convert.ToString(reader["image_produit"]),
                                    Convert.ToDecimal(reader["prixU"]),
                                    Convert.ToInt32(reader["QtéStock"]));
                reader.Close();

            }
            catch(Exception e)
            {
                throw new ExceptionDBAccess(e.Message);
            }
            return prod;

        }

        public override List<Produit> ListerTous()
        {
            return null;
        }
        public override bool Modifier(Produit obj)
        {
            return false;
        }

        /*
         * modifier la quantité en stock du produit
         * */
        public bool ModifierStock(Produit obj, int qté)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "ajusterStock";
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Connection = SqlConn;

            sqlCmd.Parameters.Add("@numProduit", SqlDbType.Int).Value = obj.ID_produit;
            sqlCmd.Parameters.Add("@qtéStock", SqlDbType.Int).Value = qté;
            sqlCmd.Parameters.Add("RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;

            return (sqlCmd.ExecuteNonQuery() == 0) ? false : true;
        }

        public override bool Supprimer(int num)
        {
            return false;
        }
    }

}