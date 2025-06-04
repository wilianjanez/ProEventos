using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interfaces
{
    public interface IEventoPersistence
    {
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool incluirPalestrantes = false);
        Task<Evento> GetAllEventoByIdAsync(int eventoId, bool incluirPalestrantes = false);
    }
}