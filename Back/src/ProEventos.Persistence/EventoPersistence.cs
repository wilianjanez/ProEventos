using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;
using ProEventos.Persistence.Contexts;

namespace ProEventos.Persistence
{
    public class EventoPersistence : IEventoPersistence
    {
        private readonly ProEventoContext _context;
        public EventoPersistence(ProEventoContext context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);

            if (incluirPalestrantes)
            {
                query = query
                    .Include(e => e.EventoPalestrante)
                    .ThenInclude(ep => ep.Palestrante);
            }

            query = query.AsNoTracking()
                         .OrderBy(e => e.Tema)
                         .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetAllEventosAsync(bool incluirPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);

            if (incluirPalestrantes)
            {
                query = query
                    .Include(e => e.EventoPalestrante)
                    .ThenInclude(ep => ep.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Tema);

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetAllEventoByIdAsync(int eventoId, bool incluirPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);

            if (incluirPalestrantes)
            {
                query = query
                    .Include(e => e.EventoPalestrante)
                    .ThenInclude(ep => ep.Palestrante);
            }

            query = query.AsNoTracking()
                         .OrderBy(e => e.Tema)
                         .Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }
   }
}