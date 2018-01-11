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
using System.Runtime.Serialization.Formatters.Soap;

namespace GrandHotel
{
    public class DAL : DbContext
    {
        private const string FICHIER_XML = @"..\..\listeSalle.xml";
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

        internal void EnregistrerModifsClients()
        {
            SaveChanges();
        }

        public IList<Client> ObtenirCoordonnees()
        {
            // List<Client> Coordonnees;
            //var Coordonnees = Clients.Where(s => s.Id == IdClient).FirstOrDefault();
            //var CP = CoordonneesClients.Adresses.CodePostal;
            //var Rue = CoordonneesClients.Adresses.Rue.ToString();
            //    .Include(a => a.Adresses)
            //    .Include(b => b.Telephones).ToList();
            ////.Include(c => c.Email)
            ////.Select(d => d.Rue).ToList();
            //IList<Client> Coordonnees;
            //return Coordonnees;

            return Clients.Include(a => a.Adresses).Include(b => b.Telephones).Include(c => c.Emails).ToList();
            
        }

        internal void SupprimerUnClient(int id)
        {
            Client CL = Clients.Find(id);
            if (CL != null)
            {
                Clients.Remove(CL);
            }
        }

        public void AjouterClient(Client clien, Adresse adre)
        {
            Clients.Add(clien);
            Adresses.Add(adre);
        }

        internal void AjouterNumeroMail(Client client, Telephone tel, Email eml)
        {
            Client clion = Clients.Find(client.Id);
            Telephone telephone = Telephones.Find(tel.Numero);
            Email email = Emails.Find(eml.Adresse);

            if(clion != null)
            {
                if(telephone == null)
                {
                    telephone.IdClient = tel.IdClient;
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

       
            public  void ExporterXml()
            {
           var liste = ObtenirClients();

            // On crée un sérialiseur, en spécifiant le type de l'objet à sérialiser
            // et le nom de l'élément xml racine
            FileStream flux = File.Create(FICHIER_XML);
            SoapFormatter serialiseur2 = new SoapFormatter();
            serialiseur2.Serialize(flux, liste);
            flux.Close();
        }

        
    }
        
 }
    

