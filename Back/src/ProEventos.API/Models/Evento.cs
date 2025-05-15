using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProEventos.API.Models
{
    public class Evento : ControlFields
    {
        public Guid Id { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }
        public string ImageURL { get; set; }    

        public Evento()
        {
            Id = Guid.NewGuid();
        }                                               
    }
}