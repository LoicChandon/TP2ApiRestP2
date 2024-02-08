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
        Task<bool> PostSerieAsync(string nomControleur, Serie serieToAdd);
        Task<bool> DeleteSerieAsync(string nomControleur);
        Task<Serie> GetSerieAsync(string nomControleur,int id);
    }
}
