﻿using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandHotel.Pages
{
    class PageAccueil : MenuPage
    {
        public PageAccueil() : base("Accueil", false)
        {
            Menu.AddOption("a", "Quitter l'application",
                () => Environment.Exit(0));
            Menu.AddOption("1", "Gestion des clients",
             () => GrandHotelApp.Instance.NavigateTo(typeof(PageClients)));
            Menu.AddOption("2", "Gestion des factures",
             () => GrandHotelApp.Instance.NavigateTo(typeof(PageFactures)));
            // Menu.AddOption("3", "produits",
            //   () => Northwind2App.Instance.NavigateTo(typeof(PagesProduits)));
            //
            // Menu.AddOption("3", "produits",
            //   () => Northwind2App.Instance.NavigateTo(typeof(PagesProduits)));

        }
    }      
}
