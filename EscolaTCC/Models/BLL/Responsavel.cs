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


        //CRUD
        public void CadastroResponsavel(Responsavel resp)
        {
            MySqlCommand cmd = new MySqlCommand
           ("INSERT INTO tblResponsavel VALUES(@CD_Resp,@NM_Resp,@Dt_Nasc_Resp,@NO_CPF_Resp,@NO_RG_Resp,@Dig_RG_Resp,@NM_Email_Resp,@NO_Tel_Resp,@CEP_End)", con.conectarBD());

            cmd.Parameters.Add("@CD_Resp",       MySqlDbType.Int32).Value =     resp.Cd_Resp;
            cmd.Parameters.Add("@NM_Resp",       MySqlDbType.VarChar).Value =   resp.Nm_Resp;
            // Acrescentar Endereço e complemento endereço
            cmd.Parameters.Add("@Dt_Nasc_Resp",  MySqlDbType.Date).Value =      resp.Dt_NascResp;
            cmd.Parameters.Add("@NO_CPF_Resp",   MySqlDbType.Int32).Value =     resp.No_CpfResp;
            cmd.Parameters.Add("@NO_RG_Resp",    MySqlDbType.Int32).Value =     resp.No_RgResp;
            cmd.Parameters.Add("@Dig_RG_Resp",   MySqlDbType.VarChar).Value =   resp.Dig_RgResp;
            cmd.Parameters.Add("@NM_Email_Resp", MySqlDbType.VarChar).Value =   resp.Nm_EmailResp;
            cmd.Parameters.Add("@NO_Tel_Resp",   MySqlDbType.Int32).Value =     resp.No_TelResp;
            cmd.Parameters.Add("@CEP_End",       MySqlDbType.Int32).Value =     resp.Cep_End;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }
    }
}
