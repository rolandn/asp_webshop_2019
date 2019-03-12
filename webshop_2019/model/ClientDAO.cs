using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using webshop_2019.classesMetier;

namespace webshop_2019.model
{
    public class ClientDAO:BaseDAO<Client>
    {
        public ClientDAO(SqlConnection sqlConn):base(sqlConn)
        {
            
        }
        

        public override bool Ajouter(Client obj)
        {
        try
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "AjouterClient";
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Connection = SqlConn;

            sqlCmd.Parameters.Add("@NumClient", SqlDbType.Int).Value = obj.ID_clt;
            sqlCmd.Parameters.Add("@Nom", SqlDbType.VarChar).Value = obj.Nom;
            sqlCmd.Parameters.Add("@Prenom", SqlDbType.VarChar).Value = obj.Prenom;
            sqlCmd.Parameters.Add("@adresse", SqlDbType.VarChar).Value = obj.Adresse;
            sqlCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = obj.Email;
            sqlCmd.Parameters.Add("@password", SqlDbType.VarChar).Value = obj.Password;
            sqlCmd.Parameters.Add("RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;

            return (sqlCmd.ExecuteNonQuery() == 0) ? false : true;
        }
        catch (Exception e)
        {
            throw new ExceptionDBAccess(e.Message);
        }

    }

        public override Client Charger(int num)
        {
            Client clt = null;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = "chargerClient";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = SqlConn;
                sqlCmd.Parameters.Add("@numClt", SqlDbType.Int).Value = num;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.Read())

                    clt = new Client(Convert.ToInt32(reader["ID_clt"]),
                                     Convert.ToString(reader["nom_clt"]),
                                     Convert.ToString(reader["prenom_clt"]),
                                     Convert.ToString(reader["adress_clt"]),                                   
                                    Convert.ToString(reader["email_clt"]),
                                    Convert.ToString(reader["password_clt"]));
                reader.Close();                      
            }
            catch (Exception e)
            {
                throw new ExceptionDBAccess(e.Message);
            }
            return clt;
        }

        public override List<Client> ListerTous()
        {
            return null;
        }

        public override bool Modifier(Client obj)
        {
            return false;
        }

        public override bool Supprimer(int num)
        {
            return false;
        }

        public Client FindClient(string email)
        {
            Client clt = null;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = "FindClient";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Connection = SqlConn;
                sqlCmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.Read())

                    clt = new Client(Convert.ToInt32(reader["ID_clt"]),
                                     Convert.ToString(reader["email_clt"]),
                                     Convert.ToString(reader["password_clt"]));

                reader.Close();
              
            }
            catch (Exception e)
            {
                throw new ExceptionDBAccess(e.Message);
            }

            return clt;
        }
    }
}