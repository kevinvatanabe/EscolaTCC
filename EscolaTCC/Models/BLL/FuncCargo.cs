using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class FuncCargo
    {
        [Key]
        public int cdFuncCargo { get; set; }

        [Display(Name = "Formação")]
        public String dsFormacao { get; set; }

        [Display(Name = "Salário")]
        public decimal No_Salario { get; set; }

        [Display(Name = "Descrição")]
        public String Ds_Cargo { get; set; }

        //Chaves Estrangeiras
        public int cdFunc { get; set; }
        public int cdLogin { get; set; }
        public int cdCargo { get; set; }


    }
}
