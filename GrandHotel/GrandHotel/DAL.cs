using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GrandHotel.Entites;

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

        public IList<Client> ObtenirCoordonnees()
        {
            // Recuprer id de client avec la 
          return Clients.Include(c => c.Telephones)
                .Include(x => x.Emails)
                .Include(w => w.Adresses).ToList();
            
        }

        internal int EnregistrerModifsClients()
        {
            return SaveChanges();
        }

        internal void SupprimerUnClient(int id)
        {
            Client cl = Clients.Find(id);

            if (cl != null)
            {
                Clients.Remove(cl);
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
    }
        
 }
    

