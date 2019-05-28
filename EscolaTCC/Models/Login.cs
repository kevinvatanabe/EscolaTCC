using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Login
    {
        [Key]
        public int cdLogin { get; set; }

        [Display(Name = "Usuário")]
        public int nmUsuario { get; set; }

        [Display(Name ="Senha")]
        public int nmSenha { get; set; }
    }
}
