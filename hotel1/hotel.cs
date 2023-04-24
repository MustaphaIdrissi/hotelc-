using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Contracts;

namespace hotel1
{
    internal class hotel
    {
        private int numero;
        private string nom;
        private string adresse;
        private int etoile;

        public hotel() { }

        public hotel(string nom, string adresse, int etoile) {
        
            this.nom = nom;
            this.adresse=adresse;
            this.etoile=etoile;
        
        
        }

        public int getNumero() { return numero; }
           public string getNom() { return nom; }
        public string getAdresse() { return adresse; }
        public int getEtoile() { return etoile; }
       


    }
}
