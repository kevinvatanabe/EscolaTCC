using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.BLL
{
    public class Aula
    {

        [Key]
        public int Cd_Aula { get; set; }


        //Foreign Key

        public int Cd_FuncCargo { get; set; }

        public int Cd_Turma { get; set; }

        [Display(Name = "Descrição da Conta")]
        public int Ds_Aula { get; set; }


        public DateTime Dt_Aula { get; set; }





    }
}
