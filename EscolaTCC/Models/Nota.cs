using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Nota
    {
        [Key]
        public int cdNota { get; set; }

        public int cdAtv { get; set; }

        public int cdAluno { get; set; }

        public String Mencao { get; set; }
    }
}
