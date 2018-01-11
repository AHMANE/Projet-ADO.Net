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

            // Ajout de page
            MenuPage accueil = new PageAccueil();
            app.AddPage(accueil);
            app.AddPage(new PageClients());




            // Afficher 
            app.NavigateTo(accueil);
            app.Run();
        }
    }
}
