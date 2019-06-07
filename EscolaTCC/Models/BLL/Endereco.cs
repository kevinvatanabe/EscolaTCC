using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Endereco
    {

        //Chave Primária
        [Key]
        [Display(Name = "Número do CEP")]
        public int No_Cep            { get; set; }

        //Dados do local
        [Display(Name = "Logradouro")]
        public String Nm_Logra       { get; set; }

        [Display(Name = "Nome do Bairro")]
        public String Nm_Bairro      { get; set; }

        [Display(Name = "Nome da Cidade")]
        public String Nm_Cidade      { get; set; }

        [Display(Name = "Unidade Federativa")]
        public String Sg_Uf          { get; set; }

       
        [Display(Name = "Complemento")]
        public String Ds_Comp        { get; set; }


        public void CadastroEndereco(Endereco end)
        {
            MySqlCommand cmd = new MySqlCommand
           ("CALL sp(@NO_CEP,@NM_Logra,@NO_End,@NM_Bairro,@NM_Cidade,@SG_Uf,@DS_Comp)", con.conectarBD());

            cmd.Parameters.Add("@NO_CEP", MySqlDbType.Int32).Value = end.No_Cep;
            cmd.Parameters.Add("@NM_Logra", MySqlDbType.VarChar).Value = end.Nm_Logra;
            cmd.Parameters.Add("@NO_End", MySqlDbType.Date).Value = end.No_End;
            cmd.Parameters.Add("@NM_Bairro", MySqlDbType.Int32).Value = end.Nm_Bairro;
            cmd.Parameters.Add("@NM_Cidade", MySqlDbType.Int32).Value = end.Nm_Cidade;
            cmd.Parameters.Add("@SG_Uf", MySqlDbType.VarChar).Value = end.Sg_Uf;
            cmd.Parameters.Add("@DS_Comp", MySqlDbType.VarChar).Value = end.Ds_Comp;
        
            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }
    }
}
