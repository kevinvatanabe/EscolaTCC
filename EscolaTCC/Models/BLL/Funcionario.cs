using System;
using System.ComponentModel.DataAnnotations;

namespace EscolaTCC.Models.BLL
{
    public class Funcionario
    {
        //Chave Primária
        [Key]
        public int Cd_Func { get; set; }

        //Dados
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome deve ser informado!")]
        public String Nm_Func { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF deve ser informado!")]
        public Int64 No_CpfFunc { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "RG deve ser informado!")]
        public Int64 No_RgFunc { get; set; }

        [Display(Name = "Dígito do RG")]
        [Required(ErrorMessage = "Último dígito do RG deve ser informado!")]
        public String Rg_DigFunc { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Telefone deve ser informado!")]
        public Int64 No_TelFunc { get; set; }

        [Display(Name = "E-mail para contato")]
        [Required(ErrorMessage = "E-mail para contato deve ser informado!")]
        public String Nm_EmailFunc { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Data de nascimento deve ser informada!")]
        public DateTime Dt_NascFunc { get; set; }

        [Display(Name = "Número do Endereço ")]
        [Required(ErrorMessage = "Número do endereço deve ser informado!")]
        public int No_EndFunc { get; set; }

        [Display(Name = "Complemento do Endereço")]
        public String Ds_CompleFunc { get; set; }

        // Foreign Key
        [Display(Name = "CEP")]
        [Required(ErrorMessage = "E-mail para contato deve ser informado!")]
        public int No_CepFunc { get; set; }

        
    }
}
