using EscolaTCC.Models.BLL;
using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace EscolaTCC.Models.DAL
{
    public class TurmaAlunoDal
    {
        public string CadastroMateriaProfessor(TurmaAluno turmaAluno)
        {
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand
           ("CALL sp_InsertMatProf(@Cpf_Prof,@Nm_Materia,@Cd_Turma)", con.conectarBD());

            cmd.Parameters.Add("@Cpf_Prof", MySqlDbType.VarChar).Value = turmaAluno.Cpf_Prof;
            cmd.Parameters.Add("@Nm_Materia", MySqlDbType.Date).Value = turmaAluno.Nm_Materia;
            cmd.Parameters.Add("@Cd_Turma", MySqlDbType.Int64).Value = turmaAluno.Cd_Turma;

            string sucesso = Convert.ToString(cmd.ExecuteScalar());

            con.desconectarBD();

            return sucesso;
        }

        public List<TurmaAluno> SelectAlunoTurmaProfessorMateria(int cdTurma)
        {
            Conexao con = new Conexao();

            MySqlDataAdapter msda = new MySqlDataAdapter
            ("SELECT  A.cdAluno, A.nmAluno, T.cdTurma, M.*, F.nmFunc "+
             "FROM tblAluno A " +
             "INNER JOIN tblTurma T ON T.cdTurma = A.cdTurma " +
             "INNER JOIN tblMatProf M ON M.cdTurma = A.cdTurma " +
             "INNER JOIN tblFuncionario F ON M.cdFunc = F.cdFunc "+
             "WHERE A.cdTurma = " + cdTurma + ";", con.conectarBD());

            DataSet ds = new DataSet();
            msda.Fill(ds);

            con.desconectarBD();

            List<TurmaAluno> lista = new List<TurmaAluno>();
            int vai = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TurmaAluno item = new TurmaAluno();
                item.Cd_Aluno = int.Parse(dr["cdAluno"].ToString());
                item.Nm_Aluno = dr["nmAluno"].ToString();
                if (vai == 0)
                {
                    item.Cd_MatProf = int.Parse(dr["cdMatProf"].ToString());
                    item.Cd_Professor = dr["cdFunc"].ToString();
                    item.Nm_Materia = dr["nmMateria"].ToString();
                    item.Nm_Professor = dr["nmFunc"].ToString();
                    item.Cd_Turma = int.Parse(dr["cdTurma"].ToString());
                }
                lista.Add(item);
                vai++;
                
            }
            return lista;
        }
    }
}
