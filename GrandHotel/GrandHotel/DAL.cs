using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using static GrandHotel.Entites;
using System.Data;

namespace GrandHotel
{
    public class DAL : DbContext
    {
        private const string FICHIER_XML = @"..\..\listeClient.xml";
        //********************DBset==================//
        public DbSet<Client> Clients { get; set; }
        public DbSet<Adresse> Adresse { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<Email> Emails { get; set; }
        //public DbSet<Facture> Factures { get; set; }
        //********************DBset==================//

        public DAL() : base("GrandHotel.Properties.Settings.HotelConnection")
        {
            // Permet d'identifier directement les entités définies dans la classe "Entités" sans créer de proxy.
            Configuration.ProxyCreationEnabled = false;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public List<Client> ObtenirClientsXML()
        {
            var clt = Clients.AsNoTracking().ToList();
            return clt;
        }

        //**************************Afficher des clients  **************************//
        public List<Entites.Client> ObtenirClients()
        {
            Clients.OrderBy(c => c.Id).Load();
            return Clients.Local.OrderBy(c => c.Id).ToList();

        }

        //**************************Enregistrer les Modifs des Clients **************************//
        public void EnregistrerModifsClients()
        {
            SaveChanges();
        }
        //**************************Obtenir des coordonnées **************************//
        public IList<Entites.Client> ObtenirCoordonnees()
        {


            Clients.Include(a => a.Adresses).Include(b => b.Telephones).Include(c => c.Emails).Load();
            return Clients.Include(a => a.Adresses).Include(b => b.Telephones).Include(c => c.Emails).ToList();
        }
        //**************************Supprimer un client donnée **************************//
        public void SupprimerUnClient(int id)
        {
            Entites.Client CL = Clients.Find(id);
            if (CL != null)
            {
                Clients.Remove(CL);
            }
        }

        //**************************Virification des id clients **************************//
        public int VérifierIDClient(int idVerif)
        {
            bool idExiste = false;

            do
            {
                if (Clients.Any(o => o.Id == idVerif))
                {
                    idExiste = true;
                    return idVerif;
                }
                else
                {
                    Console.WriteLine("Id n'existe pas");
                }
            }
            while (!idExiste);
            return -1;
        }

        //**************************Ajouter Addresse Email **************************//
        public void AjouterAddresseEmail(Email emails)
        {
            Emails.Add(emails);
        }
        //**************************Ajouter Numero Telephone **************************//
        public void AjouterNumeroTelephone(Telephone tels)
        {
            Telephones.Add(tels);
        }


        //**************************Serialiser la liste des client dans fichier Xml **************************//
        public static void ExporterXml(List<Entites.Client> ClTr)
        {
 

            XmlSerializer serializer = new XmlSerializer(typeof(List<Entites.Client>),
                              new XmlRootAttribute("ListeClients"));

            using (var sw = new StreamWriter(FICHIER_XML))
            {
                serializer.Serialize(sw, ClTr);
            }

        }


        //**************************Ajouter Client **************************//
        public void AjoutClient(Entites.Client client)
        {
            Clients.Add(client);
        }
        //**************************Ajouter Une addresse **************************//
        public void AjoutAdresse(Adresse adresse)
        {
            Adresse.Add(adresse);
        }


        //************************************************************Gestion des factures*******************************************************//

       
        }

    }


    

