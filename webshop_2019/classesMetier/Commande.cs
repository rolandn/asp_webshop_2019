using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webshop_2019.classesMetier
{
    public class Commande
    {
        private int idCmd;
        private string dateCmd;
        private string heureCmd;
        private decimal montant;
        private string livré;
        private int numClient;

        public int IdCmd
        {
            get
            {
                return idCmd;
            }

            set
            {
                idCmd = value;
            }
        }

        public string DateCmd
        {
            get
            {
                return dateCmd;
            }

            set
            {
                dateCmd = value;
            }
        }

        public string HeureCmd
        {
            get
            {
                return heureCmd;
            }

            set
            {
                heureCmd = value;
            }
        }

        public decimal Montant
        {
            get
            {
                return montant;
            }

            set
            {
                montant = value;
            }
        }

        public string Livré
        {
            get
            {
                return livré;
            }

            set
            {
                livré = value;
            }
        }

        public int NumClient
        {
            get
            {
                return numClient;
            }

            set
            {
                numClient = value;
            }
        }

        public Commande()
        {

        }
        public Commande(Commande C)
        {
            IdCmd = C.IdCmd;
            DateCmd = C.DateCmd;
            HeureCmd = C.DateCmd;
            Montant = C.Montant;
            Livré = C.Livré;
            NumClient = C.NumClient;

        }
        public Commande(int idCmd, string dateCmd, string heureCmd, decimal montant, string livré, int numClient)
        {
            IdCmd = idCmd;
            DateCmd = dateCmd;
            HeureCmd = heureCmd;
            Montant = montant;
            Livré = livré;
            NumClient = numClient;
        }
        public Commande(int int1, string string1)
        {
            IdCmd = int1;
            DateCmd = string1;
           

        }
        public Commande(int int1, string livré, decimal montant)
        {
            IdCmd = int1;
            Livré = livré;
            Montant = montant;

        }

        public string toString()
        {
            { return "Commande # " + IdCmd; }
        }
    }
}