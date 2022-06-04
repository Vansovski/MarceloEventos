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
    public class EventosPersistence : IEventosPersistence
    {
        //Injeção de dependecia do DbContext
        private readonly ProEventosContext _context;
        public EventosPersistence(ProEventosContext context)
        {
            _context = context;
            //Descarta o Track de toda aplicação 
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        //Eventos
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante)
        {
            IQueryable<Evento> query = _context.Eventos
                                            .Include(e => e.Lotes)
                                            .Include(e => e.RedesSociais);

            if (includePalestrante)
            {
                query = query
                            .Include(e => e.PalestrantesEventos)
                            .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                            .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                            .Include(e => e.Lotes)
                                            .Include(e => e.RedesSociais);

            if (includePalestrante)
            {
                query = query
                            .Include(e => e.PalestrantesEventos)
                            .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrante)
        {
            IQueryable<Evento> query = _context.Eventos
                                            .Include(e => e.Lotes)
                                            .Include(e => e.RedesSociais);
            if (includePalestrante)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}