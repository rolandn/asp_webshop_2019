namespace webshop_2019.classesMetier
{
    public class Produit
    {
        private int iD_produit;
        private string nom;
        private string image;
        private decimal prixU;
        private int qte_stock;

        public int Quantité { get; set; } = 1;       

        public int ID_produit

        {
            get
            {
                return iD_produit;
            }

            set
            {
                iD_produit = value;
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

        public int Qte_stock
        {
            get
            {
                return qte_stock;
            }

            set
            {
                qte_stock = value;
            }
        }
        public string toString() { return ID_produit + ") " + Nom; }


        /*constru*/

        public Produit()
        {

        }

        public Produit(Produit prod)
        {
            ID_produit = prod.ID_produit;
            Nom = prod.Nom;
            Image = prod.Image;
            PrixU = prod.PrixU;
            Qte_stock = prod.Qte_stock;

        }
        public Produit(int id_produit, string nom, string image, decimal prixU, int qte_stock)
        {
            ID_produit = id_produit;
            Nom = nom;
            Image = image;
            PrixU = prixU;
            Qte_stock = qte_stock;
        }

        /**
         * Nécessaire pour lister dans comboBox
         * @param id_produit
         * @param nom
         * @param prixU
         * @param qte_stock
         */
        public Produit(int id_produit, string nom, decimal prixU, int qte_stock)
        {

            ID_produit = id_produit;
            Nom = nom;
            PrixU = prixU;
            Qte_stock = qte_stock;
        }

    }
    }
}