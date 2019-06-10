using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.Data
{
    public class Conexao
    {
        public static string msg;

        MySqlConnection con = new MySqlConnection(@"server=localhost;userid=root;password=1234567;database=dbescola");

        public MySqlConnection conectarBD()
        {
            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                msg = "Erro na Conexão";
            }
            return con;
        }

        public MySqlConnection desconectarBD()
        {
            try
            {
                con.Close();
            }
            catch (Exception e)
            {
                msg = "Erro na Desconexão";
            }
            return con;
        }
    }
}
