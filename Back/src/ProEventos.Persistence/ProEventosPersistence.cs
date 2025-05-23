using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventoContext _context;
        public ProEventosPersistence(ProEventoContext _context)
        {
            this._context = _context;
            
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }



        public async Task<Evento[]> GetAllEventosByTemaAsync(string Tema, bool IncluirPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);

            if (IncluirPalestrantes)
            {
                query = query
                    .Include(e => e.EventoPalestrante)
                    .ThenInclude(ep => ep.Palestrante);
            }

            query = query.OrderBy(e => e.Tema)
                         .Where(e => e.Tema.ToLower().Contains(Tema.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetAllEventosAsync(bool IncluirPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);

            if (IncluirPalestrantes)
            {
                query = query
                    .Include(e => e.EventoPalestrante)
                    .ThenInclude(ep => ep.Palestrante);
            }

            query = query.OrderBy(e => e.Tema);

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetAllEventoByIdAsync(int EventoId, bool IncluirPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);

            if (IncluirPalestrantes)
            {
                query = query
                    .Include(e => e.EventoPalestrante)
                    .ThenInclude(ep => ep.Palestrante);
            }

            query = query.OrderBy(e => e.Tema)
                         .Where(e => e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }




        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool IncluirEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedeSociais);

            if (IncluirEventos)
            {
                query = query
                    .Include(p => p.EventoPalestrante)
                    .ThenInclude(ep => ep.Evento);
            }

            query = query.OrderBy(p => p.Nome)
                         .Where(p => p.Nome.ToLower().Contains(Nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool IncluirEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedeSociais);

            if (IncluirEventos)
            {
                query = query
                    .Include(p => p.EventoPalestrante)
                    .ThenInclude(ep => ep.Evento);
            }

            query = query.OrderBy(p => p.Nome);

            return await query.ToArrayAsync();
        }        
        public async Task<Palestrante> GetAllPalestranteByIdAsync(int PalestranteId, bool IncluirEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedeSociais);

            if (IncluirEventos)
            {
                query = query
                    .Include(p => p.EventoPalestrante)
                    .ThenInclude(ep => ep.Evento);
            }

            query = query.OrderBy(p => p.Nome)
                         .Where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}