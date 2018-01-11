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
        public DbSet<Adresse> Addresses { get; set; }
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

        public IList<Client> ObtenirCoordonnees(int idClient)
        {
            return Clients.Where(s => s.Id == idClient)
                .Include(a => a.Adresses.Rue)
                .Include(b => b.Adresses.Complement)
                .Include(c => c.Adresses.CodePostal)
                .Include(d => d.Adresses.Ville).ToList();

        }

        public void AjouterClient(Client clien, Adresse adre)
        {
            Clients.Add(clien);
            Addresses.Add(adre);
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
    }
        
 }
    

