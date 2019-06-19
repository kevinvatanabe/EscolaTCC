using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.DAL
{
    public class ResponsavelDal
    {
        Conexao con = new Conexao();
        //CRUD
        public void CadastroResponsavel(Responsavel resp)
        {
            MySqlCommand cmd = new MySqlCommand
           ("CALL sp_InsertResponsavel(@NM_Resp,@Dt_Nasc_Resp,@NO_CPF_Resp,@NO_RG_Resp,@Dig_RG_Resp,@NM_Email_Resp,@NO_Tel_Resp,@CEP_End)", con.conectarBD());

            cmd.Parameters.Add("@CEP_End", MySqlDbType.Int32).Value = resp.Cep_End;
            cmd.Parameters.Add("@NM_Resp", MySqlDbType.VarChar).Value = resp.Nm_Resp;
            cmd.Parameters.Add("@Dt_Nasc_Resp", MySqlDbType.Date).Value = resp.Dt_NascResp;
            cmd.Parameters.Add("@NO_CPF_Resp", MySqlDbType.Int32).Value = resp.No_CpfResp;
            cmd.Parameters.Add("@NO_RG_Resp", MySqlDbType.Int32).Value = resp.No_RgResp;
            cmd.Parameters.Add("@Dig_RG_Resp", MySqlDbType.VarChar).Value = resp.Dig_RgResp;
            cmd.Parameters.Add("@NM_Email_Resp", MySqlDbType.VarChar).Value = resp.Nm_EmailResp;
            cmd.Parameters.Add("@NO_Tel_Resp", MySqlDbType.Int32).Value = resp.No_TelResp;
            cmd.Parameters.Add("@CEP_End", MySqlDbType.Int32).Value = resp.Cep_End;
            cmd.Parameters.Add("@CEP_End", MySqlDbType.Int32).Value = resp.Cep_End;
            cmd.Parameters.Add("@CEP_End", MySqlDbType.Int32).Value = resp.Cep_End;
            cmd.Parameters.Add("@CEP_End", MySqlDbType.Int32).Value = resp.Cep_End;
            cmd.Parameters.Add("@CEP_End", MySqlDbType.Int32).Value = resp.Cep_End;


            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }
    }
}
