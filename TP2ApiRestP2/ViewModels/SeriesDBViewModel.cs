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
        private Serie serieToAdd;
        
        public Serie SerieToAdd
        {
            get { return serieToAdd; }
            set { serieToAdd = value; OnPropertyChanged(); }
        }
        private int idRecherche;

        public int IdRecherche
        {
            get { return idRecherche; }
            set { idRecherche = value; OnPropertyChanged(); }
        }



        public IRelayCommand BtAjouter { get; }
        public IRelayCommand BtRechercher { get; }
        public IRelayCommand BtModifier { get; }
        public IRelayCommand BtSupprimer { get; }
        public SeriesDBViewModel()
        {
            GetDataLoadAsync();
            //Boutons
            BtAjouter = new RelayCommand(ActionAjouterSerie);
            BtRechercher = new RelayCommand(ActionRechercherSerie);
            BtModifier = new RelayCommand(ActionModifierSerie);
            BtSupprimer = new RelayCommand(ActionSupprimerSerie);

            SerieToAdd = new Serie();
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
            bool result = await service.PostSerieAsync("series",SerieToAdd);
            SerieToAdd.SerieId = 0;
            if (!result)
            {
                MessageAsync("Erreur", "Erreur lors de l'insertion des valeurs, veuillez remplir tous les champs.");
            }
            else
                MessageAsync("Réussite", "La série a bien été insérée");
        }
        private async void ActionRechercherSerie()
        {
            WSService service = new WSService("https://apiserieschaloi.azurewebsites.net/api/");
            Serie serieAAfficher = await service.GetSerieAsync("series",IdRecherche);
            if (serieAAfficher == null)
            {
                MessageAsync("Erreur", "Erreur lors de la recherche");
            }
            else
                SerieToAdd = serieAAfficher;
        }
        private async void ActionModifierSerie()
        {
            WSService service = new WSService("https://apiserieschaloi.azurewebsites.net/api/");
            bool result = await service.PutSerieAsync("series",serieToAdd);
            if (!result)
            {
                MessageAsync("Erreur", "Erreur lors de la modification des valeurs, veuillez remplir tous les champs.");
            }
            else
                MessageAsync("Réussite", "La série a bien été modifée");
        }
        private async void ActionSupprimerSerie()
        {
            WSService service = new WSService("https://apiserieschaloi.azurewebsites.net/api/");
            bool result = await service.DeleteSerieAsync("series", IdRecherche);
            if (!result)
            { 
                MessageAsync("Erreur", "Erreur lors de la suppression des valeurs");
            }
            else
                MessageAsync("Réussite", "La série a bien été supprimée");
        }
    }
}