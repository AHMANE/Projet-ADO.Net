using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GrandHotel.Entites;
using System.Xml.Serialization;
using System.IO;

namespace GrandHotel
{
    public class DAL : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<Email> Emails { get; set; }

        public DAL() : base("GrandHotel.Properties.Settings.HotelConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public  IList<Client> ObtenirClients()
        {
            Clients.OrderBy(c => c.Id).Load();
            return Clients.Local.OrderBy(c => c.Id).ToList();

        }

        public Client ObtenirCoordonnees(int idClient)
        {
            // List<Client> Coordonnees;
            var Coordonnees = Clients.Where(s => s.Id == idClient).FirstOrDefault();
            //var CP = CoordonneesClients.Adresses.CodePostal;
            //var Rue = CoordonneesClients.Adresses.Rue.ToString();
            //    .Include(a => a.Adresses)
            //    .Include(b => b.Telephones).ToList();
            ////.Include(c => c.Email)
            ////.Select(d => d.Rue).ToList();
            return Coordonnees;
        }

        public void AjouterClient(Client clien, Adresse adre)
        {
            Clients.Add(clien);
            Adresses.Add(adre);
        }

        internal void AjouterNumeroMail(Client client, Telephone tel, Email eml)
        {
            Client clion = Clients.Find(client.Id);
            Telephone telephone = Telephones.Find(tel.IdClient);
            Email email = Emails.Find(eml.IdClient);

            if(clion != null)
            {
                if(telephone == null)
                {
                    telephone.Numero = tel.Numero;
                    telephone.CodeType = tel.CodeType;
                    telephone.Pro = tel.Pro;
                    
                }
                if (email == null)
                {
                    email.Adresse = eml.Adresse;
                    email.Pro = eml.Pro;
                }
                
            }
        }

        // Création d'un fichier XML contenant la liste des clients.

        public static void ExporterXml(IList<Client> listCol)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Client>),
                                       new XmlRootAttribute("Clients"));

            using (var sw = new StreamWriter(@"..\..\Clients_XMLSerializer.xml"))
            {
                serializer.Serialize(sw, listCol);
            }
        }
    }
        
 }
    

