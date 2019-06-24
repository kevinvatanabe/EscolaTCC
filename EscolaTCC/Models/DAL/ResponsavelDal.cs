using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.DAL
{
    public class ResponsavelDal
    {
      
              
        public string CadastroResponsavel(Responsavel resp)
        {
            Conexao con = new Conexao();

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


            string sucesso = Convert.ToString(cmd.ExecuteScalar());

            con.desconectarBD();

            return sucesso;
        }

        public List<Responsavel> SelectAllResponsaveis()
        {
            Conexao con = new Conexao();

            MySqlDataAdapter msda = new MySqlDataAdapter
            ("SELECT R.*,"+
             "L.* "+
             "FROM tblResponsavel R " +
             "INNER JOIN tblLogin L "+
             "ON L.cdLogin = R.cdLoginResp; ", con.conectarBD());

            DataSet ds = new DataSet();
            msda.Fill(ds);

            con.desconectarBD();

            List<Responsavel> lista = new List<Responsavel>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Responsavel item = new Responsavel();

                item.Cd_Resp = int.Parse(dr["cdResp"].ToString());
                item.Nm_Resp = dr["nmResp"].ToString();
                item.No_CpfResp = Int64.Parse(dr["noCpfResp"].ToString());
                item.No_RgResp = Int64.Parse(dr["noRgResp"].ToString());
                item.Dig_RgResp = dr["dig_RgResp"].ToString();
                item.No_TelResp = Int64.Parse(dr["noTelResp"].ToString());
                item.Nm_EmailResp = dr["nmEmailResp"].ToString();
                item.Dt_NascResp = DateTime.Parse(dr["dtNascResp"].ToString());
                item.Cep_End = Int64.Parse(dr["noCepResp"].ToString());
                item.No_EndResp = int.Parse(dr["noEndResp"].ToString());
                item.Ds_CompleResp = dr["dsCompleResp"].ToString();
                //da tblLogin
                item.Cd_LoginResp = int.Parse(dr["cdLoginResp"].ToString());          
                item.Nm_EmailRespConta = dr["nmEmail"].ToString();
                item.Nm_SenhaResp = dr["nmSenha"].ToString();

                lista.Add(item);
            }
            return lista;
        }

        public Responsavel SelectOneResponsavel(int cdResp)
        {
            Conexao con = new Conexao();

            MySqlDataAdapter msda = new MySqlDataAdapter
             ("SELECT R.*," +
              "L.* " +
              "FROM tblResponsavel R " +
              "INNER JOIN tblLogin L " +
              "ON L.cdLogin = R.cdLoginResp " +
              "WHERE R.cdResp = " + cdResp + ";", con.conectarBD());

            DataSet ds = new DataSet();
            msda.Fill(ds);

            con.desconectarBD();

            List<Responsavel> lista = new List<Responsavel>();

            Responsavel item = new Responsavel();
            if (ds.Tables[0].Rows.Count > 0)
            {
                item.Cd_Resp = int.Parse(ds.Tables[0].Rows[0]["cdResp"].ToString());
                item.Nm_Resp = ds.Tables[0].Rows[0]["nmResp"].ToString();
                item.No_CpfResp = Int64.Parse(ds.Tables[0].Rows[0]["noCpfResp"].ToString());
                item.No_RgResp = Int64.Parse(ds.Tables[0].Rows[0]["noRgResp"].ToString());
                item.Dig_RgResp = ds.Tables[0].Rows[0]["dig_RgResp"].ToString();
                item.No_TelResp = Int64.Parse(ds.Tables[0].Rows[0]["noTelResp"].ToString());
                item.Nm_EmailResp = ds.Tables[0].Rows[0]["nmEmailResp"].ToString();
                item.Dt_NascResp = DateTime.Parse(ds.Tables[0].Rows[0]["dtNascResp"].ToString());
                item.Cep_End = Int64.Parse(ds.Tables[0].Rows[0]["noCepResp"].ToString());
                item.No_EndResp = int.Parse(ds.Tables[0].Rows[0]["noEndResp"].ToString());
                item.Ds_CompleResp = ds.Tables[0].Rows[0]["dsCompleResp"].ToString();
                //tabela tblLogin
                item.Cd_LoginResp = int.Parse(ds.Tables[0].Rows[0]["cdLoginResp"].ToString());
                item.Nm_EmailRespConta = ds.Tables[0].Rows[0]["nmEmail"].ToString();
                item.Nm_SenhaResp = ds.Tables[0].Rows[0]["nmSenha"].ToString();
            }
            return item;
        }

        public string AlterResponsavel(Responsavel resp)
        {

        }
    }
}
