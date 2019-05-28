using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.ViewsModels
{
    public class MateriaProfessor
    {
        [Key]
        public int cdMatProf { get; set; }

        public Materia cdMateria { get; set; }

        public FuncCargo cdFuncCargo { get; set; }
    }
}
