using GrandHotel.Pages;
using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHotel
{
    class Program
    {
        static void Main(string[] args)
        {
            GrandHotelApp app = GrandHotelApp.Instance;
            app.Title = "Bienvnue dans le Grand Hotel";

            // Ajout des pages
            MenuPage accueil = new PageAccueil();
            app.AddPage(accueil);
            app.AddPage(new PageClients());
            app.AddPage(new PageFactures());



            // Affichage de la page d'accueil .

            app.NavigateTo(accueil);

            // lancement de l'application
            app.Run();
        }
    }
}
