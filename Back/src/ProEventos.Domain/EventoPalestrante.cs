using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class EventoPalestrante : ControlFields
    {
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
        public int PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
    }
}