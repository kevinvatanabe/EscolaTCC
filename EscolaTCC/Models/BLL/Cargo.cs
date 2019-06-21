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
        [Required(ErrorMessage = "Nome do cargo deve ser informado!")]
        public String Nm_Cargo { get; set; }

        //Descrição do cargo
        [Display(Name = "Descrição do Cargo")]
        [Required(ErrorMessage = "Descrição do cargo deve ser informada!")]
        public String Ds_Cargo { get; set; }
    }
}
