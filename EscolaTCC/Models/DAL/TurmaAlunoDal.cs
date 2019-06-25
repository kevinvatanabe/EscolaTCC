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
    public class TurmaAlunoDal
    {
        public List<TurmaAluno> SelectAlunoTurma(int cdTurma)
        {
            Conexao con = new Conexao();

            MySqlDataAdapter msda = new MySqlDataAdapter
            ("SELECT A.cdAluno, A.nmAluno FROM tblAluno A " +
             "INNER JOIN tblTurma T ON T.cdTurma = A.cdTurma " +
             "WHERE T.cdTurma = " + cdTurma + ";", con.conectarBD());

            DataSet ds = new DataSet();
            msda.Fill(ds);

            con.desconectarBD();

            List<TurmaAluno> lista = new List<TurmaAluno>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TurmaAluno item = new TurmaAluno();
                item.Cd_Aluno = int.Parse(dr["cdAluno"].ToString());
                item.Nm_Aluno = dr["nmAluno"].ToString();

                lista.Add(item);
            }
            return lista;
        }
        /*
        public List<TurmaAluno> SelectMateriaProfessorTurma(int cdTurma)
        {
            Conexao con = new Conexao();

            MySqlDataAdapter msda = new MySqlDataAdapter
            ("SELECT A.cdAluno, A.nmAluno FROM tblAluno A " +
             "INNER JOIN tblTurma T ON T.cdTurma = A.cdTurma " +
             "WHERE T.cdTurma = " + cdTurma + ";", con.conectarBD());

            DataSet ds = new DataSet();
            msda.Fill(ds);

            con.desconectarBD();

            List<TurmaAluno> lista = new List<TurmaAluno>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TurmaAluno item = new TurmaAluno();
                item.Cd_Aluno = int.Parse(dr["cdAluno"].ToString());
                item.Nm_Aluno = dr["nmAluno"].ToString();

                lista.Add(item);
            }
            return lista;
        }
        */

    }
}
