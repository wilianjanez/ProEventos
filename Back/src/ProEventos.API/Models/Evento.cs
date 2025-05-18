using System;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.API.Models
{
    public class Evento : ControlFields
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }
        public string ImageURL { get; set; }    
    }
}