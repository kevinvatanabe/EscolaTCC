using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.BLL
{
    public class MatNota
    {

        [Key]
        public int Cd_MatNota { get; set; }


        //Foreign Key

        public int Cd_MatProf { get; set; }

        public int Cd_Nota { get; set; }

        public int No_Media { get; set; }


    }
}
