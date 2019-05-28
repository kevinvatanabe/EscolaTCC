using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Aluno
    {
        //Conexão
        Conexao con = new Conexao();

        [Key]
        public int CD_Bene      { get; set; }

        [Display(Name = "Nome do Aluno")]
        public String NM_Bene   { get; set; }

        [Display(Name = "Data de Nascimento")]
        public int DT_Nasc_Bene { get; set; }

        [Display(Name = "CPF")]
        public int CPF_Bene     { get; set; }

        //Informações relativas ao Responsável
        //Acredito ser informação repetida
        public String NM_Pai    { get; set; }

        public String NM_Mae    { get; set; }

        //Chave Estrangeira
        public int CD_Resp      { get; set; }

        //CRUD
        public void CadastroAluno(Aluno aluno)
        {
            MySqlCommand cmd = new MySqlCommand
           ("INSERT INTO tblBeneficiario VALUES(@CD_Bene,@NM_Bene,@DT_Nasc_Bene,@CPF_Bene,@NM_Pai,@NM_Mae,@CD_Resp)", con.conectarBD());

            cmd.Parameters.Add("@CD_Bene",      MySqlDbType.Int32).Value = aluno.CD_Bene;
            cmd.Parameters.Add("@NM_Bene",      MySqlDbType.VarChar).Value = aluno.NM_Bene;
            cmd.Parameters.Add("@DT_Nasc_Bene", MySqlDbType.Date).Value = aluno.DT_Nasc_Bene;
            cmd.Parameters.Add("@CPF_Bene",     MySqlDbType.Int32).Value = aluno.CPF_Bene;
            cmd.Parameters.Add("@NM_Pai",       MySqlDbType.VarChar).Value = aluno.NM_Pai;
            cmd.Parameters.Add("@NM_Mae",       MySqlDbType.VarChar).Value = aluno.NM_Mae;
            cmd.Parameters.Add("@CD_Resp",      MySqlDbType.Int32).Value = aluno.CD_Resp;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }
    }
}
