using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.ResponseCompression;

namespace ProEventos.API.Models
{
    public class ControlFields
    {
        public Guid UsuarioCriacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid? UsuarioEdicao { get; set; }
        public DateTime? DataEdicao { get; set; }
        public Guid? UsuarioDelecao { get; set; }
        public DateTime? DataDelecao { get; set; }
        public bool Ativo { get; set; }
        
        public ControlFields()
        {
            DataCriacao = DateTime.Now;
            Ativo = true;
        }        
    }
}