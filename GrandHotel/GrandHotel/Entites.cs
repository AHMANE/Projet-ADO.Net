using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHotel
{
   public class Entites
    {
        public class Client
        {
            [Key]
            public int Id { get; set; }
            
            public string Civilite { get; set; }
            
            public string Nom { get; set; }
           
            public string Prenom { get; set; }
            public bool CarteFidelite { get; set; }
           
            public string Societe { get; set; }
            
            // propriete de navigation
            [Display(ShortName = "None")]
            public virtual List<Adresse> Adresses { get; set; }
            [Display(ShortName = "None")]
            public virtual List<Telephone> Telephones { get; set; }
            [Display(ShortName = "None")]
            public virtual List<Email> Emails { get; set; }
            

        }
        public class Telephone
        {
            [Key]
            public string Numero {  get; set; }

            
           [ForeignKey("Client")]
            public int IdClient { get; set; }
            
            public string CodeType { get; set; }
            public bool Pro { get; set; }
            // propriete de navigation
            public virtual List<Client> Client { get; set; }
        }
         public class Adresse 
        {
            
            [Key]
            [ForeignKey("Client")]
            public int IdClient { get; set; }
          
            public string Rue { get; set; }
            
            public string Complement { get; set; }
         
            public string CodePostal { get; set; }
            
            public string Ville { get; set; }
            // propriete de navigation
            public virtual List<Client> Client { get; set; }

        }
        public class Email
        {
            [Key]
            public string Adresse { get; set; }
            
            [ForeignKey("Client")]
            public int IdClient { get; set; }
            public bool Pro { get; set; }
            // propriete de navigation
            public virtual List<Client> Client { get; set; }
        }

    }
}
