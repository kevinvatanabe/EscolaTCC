﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Login
    {
        [Key]
        public int CdLogin { get; set; }

        [Required (ErrorMessage = "Informe o email!")]
        [Display(Name = "Email")]
        public String NmEmail { get; set; }

        [Required(ErrorMessage = "Informe sua senha!")]
        [Display(Name = "Senha")]
        public String NmSenha { get; set; }

        public int CdAutorizacao { get; set; }
    }
}
