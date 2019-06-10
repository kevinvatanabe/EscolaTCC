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

        public void CadastroEndereco(Endereco end)
        {
            MySqlCommand cmd = new MySqlCommand
           ("CALL spInsereEndereco(@NO_CEP,@NM_Logra,@NM_Bairro,@NM_Cidade,@SG_Uf,@DS_Comp)", con.conectarBD());

            cmd.Parameters.Add("@NO_CEP", MySqlDbType.Int32).Value = end.No_Cep;
            cmd.Parameters.Add("@NM_Logra", MySqlDbType.VarChar).Value = end.Nm_Logra;
            cmd.Parameters.Add("@NM_Bairro", MySqlDbType.Int32).Value = end.Nm_Bairro;
            cmd.Parameters.Add("@NM_Cidade", MySqlDbType.Int32).Value = end.Nm_Cidade;
            cmd.Parameters.Add("@SG_Uf", MySqlDbType.VarChar).Value = end.Sg_Uf;
            cmd.Parameters.Add("@DS_Comp", MySqlDbType.VarChar).Value = end.Ds_Comp;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }
    }
}
