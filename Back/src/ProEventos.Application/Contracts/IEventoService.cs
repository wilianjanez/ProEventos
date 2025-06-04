using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contracts
{
    public interface IEventoService
    {
        Task<Evento> AddEvento(Evento model);
        Task<Evento> UpdateEvento(int eventoId, Evento model);
        Task<bool> DeleteEvento(int eventoId);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool incluirPalestrantes = false);
        Task<Evento> GetAllEventoByIdAsync(int eventoId, bool incluirPalestrantes = false);
    }
}