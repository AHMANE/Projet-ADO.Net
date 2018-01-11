﻿using System;
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
        public DAL() : base("GrandHotel.Properties.Settings.HotelConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public IList<Client> ObtenirClients()
        {


            //var listClients = new List<Client>();

            //var cmd = new SqlCommand();
            //cmd.CommandText = @"select * from Client";   

            //using (var cnx = new SqlConnection(HotelConnection))
            //{
            //    cmd.Connection = cnx;
            //    cnx.Open();

            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            var client = new Client();
            //            client.Id = (int)reader["Id"];
            //            client.Civilite = (string)reader["Civilite"];
            //            client.Nom = (string)reader["Nom"];
            //            client.Prenom = (string)reader["Prenom"];
            //            client.CarteFidelite = (bool)reader["CarteFidelite"];
            //            client.Societe = (string)reader["Societe"];
            //            listClients.Add(client);
            //        }
            //    }
        }

            
        }
    }
}
