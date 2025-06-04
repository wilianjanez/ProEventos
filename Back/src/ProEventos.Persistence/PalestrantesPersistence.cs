using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;
using ProEventos.Persistence.Contexts;

namespace ProEventos.Persistence
{
    public class PalestrantesPersistence : IPalestrantePersistence
    {
        private readonly ProEventoContext _context;
        public PalestrantesPersistence(ProEventoContext context)
        {
            _context = context;
            
        }
        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluirEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedeSociais);

            if (incluirEventos)
            {
                query = query
                    .Include(p => p.EventoPalestrante)
                    .ThenInclude(ep => ep.Evento);
            }

            query = query.AsNoTracking()
                         .OrderBy(p => p.Nome)
                         .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool incluirEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedeSociais);

            if (incluirEventos)
            {
                query = query
                    .Include(p => p.EventoPalestrante)
                    .ThenInclude(ep => ep.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Nome);

            return await query.ToArrayAsync();
        }        
        public async Task<Palestrante> GetAllPalestranteByIdAsync(int palestranteId, bool incluirEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedeSociais);

            if (incluirEventos)
            {
                query = query
                    .Include(p => p.EventoPalestrante)
                    .ThenInclude(ep => ep.Evento);
            }

            query = query.AsNoTracking()
                         .OrderBy(p => p.Nome)
                         .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}