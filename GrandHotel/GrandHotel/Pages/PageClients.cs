using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GrandHotel.Entites;

namespace GrandHotel.Pages
{
    public class PageClients : MenuPage
    {
       

        public PageClients() : base("Gestion des clients")
        {
            Menu.AddOption("1", "Liste des clients", AfficherClients);
            Menu.AddOption("2", "Coordonnées clients", CoordonnesClients);
            Menu.AddOption("3", "Créer un nouveau Client ", CreationClient);
            Menu.AddOption("4", "Ajouter un numéro de téléphone ou une adresse mail ", AjouterNuméroTelAdresseMailClient);
            Menu.AddOption("5", "Supprimer un client", SupprimerUnClient);
            Menu.AddOption("6", "Exporter la liste de clients sur un fichier XML", ExporterClients);
            Menu.AddOption("7", "Enregistrer", Enregistrer);

        }

        private void ExporterClients()
        {
            
            GrandHotelApp.Instance.DAL.ExporterXml();
        }

        // Enregistrer les modifs
        private void Enregistrer()
        {
            try
            {
                GrandHotelApp.Instance.DAL.EnregistrerModifsClients();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception ra = dbEx;
                foreach (var valid in dbEx.EntityValidationErrors)
                {

                }


                throw ra;
            };
        }

        // Suprimer un client 
        private void SupprimerUnClient()
        {
            AfficherClients();
            int Id = Input.Read<int>("Entrer ID du client à supprimer :");
            GrandHotelApp.Instance.DAL.SupprimerUnClient(Id);
        }

        private void AjouterNuméroTelAdresseMailClient()
        {
            // Affiche la liste des clients 
          AfficherClients();

            // Récupère le cleint dont l'id a été saisi
            int id = Input.Read<int>("Id du Client à Ajouter son numéro de tel ou/et son adresse mail :");


            //Client client = _client.Where(x => x.Id == id).FirstOrDefault();
            Client client = new Client();
            Telephone tel = new Telephone();
            Email email = new Email();

            // Ajout de numero de tel
            Output.WriteLine(ConsoleColor.Cyan, "Saisir le numero de tel");
            tel.IdClient = Input.Read<int>("Id : ");
            tel.Numero = Input.Read<string>("Numéro : ");
            tel.CodeType = Input.Read<string>("Tapez M pour le numero mobile et F pour un numéro Fixe : ");
            tel.Pro = Input.Read<bool>("Professionnel Tapez true ou false");
            // Ajout de l'adresse mail 
            Output.WriteLine(ConsoleColor.Cyan, "Saisir adresse mail");
            email.Adresse = Input.Read<string>("Adresse mail : ");
            email.Pro = Input.Read<bool>("Professionnel Tapez true ou false");

       ;

            //Affiche Numero Client 
            GrandHotelApp.Instance.DAL.AjouterNumeroMail(client, tel, email);
            
            Output.WriteLine(ConsoleColor.Green, "Numero et mail ajouter  avec succés");
        }

        // Créer un client
        private void CreationClient()
        {
            AfficherClients();
            Client clien = new Client();
            Adresse adre = new Adresse();
            Output.WriteLine(ConsoleColor.Green, "Saisissez les informations du client :");


            clien.Id = Input.Read<int>("Veuiller Saisir un ID Cleint : ");
            clien.Civilite = Input.Read<string>("Civilité : ");
            clien.Nom = Input.Read<string>("Nom : ");
            clien.Prenom = Input.Read<string>("Prenom :");
            clien.CarteFidelite = Input.Read<bool>("Carte de fidilié (True ou False) :");
            clien.Societe = Input.Read<string>("Société");

            Output.WriteLine(ConsoleColor.Green, "Saisissez Votre adresse :");
            adre.Rue = Input.Read<string>("Rue : ");
            adre.CodePostal = Input.Read<string>("Code Postale : ");
            adre.Ville = Input.Read<string>("Ville : ");


            GrandHotelApp.Instance.DAL.AjouterClient(clien, adre);


            Output.WriteLine(ConsoleColor.Green, "produit créer avec succés");
        }

        // Affichage des Clients
        private  void AfficherClients()
            {
                IList<Client> ListeClients=GrandHotelApp.Instance.DAL.ObtenirClients();
                ConsoleTable.From(ListeClients).Display("Liste des clients");
            }

            // Affichage des Coordonnees//
        private void CoordonnesClients()
            {
            int IdClient;
            Client Coordonnees;
            AfficherClients();
            IdClient = Input.Read<int>("Saisissez l'id du client dont vous souhaitez voir les coordonnees :");
            Coordonnees = GrandHotelApp.Instance.DAL.ObtenirCoordonnees(IdClient);

            //var CoordonneesClients = Coordonnees.Where(s => s.Id == IdClient).FirstOrDefault();
            var CP = Coordonnees.Adresses.Select(c=> c.CodePostal);
            var Rue = Coordonnees.Adresses.Select(r => r.Rue);
            var Complement = Coordonnees.Adresses.Select(com => com.Complement);
            var Tels = Coordonnees.Telephones.Select(t => t.Numero);
            var Emails = Coordonnees.Emails.Select(em => em.Adresse);

            ConsoleTable.From(CP).Display("Code Postal:");

            //var Clients = GrandHotelApp.Instance.DAL.ObtenirClients();
            //ConsoleTable.From(ListeClients).Display("Liste des clients");
        }
    }
}
