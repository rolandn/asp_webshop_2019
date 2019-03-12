using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webshop_2019.classesMetier
{
    public class Ligne_Cmd
    {
        private int numCmd;
        private int numProduit;
        private int qté;

        public int NumCmd
        {
            get{return numCmd;}
            set{numCmd = value;}
        }
        public int NumProduit
        {
            get
            {
                return numProduit;
            }

            set
            {
                numProduit = value;
            }
        }
        public int Qté
        {
            get
            {
                return qté;
            }

            set
            {
                qté = value;
            }
        }

        /**
         * Constructeurs
         */
        public Ligne_Cmd()
        {

        }
        public Ligne_Cmd(Ligne_Cmd LC)
        {
            NumCmd = LC.NumCmd;
            NumProduit = LC.NumProduit;
            Qté = LC.Qté;

        }
        public Ligne_Cmd(int numCmd, int numProduit, int qté)
        {
            NumCmd = numCmd;
            NumProduit = numProduit;
            Qté = qté;
        }

        public String toString()
        {
            return this.NumCmd + " ) " + this.NumProduit + this.Qté;
        }

    }
}