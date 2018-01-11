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

        internal void AjouterModifierProduit(Client clien, Adresse adre)
        {
            throw new NotImplementedException();
        }
    }
    }

