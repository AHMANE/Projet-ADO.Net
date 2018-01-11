using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            [StringLength(4)]
            public string Civilite { get; set; }
            [StringLength(40)]
            public string Nom { get; set; }
            [StringLength(40)]
            public string Prenom { get; set; }
            public bool CarteFidelite { get; set; }
            [StringLength(100)]
            public string Societe { get; set; }

            public virtual Adresse Adresse { get; set; }
            public virtual List<Telephone> Telephone { get; set; }
            public virtual List<Email> Email { get; set; }
            

        }
        public class Telephone
        {
            [MaxLength(12)]
            public string Numero {  get; set; }
            [ForeignKey("Client")]
            public int IdClient { get; set; }
            [MaxLength(1)]
            public string CodeType { get; set; }
            public bool Pro { get; set; }
        }
         public class Adresse
        {
            [MaxLength(5)]
             public int IdClient { get; set; }
            [StringLength(40)]
            public string Rue { get; set; }
            [StringLength(40)]
            public string Complement { get; set; }
            [MaxLength(5)]
            public string CodePostal { get; set; }
            [StringLength(40)]
            public string Ville { get; set; }
        }
        public class Email
        {
            [StringLength(40)]
            public string Adresse { get; set; }
            [ForeignKey("Client")]
            public int IdClient { get; set; }
            public bool Pro { get; set; }
        }

    }
}
