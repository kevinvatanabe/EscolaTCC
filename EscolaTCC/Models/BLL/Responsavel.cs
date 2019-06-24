using System;
using System.ComponentModel.DataAnnotations;

namespace EscolaTCC.Models
{
    public class Responsavel
    {
        //Informações básicas
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome deve ser informado!")]
        public String Nm_Resp        { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Aniversário deve ser informado!")]
        public DateTime Dt_NascResp      { get; set; }

        //Números Importantes
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF deve ser informado!")]
        public Int64 No_CpfResp { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "RG deve ser informado!")]
        public Int64 No_RgResp { get; set; }

        [Display(Name = "Último dígito do RG")]
        [Required(ErrorMessage = "Último dígito do RG deve ser informado!")]
        public string Dig_RgResp { get; set; }

        //Endereço
        //Chave Estrangeira
        [Display(Name = "CEP")]
        [Required(ErrorMessage = "CEP deve ser informado!")]    
        public Int64 Cep_End { get; set; }

        [Display(Name = "Número do Endereço")]
        [Required(ErrorMessage = "Número do Endereço deve ser informado!")]
        public int No_EndResp{ get; set; }

        [Display(Name = " Complemento do Endereço")]
        public String Ds_CompleResp { get; set; }


        //Contato
        [Display(Name = "E-mail para contato")]
        [Required(ErrorMessage = "E-mail deve ser informado!")]
        public String Nm_EmailResp  { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Telefone deve ser informado!")]
        public Int64 No_TelResp       { get; set; }

        //Conta
        [Display(Name = "E-mail da conta")]
        [Required(ErrorMessage = "E-mail da conta deve ser informado!")]
        public String Nm_EmailRespConta { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Senha deve ser informada!")]
        public String Nm_SenhaResp { get; set; }

        [Display(Name = "Repetir Senha")]
        [Required(ErrorMessage = "Repetição da Senha deve ser informada!")]
        public String Nm_RepetirSenhaResp { get; set; }

        //Não vai para a View
        [Display(Name = "Código da conta")]
        public int Cd_LoginResp { get; set; }

        [Key]
        [Display(Name = "Código do responsável")]
        public int Cd_Resp { get; set; }

        [Display(Name = "Código de Autorização")]
        public int Cd_Autorizacao { get; set; }
    }
}
