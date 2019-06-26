using EscolaTCC.Models.BLL;
using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.DAL
{
    public class TurmaProfessorDal
    {
        public Int64 SelecionaProfessorCpf(string email)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand
            ("CALL sp_ProfessorCpfCod(@Nm_Email);", con.conectarBD());
            
            cmd.Parameters.AddWithValue("@Nm_Email", MySqlDbType.Date).Value = email;

            Int64 sucesso = Convert.ToInt64(cmd.ExecuteScalar());

            con.desconectarBD();

            return sucesso;
        }

        public List<TurmaProfessor> SelectTurmaProfessor(Int64 cpf)
        {
            Conexao con = new Conexao();

            MySqlDataAdapter msda = new MySqlDataAdapter
            ("SELECT M.cdTurma, M.nmMateria, A.cdAluno,A.nmAluno " +
             "FROM tblMatProf M " +
             "INNER JOIN tblFuncionario F ON M.cdFunc = F.cdFunc " +
             "INNER JOIN tblAluno A ON A.cdTurma = M.cdTurma " +
             "WHERE M.cdFunc = (SELECT cdFunc FROM tblFuncionario WHERE noCpfFunc =" + cpf + "); ", con.conectarBD());

            DataSet ds = new DataSet();
            msda.Fill(ds);

            con.desconectarBD();

            List<TurmaProfessor> lista = new List<TurmaProfessor>();
            int vai = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TurmaProfessor item = new TurmaProfessor();
                item.Cd_Aluno = int.Parse(dr["cdAluno"].ToString());
                item.Nm_Aluno = dr["nmAluno"].ToString();
                if (vai == 0)
                {
                    item.Nm_Materia = dr["nmMateria"].ToString();
                    item.Cd_Turma = int.Parse(dr["cdTurma"].ToString());
                }
                lista.Add(item);
                vai++;

            }
            return lista;
        }
    }
}
