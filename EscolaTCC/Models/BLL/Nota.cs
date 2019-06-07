using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Nota
    {
        [Key]
        public int Cd_Nota { get; set; }

        [Display(Name = "Menção da Atividade")]
        public String Mencao { get; set; }

        public Atividade Cd_Atv { get; set; }

        public Aluno Cd_Aluno { get; set; }

        
    }
}
