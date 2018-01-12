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
        private Client _client;
        private Adresse _adresse;
        private IList<Client> _listeDesClients;
        public PageClients() : base("Gestion des clients")
        {
            Menu.AddOption("1", "Liste des clients", AfficherClients);
            Menu.AddOption("2", "Coordonnées clients", CoordonnesClients);
            Menu.AddOption("3", "Créer un nouveau Client ", CreationClient);
            Menu.AddOption("4", "Ajouter un numéro de téléphone ou une adresse mail ", AjouterNuméroTelAdresseMailClient);
            Menu.AddOption("5", "Supprimer un client", SupprimerUnClient);
            Menu.AddOption("6", "Exporter la liste de clients sur un fichier XML", ExporterClients);
            Menu.AddOption("7", "Enregistrer", Enregistrer);

            _client = new Client();
            _adresse = new Adresse();

        }
        //**************************Exporter Clients en XML **************************//
        private void ExporterClients()
        {
            List<Client> liste = GrandHotelApp.Instance.DAL.ObtenirClientsXML();

            DAL.ExporterXml(liste);

            Output.WriteLine(ConsoleColor.Red, "Sérialisation réussie!");
        }

        //**************************Enregistrer les modifs  **************************//
      
        public void Enregistrer()
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

        //**************************Suprimer un client  **************************//
      
        private void SupprimerUnClient()
        {
            AfficherClients();
            int Id = Input.Read<int>("Entrer ID du client à supprimer :");
            GrandHotelApp.Instance.DAL.SupprimerUnClient(Id);
        }

        //**************************Ajouter Une Addresse mail  et un Mail **************************//
        private void AjouterNuméroTelAdresseMailClient()
        {
           int choix = 0;
             while (choix !=1 && choix !=2)
            {
                choix = Input.Read<int>("1 pour ajouter un N° Téléphone 2 pour Ajouter une adresse email:");
                if(choix == 1)
                {
                    Telephone tels = new Telephone();
                    AfficherClients();
                    int idVerif = Input.Read<int>("Id du client :");
                    tels.IdClient = GrandHotelApp.Instance.DAL.VérifierIDClient(idVerif);
                    bool NumeroOK = false;
                    do
                    {
                        tels.Numero = Input.Read<string>("Saisir le N° téléphone à ajouter :");
                        if (tels.Numero.Length < 13)
                        {
                            NumeroOK = true;
                        }
                        else
                        {
                            Console.WriteLine("");
                        }
                    }
                    while (!NumeroOK);
                    tels.CodeType = Input.Read<String>(" (F) pour fixe ou (M) pour mobile :");
                    tels.Pro = Input.Read<bool>(" Numéro personnel (false) ,  pro  (true) ");

                    GrandHotelApp.Instance.DAL.AjouterNumeroTelephone(tels);
                    
                }
                else if (choix == 2)
                {
                    AfficherClients();
                    Email emails = new Email();
                    emails.IdClient = Input.Read<int>("Id du client :");
                    emails.Adresse = Input.Read<String>("Saisir l'adresse email:");
                    emails.Pro = Input.Read<bool>("Saisir le Type de numéro : personnel: false ,  pro: true ");
                    GrandHotelApp.Instance.DAL.AjouterAddresseEmail(emails);

                    Output.WriteLine(ConsoleColor.Green, "Adresse mail ajouter avec succés");

                }

                Telephone tel = new Telephone();
            Email email = new Email();
 
            }
  
            
           
            
        }

        //**************************AJouter un Client**************************//
        private void CreationClient()
        {

            AfficherClients();

            int choix = Input.Read<int>("1 pour ajouter un client 2 pour Ajouter une adresse:");
            if (choix == 1)
            {
                bool civilite = false;
                while (!civilite)
                {
                    _client.Civilite = (Input.Read<string>("Choisissez la civilite: M, MME  ")).ToUpper();
                    civilite = _client.Civilite == "M" || _client.Civilite == " MME";

                }

                    _client.Nom = Input.Read<string>("Saississez le nom du client: ");

                    _client.Prenom = Input.Read<string>("Saissisez le prenom du client: ");

                _client.CarteFidelite = Input.Read<bool>("Le client a t-il une carte fidelité: tapez true pour oui et false pour non ");
                _client.Societe = Input.Read<string>("Saissisez le nom de la société du client: ");
                GrandHotelApp.Instance.DAL.AjoutClient(_client);
                Output.WriteLine(ConsoleColor.Green, "produit créer avec succés");
            }
           else if (choix == 2)
            {
                AfficherClients();
               

                _listeDesClients = GrandHotelApp.Instance.DAL.ObtenirClients();
                int idx = 0;
                bool IDvéficatio = false;
                while (!IDvéficatio)
                {

                    idx = Input.Read<int>("Id du client :");
                    IDvéficatio = _listeDesClients.Where(a => a.Id == idx).Any();
                }
                _adresse.IdClient = idx;

              
               
                    _adresse.Rue = Input.Read<string>("Saississez la rue: ");
                    //rue = GrandHotelApp.Instance.DAL.VerificationTaille(_adresse.Rue, 40);

                

                _adresse.Complement = Input.Read<string>("Saississez le complement d'adresse: ");

               
                    _adresse.CodePostal = Input.Read<string>("Saississez le code postal: ");
                    //codePostal = AppGrandHotel.Instance.Contexte.VerificationTaille(_adresse.CodePostal, 5);

                

                
                    _adresse.Ville = Input.Read<string>("Saississez la ville: ");
                   // ville = AppGrandHotel.Instance.Contexte.VerificationTaille(_adresse.Ville, 40);

                

                GrandHotelApp.Instance.DAL.AjoutAdresse(_adresse);
                Output.WriteLine(ConsoleColor.Green, " adresse créé avec succès ");


                
           
            }

            // Client clien = new Client();
            // Adresse adre = new Adresse();
            // Output.WriteLine(ConsoleColor.Green, "Saisissez les informations du client :");
            //
            //
            //// clien.Id = Input.Read<int>("Veuiller Saisir un ID Cleint : ");
            // clien.Civilite = Input.Read<string>("Civilité : ");
            // clien.Nom = Input.Read<string>("Nom : ");
            // clien.Prenom = Input.Read<string>("Prenom :");
            // clien.CarteFidelite = Input.Read<bool>("Carte de fidilié (True ou False) :");
            // clien.Societe = Input.Read<string>("Société");
            //
            // Output.WriteLine(ConsoleColor.Green, "Saisissez Votre adresse :");
            // adre.Rue = Input.Read<string>("Rue : ");
            // adre.CodePostal = Input.Read<string>("Code Postale : ");
            // adre.Ville = Input.Read<string>("Ville : ");
            //
            //
            // GrandHotelApp.Instance.DAL.AjouterClient(clien, adre);



        }
        
        //**************************Affichage des Clients**************************//
        
        private void AfficherClients()
            {
                IList<Client> ListeClients=GrandHotelApp.Instance.DAL.ObtenirClients();
                ConsoleTable.From(ListeClients).Display("Liste des clients");
            }
        
        //**************************Affichage des Coordonnees**************************//
       
        private void CoordonnesClients()
            {
    

            AfficherClients();
            

            int id = Input.Read<int>("Id du client :");



            var coordonneesClient = GrandHotelApp.Instance.DAL.ObtenirCoordonnees().Where(p => p.Id == id).FirstOrDefault();
            var adresse = _adresse;
            var telephones = coordonneesClient.Telephones;


            var emails = coordonneesClient.Emails.Select(e => e.Adresse);


            Console.WriteLine("Adresse: {0}", adresse.ToString());

            ConsoleTable.From(telephones, "Telephones").Display("Telephones");
            ConsoleTable.From(emails, "Emails").Display("Emails");


            //ConsoleTable.From(CP).Display("Code Postal:");

            //var Clients = GrandHotelApp.Instance.DAL.ObtenirClients();
            //ConsoleTable.From(ListeClients).Display("Liste des clients");
        }
    }
}
