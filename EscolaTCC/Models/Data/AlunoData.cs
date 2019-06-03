using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.Data
{
    public class AlunoData
    {
        Conexao con = new Conexao();
        public void CadastroAluno(Aluno aluno)
        {
            MySqlCommand cmd = new MySqlCommand
           ("CALL sp_InsertAluno(@CD_Bene,@NM_Bene,@DT_Nasc_Bene,@CPF_Bene,@NM_Pai,@NM_Mae,@CD_Resp)", con.conectarBD());

            cmd.Parameters.Add("@CD_Bene", MySqlDbType.Int32).Value = aluno.CD_Bene;
            cmd.Parameters.Add("@NM_Bene", MySqlDbType.VarChar).Value = aluno.NM_Bene;
            cmd.Parameters.Add("@DT_Nasc_Bene", MySqlDbType.Date).Value = aluno.DT_Nasc_Bene;
            cmd.Parameters.Add("@CPF_Bene", MySqlDbType.Int32).Value = aluno.CPF_Bene;
            cmd.Parameters.Add("@NM_Pai", MySqlDbType.VarChar).Value = aluno.NM_Pai;
            cmd.Parameters.Add("@NM_Mae", MySqlDbType.VarChar).Value = aluno.NM_Mae;
            cmd.Parameters.Add("@CD_Resp", MySqlDbType.Int32).Value = aluno.CD_Resp;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }
    }
}
