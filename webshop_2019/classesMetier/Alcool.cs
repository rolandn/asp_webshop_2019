using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webshop_2019.classesMetier
{
    public class Alcool
    {
        private int NumArticle;
        private string Gout;
        private float DegreAlcool;
        private string Provenance;
       

        public int NumArticle
        {
            get
            {
                return numArticle;
            }

            set { numArticle = value; }
        }

        public string Gout { get; set; }
    

        public float DegreAlcool
        {
            get
            {
                return degreAlcool;
            }

            set
            {
                degreAlcool = value;
            }
        }

        public string Provenance { get; set; }


        public Alcool(Alcool A)
        {
            NumArticle = A.NumArticle;
            Gout = A.Gout;
            DegreAlcool = A.DegreAlcool;
            Provenance = A.Provenance;
        }
        public Alcool(int numArticle, string gout, float degreAlcool, string provenance)
        {
            NumArticle = numArticle;
            Gout = gout;
            DegreAlcool = degreAlcool;
            Provenance = provenance;
        }



    }
}