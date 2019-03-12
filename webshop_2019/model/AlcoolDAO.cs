using BoutiqueExotique.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using webshop_2019.classesMetier;

namespace webshop_2019.model
{
    public class AlcoolDAO:BaseDAO<Alcool>
    {
        public AlcoolDAO(SqlConnection sqlConn):base(sqlConn)
        {

        }

        public override bool Ajouter(Alcool obj)
        {
            return false;
        }

        public override Bouteille Charger(int num)
        {
            return null;
        }

        public override List<Alcool> ListerTous()
        {
            return null;
        }

        public override bool Modifier(Alcool obj)
        {
            return false;
        }

        public override bool Supprimer(int num)
        {
            return false;
        }
    }
}