using System;
using System.ComponentModel.DataAnnotations;

namespace EscolaTCC.Models
{
    public class Responsavel
    {
        //Informações básicas
        [Display(Name = "Nome")]
        public String Nm_Resp        { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime Dt_NascResp      { get; set; }

        //Números Importantes
        [Display(Name = "CPF")]
        public int No_CpfResp { get; set; }

        [Display(Name = "RG")]
        public int No_RgResp { get; set; }

        [Display(Name = "Último dígito do RG")]
        public string Dig_RgResp { get; set; }

        //Endereço
        //Chave Estrangeira
        [Display(Name = "CEP")]
        public Endereco Cep_End { get; set; }

        [Display(Name = "Endereço")]
        public String No_EndResp{ get; set; }

        [Display(Name = " Complemento do Endereço")]
        public String Ds_CompleResp { get; set; }


        //Contato
        [Display(Name = "E-mail para contato")]
        public String Nm_EmailResp  { get; set; }

        [Display(Name = "Telefone")]
        public int No_TelResp       { get; set; }

        //Conta
        [Display(Name = "E-mail da conta")]
        public String Nm_Email { get; set; }

        [Display(Name = "Senha")]
        public String Nm_Senha { get; set; }

        //Não vai para a View
        [Display(Name = "Código da conta")]
        public int Cd_LoginResp { get; set; }

        [Key]
        public int Cd_Resp { get; set; }
    }
}
