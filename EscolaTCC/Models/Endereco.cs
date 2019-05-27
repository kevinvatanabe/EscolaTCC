using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Endereco
    {
        //Conexão
        Conexao con = new Conexao();

        //Chave Primária
        public int NO_CEP            { get; set; }

        //Dados do local
        public String NM_Logra       { get; set; }
        public int NO_End            { get; set; }
        public String NM_Bairro      { get; set; }
        public String NM_Cidade      { get; set; }
        public String SG_Uf          { get; set; }

        //Precisa deste?
        public String DS_Comp        { get; set; }

        public void CadastroEndereco(Endereco end)
        {
            MySqlCommand cmd = new MySqlCommand
           ("INSERT INTO tblEndereco VALUES(@NO_CEP,@NM_Logra,@NO_End,@NM_Bairro,@NM_Cidade,@SG_Uf,@DS_Comp)", con.conectarBD());

            cmd.Parameters.Add("@NO_CEP", MySqlDbType.Int32).Value = end.NO_CEP;
            cmd.Parameters.Add("@NM_Logra", MySqlDbType.VarChar).Value = end.NM_Logra;
            cmd.Parameters.Add("@NO_End", MySqlDbType.Date).Value = end.NO_End;
            cmd.Parameters.Add("@NM_Bairro", MySqlDbType.Int32).Value = end.NM_Bairro;
            cmd.Parameters.Add("@NM_Cidade", MySqlDbType.Int32).Value = end.NM_Cidade;
            cmd.Parameters.Add("@SG_Uf", MySqlDbType.VarChar).Value = end.SG_Uf;
            cmd.Parameters.Add("@DS_Comp", MySqlDbType.VarChar).Value = end.DS_Comp;
        
            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }
    }
}
