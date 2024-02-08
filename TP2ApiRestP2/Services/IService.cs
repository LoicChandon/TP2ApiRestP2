using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2ApiRest.Models.EntityFramework;

namespace TP2ApiRestP2.Services
{
    internal interface IService
    {
        Task<List<Serie>> GetAll(string nomControleur);
        Task<bool> PutSerieAsync(string nomControleur);
        Task<bool> PostSerieAsync(string nomControleur, string titre, string resume, int nbSaisons, int nbEpisodes, int anneeCreation, string network);
        Task<bool> DeleteSerieAsync(int id);
        Task<Serie> GetSerieAsync(int id);
    }
}
