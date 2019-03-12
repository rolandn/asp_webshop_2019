using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using webshop_2019.classesMetier;

namespace webshop_2019.model
{
    public class Ligne_CmdDAO:BaseDAO<Ligne_Cmd>
    {
        public Ligne_CmdDAO(SqlConnection sqlConn):base(sqlConn)
        {

        }

        public override bool Ajouter(Ligne_Cmd obj)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = "AjouterLigneCommande";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Connection = SqlConn;

                sqlCmd.Parameters.Add("@numCmd", SqlDbType.Int).Value = obj.NumCmd;
                sqlCmd.Parameters.Add("@numProduit", SqlDbType.VarChar).Value = obj.NumProduit;
                sqlCmd.Parameters.Add("@Qté", SqlDbType.VarChar).Value = obj.Qté;             
                sqlCmd.Parameters.Add("RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;

                return (sqlCmd.ExecuteNonQuery() == 0) ? false : true;
            }
            catch (Exception e)
            {
                throw new ExceptionDBAccess(e.Message);
            }            
        }

        public override Ligne_Cmd Charger(int num)
        {
            return null;
        }

        public override List<Ligne_Cmd> ListerTous()
        {
            return null;
        }

        public override bool Modifier(Ligne_Cmd obj)
        {
            return false;
        }

        public override bool Supprimer(int num)
        {
            return false;
        }
    }
}