using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Turma
    {
        [Key]
        [Display(Name = "Código da Turma")]
        public int cdTurma { get; set; }

        [Display(Name = "Nome da Turma")]
        [Required(ErrorMessage = "Nome da turma deve ser informado!")]
        public String nmTurma { get; set; }

        [Display(Name = "Período")]
        [Required(ErrorMessage = "Período da turma deve ser informado!")]
        public String nmTurno { get; set; }

        [Display(Name = "Descrição da série da Turma")]
        [Required(ErrorMessage = "Descrição da turma deve ser informada!")]
        public String dsSerie { get; set; }
    }
}
