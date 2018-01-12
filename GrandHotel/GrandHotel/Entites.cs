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
        [Serializable]

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

            public virtual Adresse Adresses { get; set; }
            [Display(ShortName = "None")]
            [XmlIgnore]

            public virtual List<Telephone> Telephones { get; set; }
            [Display(ShortName = "None")]
            [XmlIgnore]
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

       /*
        public class Facture
        {
            [Key]
            [XmlAttribute]
            public int Id { get; set; }
            [ForeignKey("Client")]
            [XmlAttribute]
            public int IdClient { get; set; }
            [XmlAttribute]
            public DateTime DateFacture { get; set; }
            [XmlIgnore]
            public DateTime DatePaiement { get; set; }
            [ForeignKey("ModePaiement")]
            [XmlIgnore]
            public string CodeModePaiement { get; set; }
            // // Propriété de navigation
            [XmlAttribute]
            public virtual Client Client { get; set; }
            [XmlIgnore]
            public virtual LigneFacture LigneFacture { get; set; }

        }

        public class LigneFacture
        {
            [Key]
            [ForeignKey("Facture")]
            public int IdFacture { get; set; }
            [Key]
            public int NumLigne { get; set; }
            public short Quantite { get; set; }
            public decimal MontantHT { get; set; }
            public decimal TauxTVA { get; set; }
            public decimal TauxReduction { get; set; }
        }

        public class ModePaiement
        {
            [Key]
            public string Code { get; set; }
            public string Libelle { get; set; }
        }
        */
   
    }
}
