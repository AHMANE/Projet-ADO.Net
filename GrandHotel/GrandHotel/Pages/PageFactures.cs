using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHotel.Pages
{
    public class PageFactures: MenuPage
    {
        public PageFactures() : base("")
        {
            Menu.AddOption("1", "Liste des factures d'un client sur 1 annéee", FacturesAnnee);
        }
    }
}
