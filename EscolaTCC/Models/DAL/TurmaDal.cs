using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.DAL
{
    public class TurmaDal
    {
        Conexao con = new Conexao();

        public string CadastroTurma(Turma turma)
        {
            MySqlCommand cmd = new MySqlCommand
           ("CALL sp_insertTurma(@NM_Turma,@NM_Turno,@DS_Serie)", con.conectarBD());

            cmd.Parameters.AddWithValue("@NM_Turma", MySqlDbType.VarChar).Value = turma.nmTurma;
            cmd.Parameters.AddWithValue("@NM_Turno", MySqlDbType.VarChar).Value = turma.nmTurno;
            cmd.Parameters.AddWithValue("@DS_Serie", MySqlDbType.VarChar).Value = turma.dsSerie;

            string sucesso = Convert.ToString(cmd.ExecuteScalar());

            con.desconectarBD();

            return sucesso;
        }

        public List<Turma> SelectAll()
        {
             Conexao con = new Conexao();
             MySqlCommand msc = new MySqlCommand("Select * from tblturma", con.conectarBD());
             MySqlDataAdapter adapter = new MySqlDataAdapter(msc);
             DataSet ds = new DataSet();
             adapter.Fill(ds);

            List<Turma> listTurma = new List<Turma>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Turma turma = new Turma();
                turma.cdTurma = int.Parse(dr["cdTurma"].ToString());
                turma.nmTurma = dr["nmTurma"].ToString();
                turma.nmTurma = dr["nmTurno"].ToString();
                turma.dsSerie = dr["dsSerie"].ToString();
                listTurma.Add(turma);
            }

            return listTurma;
        }
    }
}

