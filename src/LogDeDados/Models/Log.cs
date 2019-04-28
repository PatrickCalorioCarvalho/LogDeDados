using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogDeDados.Models
{
    public class Log
    {
        [Key]
        public int IDLog { get; set; }
        public string Evento { get; set; }
        public string Etapa { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime FIm { get; set; }

        [ScaffoldColumn(false)]
        public int IDUsuario { get; set; }

        public Usuario Usuario { get; set; }
    }
}

