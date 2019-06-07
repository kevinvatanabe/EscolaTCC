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

        [Required (ErrorMessage = "Informe o login!")]
        [Display(Name = "Usuário")]
        public String nmUsuario { get; set; }

        [Required(ErrorMessage = "Informe sua senha!")]
        [Display(Name = "Senha")]
        public String nmSenha { get; set; }
    }
}
