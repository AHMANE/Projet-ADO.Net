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


namespace GrandHotel
{
    public class DAL : DbContext
    {
        //private const string FICHIER_XML = @"S:\Velio\listeClient.xml";
        public DbSet<Entites.Client> Clients { get; set; }
        public DbSet<Entites.Adresse> Addresses { get; set; }
        public DbSet<Entites.Telephone> Telephones { get; set; }
        public DbSet<Entites.Email> Emails { get; set; }

        public DAL() : base("GrandHotel.Properties.Settings.HotelConnection")
        {
            // Permet d'identifier directement les entités définies dans la classe "Entités" sans créer de proxy.
            Configuration.ProxyCreationEnabled = false;///
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
        public  List<Entites.Client> ObtenirClients()
        {
            Clients.OrderBy(c => c.Id).Load();
            return Clients.Local.OrderBy(c => c.Id).ToList();

        }
        public List<Entites.Client> ChercherClientsxmL()
        {
            var ClTr = Clients.AsNoTracking().ToList();
            return ClTr;
                
            // Clients.AsNoTracking().OrderBy(c => c.Id).ToList();

        }
        public void EnregistrerModifsClients()
        {
            SaveChanges();
        }

        public IList<Entites.Client> ObtenirCoordonnees()
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

            return Clients.AsNoTracking().Include(a => a.Adresse).Include(b => b.Telephones).Include(c => c.Emails).ToList();
            
        }

        public void SupprimerUnClient(int id)
        {
            Entites.Client CL = Clients.Find(id);
            if (CL != null)
            {
                Clients.Remove(CL);
            }
        }

        public void AjouterClient(Entites.Client clien, Entites.Adresse adre)
        {
            Clients.Add(clien);
            Addresses.Add(adre);
        }

        public void AjouterNumeroMail(Entites.Client client, Entites.Telephone tel, Entites.Email email)
        {
            //Client clion = Clients.Find(client.Id);
            //Telephone telephone = Telephones.Find(tel.Numero);
            //Email email = Emails.Find(eml.Adresse);

            Entites.Telephone telephone = new Entites.Telephone();
            Entites.Email eml = new Entites.Email();

            //if(clion != null)
            //{
            //    if(telephone == null)
            //    {
            telephone.IdClient = tel.IdClient;
                    telephone.Numero = tel.Numero;
                    telephone.CodeType = tel.CodeType;
                    telephone.Pro = tel.Pro;
                    
                //}
                //if (email == null)
                //{
                    eml.Adresse = email.Adresse;
                    eml.Pro = email.Pro;
                //}
                Telephones.Add(telephone);
                Emails.Add(eml);
            }

        // Création d'un fichier XML contenant la liste des clients.


        //private Client client1= null;
        public static void ExporterXml(List<Entites.Client> ClTr)
        {
            //List<Client> liste = ObtenirClients();
           //Client client1 = new Client();
            
            //for (int i = 0; i <= Clients.Count(); i++)
            //{
                //foreach (var c in Clients)
                //{
                    //liste.Add(client1.Id);
                    //client1.Civilite = c.Civilite;
                    //client1.Nom = c.Nom;
                    //client1.Prenom = c.Prenom;
                    //client1.CarteFidelite = c.CarteFidelite;
                    //client1.Societe = c.Societe;

                    //client1.Id = c.Id;
                    //client1.Civilite = c.Civilite;
                    //client1.Nom = c.Nom;
                    //client1.Prenom = c.Prenom;
                    //client1.CarteFidelite = c.CarteFidelite;
                    //client1.Societe = c.Societe;
                //}

            //    client1 =liste.Add(new Client);

            //}
           

            // On crée un sérialiseur, en spécifiant le type de l'objet à sérialiser
            // et le nom de l'élément xml racine
            //FileStream flux = File.Create(FICHIER_XML);
            //SoapFormatter serialiseur2 = new SoapFormatter();
            //serialiseur2.Serialize(flux, liste);
            //flux.Close();

            // On crée un sérialiseur, en spécifiant le type de l'objet à sérialiser
            // et le nom de l'élément xml racine
            //FileStream flux = File.Create(FICHIER_XML);
            //SoapFormatter serialiseur2 = new SoapFormatter();
            //serialiseur2.Serialize(flux, liste);
            //flux.Close();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Entites.Client>),
                              new XmlRootAttribute("ListeClients"));

            using (var sw = new StreamWriter(@"S:\Velio\ListeClients.xml"))
            {
                serializer.Serialize(sw, ClTr);
            }

        }


    }
        
 }
    

