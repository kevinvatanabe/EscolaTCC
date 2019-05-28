using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Chamada
    {
        [Key]
        public int cdChamada { get; set; }

        //Não acho que seja booleano
        [Display(Name = "Falta do dia")]
        public bool falta { get; set; }

        //Adicionar um contador de faltas
        [Display(Name = "Contador de faltas do Aluno")]
        public int presenca { get; set; }

        //Chaves Estrangeiras
        //Associação
        public Aluno cdAluno { get; set; }

        public Materia cdMateria { get; set; }

    }
}
