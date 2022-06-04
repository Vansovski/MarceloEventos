using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;
using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Contratos;
using ProEventos.Persistence.Contexto;


namespace ProEventos.Persistence
{
    public class PalestrantesPersistence : IPalestrantesPersistence
    {
        //Injeção de dependecia do DbContext
        private readonly ProEventosContext _context;
        public PalestrantesPersistence(ProEventosContext context)
        {
            _context = context;
        }
        
        //Palestrante
        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEvento)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
                                            .Include(e => e.RedesSociais);
            if (includeEvento)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome));

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
           .Include(p => p.RedesSociais);

            if (includeEvento)
            {
                query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(e => e.Evento);
            }

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante> GetAllPalestranteByIdAsync(int palestranteId, bool includeEvento)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                            .Include(p => p.RedesSociais);
            if (includeEvento)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}