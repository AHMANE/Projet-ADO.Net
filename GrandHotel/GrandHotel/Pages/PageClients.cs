using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHotel.Pages
{
    public class PageClients : MenuPage
    {
        public PageClients() : base("Gestion des clients")
        {
            Menu.AddOption("1", "Liste des clients", AfficherClients);
        }

        private void AfficherClients()
        {
            throw new NotImplementedException();
        }
    }
}
