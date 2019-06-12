using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.DAL
{
    public class LoginDal
    {
        Conexao con = new Conexao();

        public string VerificaUsuario(Login login)
        {
            MySqlCommand cmd = new MySqlCommand
           ("CALL sp_VerificaUsuario(@nmEmail,@nmSenha,@cdAutorizacao)", con.conectarBD());

            cmd.Parameters.AddWithValue("@nmEmail",       MySqlDbType.VarChar).Value = login.NmEmail;
            cmd.Parameters.AddWithValue("@nmSenha",       MySqlDbType.VarChar).Value = login.NmSenha;
            cmd.Parameters.AddWithValue("@cdAutorizacao", MySqlDbType.VarChar).Value = login.CdAutorizacao;

            string sucesso = Convert.ToString(cmd.ExecuteScalar());
           
            con.desconectarBD();

            return sucesso;
        }
    }
}
