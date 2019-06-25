using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.DAL
{
    public class AlunoDal
    {
        Conexao con = new Conexao();

        //CRUD
        public string CadastroAluno(Aluno aluno)
        {
            MySqlCommand cmd = new MySqlCommand
           ("CALL sp_InsertAluno(@NM_Bene,@DT_Nasc_Bene,@No_RgAluno,@Dig_RgAluno,@No_CpfAluno,@NM_Pai,@NM_Mae,@Cpf_Resp,@Cd_Turma)", con.conectarBD());

            cmd.Parameters.Add("@NM_Bene", MySqlDbType.VarChar).Value = aluno.Nm_Aluno;
            cmd.Parameters.Add("@DT_Nasc_Bene", MySqlDbType.Date).Value = aluno.Dt_NascAluno;
            cmd.Parameters.Add("@No_RgAluno", MySqlDbType.Int64).Value = aluno.No_RgAluno;
            cmd.Parameters.Add("@Dig_RgAluno", MySqlDbType.VarChar).Value = aluno.Dig_RgAluno;
            cmd.Parameters.Add("@No_CpfAluno", MySqlDbType.Int64).Value = aluno.No_CpfAluno;
            cmd.Parameters.Add("@NM_Pai", MySqlDbType.VarChar).Value = aluno.Nm_Pai;
            cmd.Parameters.Add("@NM_Mae", MySqlDbType.VarChar).Value = aluno.Nm_Mae;
            cmd.Parameters.Add("@Cpf_Resp", MySqlDbType.Int64).Value = aluno.Cpf_Resp;
            cmd.Parameters.Add("@Cd_Turma", MySqlDbType.Int64).Value = aluno.Cd_Turma;

            string sucesso = Convert.ToString(cmd.ExecuteScalar());

            con.desconectarBD();

            return sucesso;
        }

        public List<Aluno> SelectAllAlunos()
        {
            Conexao con = new Conexao();

            MySqlDataAdapter msda = new MySqlDataAdapter
            ("SELECT A.*, (SELECT noCpfResp FROM tblResponsavel AS R where R.cdResp = A.cdResp) AS noCpfResp," +
             "T.* "+
             "FROM tblAluno A " +
             "INNER JOIN tblTurma T "+
             "ON T.cdTurma = A.cdTurma ", con.conectarBD());

            DataSet ds = new DataSet();
            msda.Fill(ds);

            con.desconectarBD();

            List<Aluno> lista = new List<Aluno>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Aluno item = new Aluno();
                item.Cd_Aluno = int.Parse(dr["cdAluno"].ToString());
                item.Nm_Aluno = dr["nmAluno"].ToString();
                item.Dt_NascAluno = DateTime.Parse(dr["dtNascAluno"].ToString());
                item.No_CpfAluno = Int64.Parse(dr["noCpfAluno"].ToString());
                item.No_RgAluno = Int64.Parse(dr["noRgAluno"].ToString());
                item.Dig_RgAluno = dr["dig_RgAluno"].ToString();
                item.Nm_Pai = dr["nmPai"].ToString();
                item.Nm_Mae = dr["nmMae"].ToString();
                item.Cpf_Resp = Int64.Parse(dr["noCpfResp"].ToString());

                item.Cd_Turma = int.Parse(dr["cdTurma"].ToString());
                item.nmTurma = dr["nmTurma"].ToString();
                item.nmTurno = dr["nmTurno"].ToString();
                item.dsSerie = dr["dsSerie"].ToString();

                lista.Add(item);
            }
            return lista;
        }

        public Aluno SelectOneAluno(int cdAluno)
        {
            Conexao con = new Conexao();

            MySqlDataAdapter msda = new MySqlDataAdapter
           ("SELECT A.*, (SELECT noCpfResp FROM tblResponsavel AS R where R.cdResp = A.cdResp) AS noCpfResp," +
            "T.* " +
            "FROM tblAluno A " +
            "INNER JOIN tblTurma T " +
            "ON T.cdTurma = A.cdTurma "+ 
            "WHERE cdAluno = " + cdAluno, con.conectarBD());

            DataSet ds = new DataSet();
            msda.Fill(ds);

            con.desconectarBD();

            List<Aluno> lista = new List<Aluno>();

            Aluno item = new Aluno();
            if (ds.Tables[0].Rows.Count > 0)
            {
                item.Cd_Aluno = int.Parse(ds.Tables[0].Rows[0]["cdAluno"].ToString());
                item.Nm_Aluno = ds.Tables[0].Rows[0]["nmAluno"].ToString();
                item.Dt_NascAluno = DateTime.Parse(ds.Tables[0].Rows[0]["dtNascAluno"].ToString());
                item.No_CpfAluno = Int64.Parse(ds.Tables[0].Rows[0]["noCpfAluno"].ToString());
                item.No_RgAluno = Int64.Parse(ds.Tables[0].Rows[0]["noRgAluno"].ToString());
                item.Dig_RgAluno = ds.Tables[0].Rows[0]["dig_RgAluno"].ToString();
                item.Nm_Pai = ds.Tables[0].Rows[0]["nmPai"].ToString();
                item.Nm_Mae = ds.Tables[0].Rows[0]["nmMae"].ToString();
                item.Cpf_Resp = Int64.Parse(ds.Tables[0].Rows[0]["noCpfResp"].ToString());

                item.Cd_Turma = int.Parse(ds.Tables[0].Rows[0]["cdTurma"].ToString());
                item.nmTurma = ds.Tables[0].Rows[0]["nmTurma"].ToString();
                item.nmTurno = ds.Tables[0].Rows[0]["nmTurno"].ToString();
                item.dsSerie = ds.Tables[0].Rows[0]["dsSerie"].ToString();
            }
            return item;
        }
        public string AlterAluno(Aluno aluno)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand
           ("CALL sp_AlterAluno(@Cd_Aluno,@NM_Bene,@DT_Nasc_Bene,@No_RgAluno,@Dig_RgAluno,@No_CpfAluno,@NM_Pai,@NM_Mae,@Cpf_Resp,@Cd_Turma)", con.conectarBD());

            cmd.Parameters.Add("@Cd_Aluno", MySqlDbType.Int64).Value = aluno.Cd_Aluno;
            cmd.Parameters.Add("@NM_Bene", MySqlDbType.VarChar).Value = aluno.Nm_Aluno;
            cmd.Parameters.Add("@DT_Nasc_Bene", MySqlDbType.Date).Value = aluno.Dt_NascAluno;
            cmd.Parameters.Add("@No_RgAluno", MySqlDbType.Int64).Value = aluno.No_RgAluno;
            cmd.Parameters.Add("@Dig_RgAluno", MySqlDbType.VarChar).Value = aluno.Dig_RgAluno;
            cmd.Parameters.Add("@No_CpfAluno", MySqlDbType.Int64).Value = aluno.No_CpfAluno;
            cmd.Parameters.Add("@NM_Pai", MySqlDbType.VarChar).Value = aluno.Nm_Pai;
            cmd.Parameters.Add("@NM_Mae", MySqlDbType.VarChar).Value = aluno.Nm_Mae;
            cmd.Parameters.Add("@Cpf_Resp", MySqlDbType.Int64).Value = aluno.Cpf_Resp;
            cmd.Parameters.Add("@Cd_Turma", MySqlDbType.Int64).Value = aluno.Cd_Turma;

            string sucesso = Convert.ToString(cmd.ExecuteScalar());

            con.desconectarBD();
            return sucesso;
        }
    }
}
