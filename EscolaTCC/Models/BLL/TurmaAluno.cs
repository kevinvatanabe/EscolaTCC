using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.BLL
{
    public class TurmaAluno
    {

        [Key]
        public int Cd_TurmaAluno { get; set; }

        public int Cd_Aluno { get; set; }

        public int Cd_Turma { get; set; }


    }
}
