using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogDeDados.Models
{
    public class Usuario
    {
        [Key]
        public int IDUsuario { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [ScaffoldColumn(false)]
        public Guid Token { get; set; }

        public ICollection<Log> Logs { get; set; }
    }
}
