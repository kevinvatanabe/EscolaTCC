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
              
        public string CadastroResponsavel(Responsavel resp)
        {
            MySqlCommand cmd = new MySqlCommand
           ("CALL sp_InsertResponsavel(" +

           "@CEP_End,@NO_End,@DS_Comple," +

           "@NM_Resp,@NO_CPF_Resp,@NO_RG_Resp," +

           "@Dig_RG_Resp,@Dt_Nasc_Resp,@NM_Email_Resp," +

           "@NO_Tel_Resp," +

           "@NM_Email,@Nm_Senha,@Cd_Autorizacao)", con.conectarBD());

            cmd.Parameters.Add("@CEP_End", MySqlDbType.Int32).Value = resp.Cep_End;
            cmd.Parameters.Add("@NO_End", MySqlDbType.Int32).Value = resp.No_EndResp;
            cmd.Parameters.Add("@DS_Comple", MySqlDbType.VarChar).Value = resp.Ds_CompleResp;
            cmd.Parameters.Add("@NM_Resp", MySqlDbType.VarChar).Value = resp.Nm_Resp;
            cmd.Parameters.Add("@NO_CPF_Resp", MySqlDbType.Int64).Value = resp.No_CpfResp;
            cmd.Parameters.Add("@NO_RG_Resp", MySqlDbType.Int64).Value = resp.No_RgResp;
            cmd.Parameters.Add("@Dig_RG_Resp", MySqlDbType.VarChar).Value = resp.Dig_RgResp;
            cmd.Parameters.Add("@Dt_Nasc_Resp", MySqlDbType.Date).Value = resp.Dt_NascResp;
            cmd.Parameters.Add("@NM_Email_Resp", MySqlDbType.VarChar).Value = resp.Nm_EmailResp;
            cmd.Parameters.Add("@NO_Tel_Resp", MySqlDbType.Int64).Value = resp.No_TelResp;

            cmd.Parameters.Add("@Nm_Email", MySqlDbType.VarChar).Value = resp.Nm_EmailResp;
            cmd.Parameters.Add("@Nm_Senha", MySqlDbType.VarChar).Value = resp.Nm_SenhaResp;
            cmd.Parameters.Add("@Cd_Autorizacao", MySqlDbType.Int32).Value = resp.Cd_Autorizacao;


            string sucesso2 = Convert.ToString(cmd.ExecuteScalar());

            con.desconectarBD();

            return sucesso2;
        }
    }
}
