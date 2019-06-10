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

        public void VerificaLogin(Login login)
        {
            MySqlCommand cmd = new MySqlCommand
           ("CALL spVerificaLogin(@nmEmail,@nmSenha)", con.conectarBD());

            cmd.Parameters.Add("@nmEmail", MySqlDbType.VarChar).Value = login.NmEmail;
            cmd.Parameters.Add("@nmSenha", MySqlDbType.VarChar).Value = login.NmSenha;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }
    }
}
