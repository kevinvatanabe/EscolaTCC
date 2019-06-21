using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Atividade
    {
        [Key]
        public int Cd_Atv { get; set; }

        [Display(Name = "Data da Realização da Atividade")]
        [Required(ErrorMessage = "Data deve ser informada!")]
        public int Dt_Atv { get; set; }

        [Display(Name = "Descrição da Atividade")]
        [Required(ErrorMessage = "Descrição deve ser informada!")]
        public String Ds_Atv { get; set; }

        //Código do professor vinculda a matéria
        [Display(Name = "Código do Professor")]
        [Required(ErrorMessage = "Código do Funcionário Cargo deve ser informado!")]
        public int Cd_FuncCargo { get; set; }

        //Código da Turma
        [Display(Name = "Código da Turma")]
        [Required(ErrorMessage = "Código da turma deve ser informado!")]
        public int Cd_Turma { get; set; }
    }
}
