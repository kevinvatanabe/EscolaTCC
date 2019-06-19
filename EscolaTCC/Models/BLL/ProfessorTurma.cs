using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.BLL
{
    public class ProfessorTurma
    {
        [Display(Name = "Número")]
        public int Contador { get; set; }

        [Display(Name = "Descrição da série da Turma")]
        public int Cd_Turma { get; set; }

        [Display(Name = "Descrição da série da Turma")]
        public String dsSerie { get; set; }

        [Display(Name = "Nome do Professor")]
        public String Nm_Professor { get; set; }

        [Display(Name = "Nome da matéria")]
        public String Nm_Materia { get; set; }

        [Display(Name = "Número de aulas totais")]
        public int No_AulasTotais { get; set; }

        [Display(Name = "Número de aulas dadas")]
        public int No_AulasDadas { get; set; }
    }
}
