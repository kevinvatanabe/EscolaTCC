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
        public int Cd_Chamada { get; set; }

        //Não acho que seja booleano
        [Display(Name = "Falta do dia")]
        public bool falta { get; set; }

        //Chaves Estrangeiras
        public int cdAluno { get; set; }

        public int cdMateria { get; set; }

    }
}
