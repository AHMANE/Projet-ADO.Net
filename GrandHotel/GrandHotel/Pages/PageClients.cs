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
            Menu.AddOption("2", "Créer un nouveau Client ", CreationClient);
        }

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
            clien.CarteFidelite = Input.Read<bool>("Carte de fidilié (oui ou non) :");
            clien.Societe = Input.Read<string>("Société");

            Output.WriteLine(ConsoleColor.Green, "Saisissez Votre adresse :");
            adre.Rue = Input.Read<string>("Rue : ");
            adre.CodePostal = Input.Read<string>("Code Postale : ");
            adre.Ville = Input.Read<string>("Ville : ");


            GrandHotelApp.Instance.DAL.AjouterModifierProduit(clien, adre);
           

            Output.WriteLine(ConsoleColor.Green, "produit créer avec succés");
        }

        // Affichage des Clientss
        private  void AfficherClients()
            {
                IList<Client> ListeClients=GrandHotelApp.Instance.DAL.ObtenirClients();
                ConsoleTable.From(ListeClients).Display("Liste des clients");
            }

            // Affichage des Clientss
            private void CoordonnesClients()
            {
            AfficherClients();
            ConsoleTable.From(ListeClients).Display("Liste des clients");
            var Coords = GrandHotelApp.Instance.DAL.ObtenirClients();
            

            }
    }
}
