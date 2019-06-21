using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    }
}
