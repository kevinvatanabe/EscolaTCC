using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Materia
    {
        [Key]
        public int cdMateria { get; set; }

        [Display(Name = "Nome da Matéria")]
        public String Nm_Materia { get; set; }

        [Display(Name = "Descrição da Matéria")]
        public String Ds_Materia { get; set; }
    }
}
