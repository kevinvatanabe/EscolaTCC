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

        //Informações virão do Login
        [Display(Name = "Código do Funcionário Cargo")]
        [Required(ErrorMessage = "Nome deve ser informado!")]
        public int Cd_FuncCargo { get; set; }

        [Display(Name = "Código da Turma")]
        [Required(ErrorMessage = "Código da Turma deve ser informado!")]
        public int Cd_Turma { get; set; }

        [Display(Name = "Descrição da aula")]
        [Required(ErrorMessage = "Descrição da aula deve ser informada!")]
        public int Ds_Aula { get; set; }

        [Display(Name = "Data da aula")]
        [Required(ErrorMessage = "Data da aula deve ser informada!")]
        public DateTime Dt_Aula { get; set; }





    }
}
