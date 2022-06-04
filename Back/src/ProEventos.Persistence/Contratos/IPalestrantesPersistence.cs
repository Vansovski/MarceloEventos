using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantesPersistence
    {
        //Palestrante
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEvento);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEvento);
        Task<Palestrante> GetAllPalestranteByIdAsync(int palestranteId, bool includeEvento);
    }
}