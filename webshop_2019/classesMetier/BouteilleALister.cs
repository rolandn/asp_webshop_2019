using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webshop_2019.classesMetier
{
    public class BouteilleALister
    {
        private int iDBout;
        private String gout;
        private decimal degréAlcool;
        private String provenance;
        private String nom;
        private String image;
        private decimal prixU;
        private int qtéStock;

        public BouteilleALister()
        {

        }
        public BouteilleALister(int iDBout, String gout, decimal degréAlcool, String provenance, String nom, String image,
         decimal prixU, int qtéStock)
        {
             IDBout = iDBout;
             Gout = gout;
             DegréAlcool = degréAlcool;
             Provenance = provenance;
             Nom = nom;
             Image = image;
             PrixU = prixU;
             QtéStock = qtéStock;
        }

       public int IDBout
        {
            get
            {
                return iDBout;
            }
            set
            {
                iDBout = value;
            }
        }

        public string Gout
        {
            get
            {
                return gout;
            }

            set
            {
                gout = value;
            }
        }

        public decimal DegréAlcool
        {
            get
            {
                return degréAlcool;
            }

            set
            {
                degréAlcool = value;
            }
        }

        public string Provenance
        {
            get
            {
                return provenance;
            }

            set
            {
                provenance = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public decimal PrixU
        {
            get
            {
                return prixU;
            }

            set
            {
                prixU = value;
            }
        }
        public int QtéStock { get; set; }
    }
}