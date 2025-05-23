using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence;
using ProEventos.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly ProEventoContext _context;
        public EventosController(ProEventoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos.Where(evento => evento.Ativo == true);
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return _context.Eventos.Where(evento => evento.Id == id);
        }        

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com {id}";
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
            var evento = await _context.Eventos.FirstOrDefaultAsync(e => e.Id == id);

            if (evento == null)
                return NotFound($"Evento não encontrado ({id})");

            evento.Ativo = false;
            await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("O evento foi alterado ou removido por outro processo.");
            }

            return Ok($"Evento deletado ({id})");
        }           
    }
}
