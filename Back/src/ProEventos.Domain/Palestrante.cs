using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class Palestrante : ControlFields
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Curriculo { get; set; }
        public string ImageURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<RedeSocial> RedeSociais { get; set; }
        public IEnumerable<EventoPalestrante> EventoPalestrante { get; set; }
    }
}