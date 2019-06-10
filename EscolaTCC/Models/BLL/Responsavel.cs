using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Responsavel
    {
 

        //Informações básicas
        [Key]
        public int Cd_Resp           { get; set; }

        [Display(Name = "Nome")]
        public String Nm_Resp        { get; set; }

        [Display(Name = "Data de Nascimento")]
        public int Dt_NascResp      { get; set; }

        [Display(Name = "Endereço")]
        public String No_EndResp{ get; set; }

        [Display(Name = " Complemento do Endereço")]
        public String Ds_CompleResp { get; set; }



        //Números Importantes
        [Display(Name = "CPF")]
        public int No_CpfResp       { get; set; }

        [Display(Name = "RG")]
        public int No_RgResp        { get; set; }

        [Display(Name = "Último dígito do RG")]
        public int Dig_RgResp       { get; set; }


        //Contato
        [Display(Name = "E-mail")]
        public String Nm_EmailResp  { get; set; }

        [Display(Name = "Telefone")]
        public int No_TelResp       { get; set; }

        //Endereço
        //Chave Estrangeira
        [Display(Name = "CEP")]
        public Endereco Cep_End      { get; set; }

    }
}
