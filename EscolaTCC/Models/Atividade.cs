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
        public int cdAtv { get; set; }

        [Display(Name = "Data da Realização da Atividade")]
        public int dtAtv { get; set; }

        [Display(Name = "Descrição da Atividade")]
        public String dsAtv { get; set; }

        //Código do professor vinculda a matéria
        [Display(Name = "Código do Professor")]
        public int cdFuncCargo { get; set; }

        //Código da Turma
        [Display(Name = "Código da Turma")]
        public int cdTurma { get; set; }
    }
}
