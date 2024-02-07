using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2ApiRest.Models.EntityFramework;

namespace TP2ApiRestP2.ViewModels
{
    internal class SeriesDBViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private ObservableCollection<Serie> listeSeries;
        public ObservableCollection<Serie> ListeDevises
        {
            get { return listeSeries; }
            set
            {
                listeSeries = value;
                OnPropertyChanged();
            }
        }

    }
}
