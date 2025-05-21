using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class Evento : ControlFields
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? Data { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }
        public string ImageURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Lote> Lotes { get; set; }
        public IEnumerable<RedeSocial> RedeSociais { get; set; }
        public IEnumerable<EventoPalestrante> EventoPalestrante { get; set; }
    }
}