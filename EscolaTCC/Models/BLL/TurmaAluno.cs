﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.BLL
{
    public class TurmaAluno
    {
        [Display(Name = "Número")]
        public int Contador { get; set; }

        [Display(Name = "Descrição da série da Turma")]
        public int Cd_Turma { get; set; }

        [Display(Name = "Descrição da série da Turma")]
        public String dsSerie { get; set; }

        [Display(Name = "Código/Registro do Aluno")]
        public int Cd_Aluno { get; set; }

        [Display(Name = "Nome do Aluno")]
        public string Nm_Aluno { get; set; }




    }
}
