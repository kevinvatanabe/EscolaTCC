using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.DAL
{
    public class EnderecoDal
    {
        Conexao con = new Conexao();

        public string CadastroEndereco(Endereco end)
        {
            MySqlCommand cmd = new MySqlCommand
           ("CALL sp_InsertEndereco(@NO_CEP,@NM_Logra,@NM_Bairro,@NM_Cidade,@SG_Uf)", con.conectarBD());

            cmd.Parameters.AddWithValue("@NO_CEP",    MySqlDbType.Int64).Value   = end.No_Cep;
            cmd.Parameters.AddWithValue("@NM_Logra",  MySqlDbType.VarChar).Value = end.Nm_Logra;
            cmd.Parameters.AddWithValue("@NM_Bairro", MySqlDbType.VarChar).Value = end.Nm_Bairro;
            cmd.Parameters.AddWithValue("@NM_Cidade", MySqlDbType.VarChar).Value = end.Nm_Cidade;
            cmd.Parameters.AddWithValue("@SG_Uf",     MySqlDbType.VarChar).Value = end.Sg_Uf;

            string sucesso = Convert.ToString(cmd.ExecuteScalar());

            con.desconectarBD();

            return sucesso;
        }
    }
}
