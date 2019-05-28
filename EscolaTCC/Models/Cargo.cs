using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Cargo
    {
        [Key]
        public int cdCargo { get; set; }

        [Display(Name = "Nome do Cargo")]
        public String nmCargo { get; set; }
    }
}
