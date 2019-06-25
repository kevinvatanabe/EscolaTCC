using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.BLL
{
    public class TurmaAluno
    {
        public int Contador { get; set; }

        public int Cd_Turma { get; set; }

        public string Nm_Turma { get; set; }

        public string Ds_Serie { get; set; }

        [Display(Name = "Código do Professor")]
        public int Cd_Professor { get; set; }

        [Display(Name = "Professor")]
        public int Nm_Professor { get; set; }

        [Display(Name = "Matéria")]
        public string Nm_Materia { get; set; }

        [Display(Name = "Código do Aluno")]
        public int Cd_Aluno { get; set; }

        [Display(Name = "Nome do Aluno")]
        public string Nm_Aluno { get; set; }
    }
}
