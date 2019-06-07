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
        public int cdNota { get; set; }

        [Display(Name = "Menção da Atividade")]
        public String Mencao { get; set; }

        public Atividade cdAtv { get; set; }

        public Aluno cdAluno { get; set; }

        
    }
}
