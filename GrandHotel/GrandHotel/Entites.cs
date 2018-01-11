using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHotel
{
    class Entites
    {
        public class Client
        {
            public int Id { get; set; }
            public string Civilite { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public bool CarteFidelite { get; set; }
            public string Societe { get; set; }
        }
        public class Telephone
        {
            public string Numero {  get; set; }
            public int IdClient { get; set; }
            public string CodeType { get; set; }
            public bool Pro { get; set; }
        }
         public class Adresse
        {
            public int IdClient { get; set; }
            public string Rue { get; set; }
            public string Complement { get; set; }
            public string CodePostal { get; set; }
            public string Ville { get; set; }
        }
        public class Email
        {
            public string Adresse { get; set; }
            public int IdClient { get; set; }
            public bool Pro { get; set; }
        }

    }
}
