using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.BLL
{
    public class Funcionario
    {
        //Chave Primária
        [Key]
        public int Cd_Func { get; set; }


        //Dados
        [Display(Name = "Nome")]
        public String Nm_Func { get; set; }

        [Display(Name = "CPF")]
        public int No_CpfFunc { get; set; }

        [Display(Name = "RG")]
        public int No_RgFunc { get; set; }

        [Display(Name = "Dígito do RG")]
        public int Rg_DigFunc { get; set; }

        [Display(Name = "Telefone")]
        public int No_TelFunc { get; set; }

        [Display(Name = "Email")]
        public String Nm_EmailFunc { get; set; }

        [Display(Name = "Data de Nascimento")]
        public String Dt_NascFunc { get; set; }

        [Display(Name = "Endreço ")]
        public String No_EndFunc { get; set; }

        [Display(Name = "Complemento do Funcionário")]
        public String Ds_CompleFunc { get; set; }

        // Foreign Key

        public int No_CepFunc { get; set; }



    }
}
