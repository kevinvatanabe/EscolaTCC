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

        public bool falta { get; set; }

        //Adicionar um contador de faltas
        public int MyProperty { get; set; }

        //Chaves Estrangeiras
        public int cdAluno { get; set; }

        public int cdMateria { get; set; }

    }
}
