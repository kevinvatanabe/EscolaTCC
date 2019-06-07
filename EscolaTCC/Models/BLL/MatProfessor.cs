using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.BLL
{
    public class MatProfessor
    {

        [Key]
        public int Cd_MatProf { get; set; }

        public int Cd_FuncCargo { get; set; }

        public int Cd_Materia { get; set; }


    }
}
