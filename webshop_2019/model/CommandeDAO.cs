using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using webshop_2019.model;

namespace webshop_2019.model
{
    public class CommandeDAO: BaseDAO<Commande>
    {
        public CommandeDAO(SqlConnection sqlConn): base(sqlConn)
        {

        }

        public override bool Ajouter(Commande obj)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = "AjouterCommand";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Connection = SqlConn;

                sqlCmd.Parameters.Add("@id_Cmd", SqlDbType.Int).Value = obj.IdCmd;
                sqlCmd.Parameters.Add("@date_Cmd", SqlDbType.VarChar).Value = obj.DateCmd;
                sqlCmd.Parameters.Add("@heure_Cmd", SqlDbType.VarChar).Value = obj.HeureCmd;
                sqlCmd.Parameters.Add("@livraison_cmd", SqlDbType.VarChar).Value = obj.Livré;
                sqlCmd.Parameters.Add("@Montant_cmd", SqlDbType.Decimal).Value = obj.Montant;
                sqlCmd.Parameters.Add("@numClient", SqlDbType.Int).Value = obj.NumClient;
                sqlCmd.Parameters.Add("RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;

                return (sqlCmd.ExecuteNonQuery() == 0) ? false : true;
            }
            catch (Exception e)
            {
                throw new ExceptionDBAccess(e.Message);
            }           
        }

        public override Commande Charger(int num)
        {
            
            return null;
        }

        public override List<Commande> ListerTous()
        {
            return null;
        }

        public override bool Modifier(Commande obj)
        {
            return false;
        }

        public override bool Supprimer(int num)
        {
            return false;
        }
        public int GénérerCmdID()
        {
            try
            {
                int retVal = 0;
                SqlCommand sqlCmd = new SqlCommand();              
                sqlCmd.CommandText = "select max(id_cmd)+1 from Commande";              
                sqlCmd.Connection = SqlConn;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.Read())
                    retVal= Convert.ToInt32(reader[0]);
                reader.Close();

                return retVal;
            }
            catch(Exception ex)
            {
                throw new ExceptionDBAccess(ex.Message);
            }
        }

        public List<Commande> chargerCmd(int num)
        {
            List<Commande> liste= new List<Commande>();
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = "chargerCommande";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConn;
                sqlCmd.Parameters.Add("@num", SqlDbType.Int).Value = num;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while(reader.Read())
                    liste.Add(new Commande(Convert.ToInt32(reader["ID_cmd"]),
                                           Convert.ToString(reader["date_cmd"]),
                                           Convert.ToString(reader["heure_cmd"]),
                                           Convert.ToDecimal(reader["montant_cmd"]),
                                           Convert.ToString(reader["livraison_cmd"]),
                                           Convert.ToInt32(reader["numClient"])));
                                  
                reader.Close();
                
            }
            catch (Exception e)
            {
                throw new ExceptionDBAccess(e.Message);
            }
            return liste;
        }
    }

    


}