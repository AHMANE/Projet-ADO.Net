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
        }

            // Affichage des Clientss
             private  void AfficherClients()
            {
                IList<Client> ListeClients=GrandHotelApp.Instance.DAL.ObtenirClients();
                ConsoleTable.From(ListeClients).Display("Liste des clients");
            }

            // Affichage des Coordonnees
            private void CoordonnesClients()
            {
            int IdClient;
            IList<string> Coordonnees;
            AfficherClients();
            IdClient = Input.Read<int>("Saisissez l'id du client dont vous souhaitez voir les coordonnees :");
            Coordonnees = GrandHotelApp.Instance.DAL.ObtenirCoordonnees(IdClient);
            ConsoleTable.From(Coordonnees).Display("Coordonnees clients");

            //var Clients = GrandHotelApp.Instance.DAL.ObtenirClients();
            //ConsoleTable.From(ListeClients).Display("Liste des clients");


        }
    }
}
