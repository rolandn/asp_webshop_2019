using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webshop_2019.model
{
    public abstract class BaseDAO<T>
    {
        protected SqlConnection SqlConn = null;
        /**
        * Constructeur
        */
        public BaseDAO(SqlConnection sqlConn)
        {
            SqlConn = sqlConn;
        }
        /**
        * Méthodes abstraites
        */
        public abstract T Charger(int num);
        public abstract bool Ajouter(T obj);
        public abstract bool Modifier(T obj);
        public abstract bool Supprimer(int num);
        public abstract List<T> ListerTous();
    }
}
