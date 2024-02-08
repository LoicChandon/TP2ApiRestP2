using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TP2ApiRest.Models.EntityFramework
{
    public class Serie
    {
        private int serieId;

        public int SerieId
        {
            get { return serieId; }
            set { serieId = value; }
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

        public Serie() { }

        public Serie(int serieId, string titre, string resume, int nbSaisons, int nbEpisodes, int anneeCreation, string network)
        {
            SerieId = serieId;
            Titre = titre;
            Resume = resume;
            NbSaisons = nbSaisons;
            NbEpisodes = nbEpisodes;
            AnneeCreation = anneeCreation;
            Network = network;
        }

        public Serie(string titre, string resume, int nbSaisons, int nbEpisodes, int anneeCreation, string network)
        {
            this.titre = titre;
            this.resume = resume;
            this.nbSaisons = nbSaisons;
            this.nbEpisodes = nbEpisodes;
            this.anneeCreation = anneeCreation;
            this.network = network;
        }

        public override bool Equals(object? obj)
        {
            return obj is Serie serie &&
                   SerieId == serie.SerieId &&
                   Titre == serie.Titre &&
                   Resume == serie.Resume &&
                   NbSaisons == serie.NbSaisons &&
                   NbEpisodes == serie.NbEpisodes &&
                   AnneeCreation == serie.AnneeCreation &&
                   Network == serie.Network;
        }
    }
}
