using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2ApiRest.Models.EntityFramework;
using TP2ApiRestP2.Services;

namespace TP2ApiRestP2.ViewModels
{
    internal class SeriesDBViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private ObservableCollection<Serie> listeSeries;
        public ObservableCollection<Serie> ListeSeries
        {
            get { return listeSeries; }
            set
            {
                listeSeries = value;
                OnPropertyChanged();
            }
        }
        private string titre;
        public string Titre
        {
            get { return titre; }
            set { titre = value; }
        }
        private string resume;

        public string Resume
        {
            get { return resume; }
            set { resume = value; }
        }

        private int nbSaisons;

        public int NbSaisons
        {
            get { return nbSaisons; }
            set { nbSaisons = value; }
        }
        private int nbEpisodes;

        public int NbEpisodes
        {
            get { return nbEpisodes; }
            set { nbEpisodes = value; }
        }
        private int anneeCreation;

        public int AnneeCreation
        {
            get { return anneeCreation; }
            set { anneeCreation = value; }
        }
        private string network;

        public string Network
        {
            get { return network; }
            set { network = value; }
        }


        public IRelayCommand BtAjouter { get; }
        public SeriesDBViewModel()
        {
            GetDataLoadAsync();
            //Boutons
            BtAjouter = new RelayCommand(ActionAjouterSerie);
        }
        private async void GetDataLoadAsync()
        {
            WSService service = new WSService("https://apiserieschaloi.azurewebsites.net/api/");
            List<Serie> result = await service.GetAll("series");
            if (result == null)
            {
                MessageAsync("API indisponible", "Relance l'API chakal");
            }
            else
                ListeSeries = new ObservableCollection<Serie>(result);
        }

        private async void MessageAsync(string titre, string content)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = titre,
                Content = content,
                CloseButtonText = "Ok"
            };
            contentDialog.XamlRoot = App.MainRoot.XamlRoot;

            ContentDialogResult result = await contentDialog.ShowAsync();
        }
        private async void ActionAjouterSerie()
        {
            WSService service = new WSService("https://apiserieschaloi.azurewebsites.net/api/");
            bool result = await service.PostSerieAsync("series",Titre,Resume,NbSaisons,NbEpisodes,AnneeCreation,Network);
            if (!result)
            {
                MessageAsync("Erreur", "Erreur lors de l'insertion des valeurs");
            }
            else
                MessageAsync("Réussite", "La série a bien été insérée");
        }
    }
}