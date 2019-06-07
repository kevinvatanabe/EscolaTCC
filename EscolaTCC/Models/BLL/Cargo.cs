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
        public int CdCargo { get; set; }

        [Display(Name = "Nome do Cargo")]
        public String Nm_Cargo { get; set; }

        //Descrição do cargo
        [Display(Name = "Descrição do Cargo")]
        public String Ds_Cargo { get; set; }
    }
}
