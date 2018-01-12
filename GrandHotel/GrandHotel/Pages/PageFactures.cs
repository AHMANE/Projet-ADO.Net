using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GrandHotel.Entites;

namespace GrandHotel.Pages
{
    public class PageFactures: MenuPage
    {
        //private Facture _facture;
        public PageFactures() : base("Gestion des factures")
        {
                 //Menu.AddOption("1", "Liste des factures d'un client sur 1 annéee", ()=> AfficherListe() );
        }

       // private void AfficherListe()
       // {
       //     int Id = Input.Read<int>("Veuillez saisir l'ID du client");
       //     DateTime DateFac= Input.Read<DateTime>("Veuillez saisir une date");
       //
       //     // Console.WriteLine(NumeroID);
       //    
       //    _facture = GrandHotelApp.Instance.DAL.Listefacture(DateFac, Id);
       //   //ConsoleTable.From(_facture).Display("ProductId");
       //     
       // }
    }
}
