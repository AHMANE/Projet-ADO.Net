using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GrandHotel
{
   public class Entites 
    {
        [XmlInclude(typeof(Client))]
        public class Client
        {
            [Key]
            [XmlAttribute]
            public int Id { get; set; }
            [XmlAttribute]
            public string Civilite { get; set; }
            [XmlAttribute]
            public string Nom { get; set; }
            [XmlAttribute]
            public string Prenom { get; set; }
            [XmlAttribute]
            public bool CarteFidelite { get; set; }
            [XmlAttribute]
            public string Societe { get; set; }

            // Propriété de navigation
            [Display(ShortName = "None")]
            public virtual Adresse Adresse { get; set; }
            [Display(ShortName = "None")]
            [XmlIgnore]
            [XmlArray("Telephones")]
            [XmlArrayItem("Telephone")]
            public virtual List<Telephone> Telephones { get; set; }
            [Display(ShortName = "None")]
            [XmlIgnore]
            [XmlArray("Emails")]
            [XmlArrayItem("Email")]
            public virtual List<Email> Emails { get; set; }
            

        }
       
        public class Telephone
        {
            [XmlIgnore]
            [Key]
            [XmlAttribute]
            public string Numero {  get; set; }
            [ForeignKey("Client")]
            [XmlIgnore]
            public int IdClient { get; set; }
            [XmlIgnore]
            public string CodeType { get; set; }
            [XmlIgnore]
            public bool Pro { get; set; }
            // Propriété de navigation
            [Display(ShortName = "None")]
            public virtual Client Client { get; set; }
        }
        
        public class Adresse 
        {
            
            [Key]
            [ForeignKey("Client")]
            public int IdClient { get; set; }
            [XmlAttribute]
            public string Rue { get; set; }
            [XmlAttribute]
            public string Complement { get; set; }
            [XmlAttribute]
            public string CodePostal { get; set; }
            [XmlAttribute]
            public string Ville { get; set; }
            // Propriété de navigation
            public virtual Client Client { get; set; }
            public override string ToString()
            {
                return IdClient + "   " + Rue + "   " + Complement + "   " + CodePostal + "   " + Ville;
            }

        }
        public class Email
        {
            [Key]
            [XmlAttribute]
            public string Adresse { get; set; }
            [ForeignKey("Client")]
            [XmlIgnore]
            public int IdClient { get; set; }
            [XmlIgnore]
            public bool Pro { get; set; }
            // // Propriété de navigation
            public virtual Client Client { get; set; }
            public override string ToString()
            {
                return IdClient + "   " + Adresse + "   " + Pro;
            }
        }

    }
}
