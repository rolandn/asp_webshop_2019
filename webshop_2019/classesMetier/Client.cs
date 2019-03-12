using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webshop_2019.classesMetier
{
    public class Client
    {
        private int numClient;      //iD_clt
        private string nom;
        private string prenom;
        private string adresse;
        private string email;
        private string password;

        // constructeur

        public Client()
        {

        }
        public Client(Client clt)
        {
            NumClient = clt.NumClient;
            Nom = clt.Nom;
            Prenom = clt.Prenom;
            Adresse = clt.Adresse;
            Email = clt.Email;
            Password = clt.Password;
        }

        public Client(int id_clt, string nom, string prenom, string adresse, string email,
        string password)
        {
            NumClient = numClient;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Email = email;
            Password = password;
        }
        public Client(int int1, string string1)
        {
            NumClient = int1;
            Nom = string1;
        }
        public Client(int ID,string email, string pass)
        {
            NumClient = ID;
            Email = email;
            Password = pass;
        }
        // propriété
        public int NumClient
        {
            get{return numClient; }
            set{ numClient = value;}
        }

        public string Nom
        {
            get { return nom; }
            set{nom = value;}
        }

        public string Prenom
        {
            get{return prenom;}

            set{prenom = value;}
        }

        public string Adresse
        {
            get{return adresse;}

            set{adresse = value;}
        }

        public string Email
        {
            get{return email;}

            set{email = value;}
        }

        public string Password
        {
            get{return password;}

            set{password = value;}
        }
        
        public string toString()
        {
            return NumClient + ")  " + Nom.ToString();
        }



    }
}