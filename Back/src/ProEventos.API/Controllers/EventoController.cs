using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private IEnumerable<Evento> _eventos = new Evento[] {
            new Evento()
            {
                Id = Guid.Parse("d08c7045-6af6-415a-b53e-5f26cf03ee96"),
                Tema = "Evento Inicial",
                Data = DateTime.Now.AddDays(13),
                Local = "Ubatuba",
                Lote = "XTR88847",
                QtdPessoas = 400,
                ImageURL = "../images/evento_capa_ubatuba.png"
            },
            new Evento()
            {
                Id = Guid.Parse("9d62a99c-195b-41e6-84bc-b3024b1a396d"),
                Tema = "Evento C#",
                Data = DateTime.Now.AddDays(10),
                Local = "Caraguatatuba",
                Lote = "XTR907989789",
                QtdPessoas = 800,
                ImageURL = "../images/evento_capa_caragua.png"
            }
        };
        public EventoController()
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _eventos;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(Guid id)
        {
            return _eventos.Where(evento => evento.Id == id);
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
        public string Delete(int id)
        {
            return $"Exemplo de Delete com {id}";
        }                    
    }
}
