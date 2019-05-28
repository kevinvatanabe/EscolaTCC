﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Turma
    {
        [Key]
        public int cdTurma { get; set; }

        [Display(Name = "Nome da Turma")]
        public String nmTurma { get; set; }

        [Display(Name = "Descrição da série da Turma")]
        public String dsSerie { get; set; }
    }
}
