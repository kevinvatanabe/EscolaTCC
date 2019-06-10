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
        public void CadastroAluno(Aluno aluno)
        {
            MySqlCommand cmd = new MySqlCommand
           ("CALL spInsereAluno(@CD_Bene,@NM_Bene,@DT_Nasc_Bene,@CPF_Bene,@NM_Pai,@NM_Mae,@CD_Resp)", con.conectarBD());

            cmd.Parameters.Add("@NM_Bene", MySqlDbType.VarChar).Value = aluno.Nm_Aluno;
            cmd.Parameters.Add("@DT_Nasc_Bene", MySqlDbType.Date).Value = aluno.Dt_NascAluno;
            cmd.Parameters.Add("@CPF_Bene", MySqlDbType.Int32).Value = aluno.No_CpfAluno;
            cmd.Parameters.Add("@NM_Pai", MySqlDbType.VarChar).Value = aluno.Nm_Pai;
            cmd.Parameters.Add("@NM_Mae", MySqlDbType.VarChar).Value = aluno.Nm_Mae;
            cmd.Parameters.Add("@CD_Resp", MySqlDbType.Int32).Value = aluno.Cd_Resp;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }
    }
}
