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


        [Key]
        public int Cd_Aluno      { get; set; }

        [Display(Name = "Nome do Aluno")]
        public String Nm_Aluno   { get; set; }

        [Display(Name = "Data de Nascimento")]
        public int Dt_NascAluno { get; set; }

        [Display(Name = "CPF")]
        public int No_CpfAluno     { get; set; }

        [Display(Name = "RG")]
        public int No_RgAluno { get; set; }

        [Display(Name = "Último Digito do RG")]
        public int Dig_RgAluno { get; set; }

        [Display(Name = "Nome do Pai")]
        //Informações relativas ao Responsável
        public String Nm_Pai    { get; set; }

        [Display(Name = "Nome da Mãe")]
        public String Nm_Mae    { get; set; }

        //Chave Estrangeira
        //Associação
        public int Cd_Resp  { get; set; }

        public int Cd_Turma { get; set; }

        //CRUD
        public void CadastroAluno(Aluno aluno)
        {
            MySqlCommand cmd = new MySqlCommand
           ("INSERT INTO tblBeneficiario VALUES(@CD_Bene,@NM_Bene,@DT_Nasc_Bene,@CPF_Bene,@NM_Pai,@NM_Mae,@CD_Resp)", con.conectarBD());

            cmd.Parameters.Add("@CD_Bene",      MySqlDbType.Int32).Value = aluno.CD_Bene;
            cmd.Parameters.Add("@NM_Bene",      MySqlDbType.VarChar).Value = aluno.Nm_Bene;
            cmd.Parameters.Add("@DT_Nasc_Bene", MySqlDbType.Date).Value = aluno.Dt_NascBene;
            cmd.Parameters.Add("@CPF_Bene",     MySqlDbType.Int32).Value = aluno.Cpf_Bene;
            cmd.Parameters.Add("@NM_Pai",       MySqlDbType.VarChar).Value = aluno.Nm_Pai;
            cmd.Parameters.Add("@NM_Mae",       MySqlDbType.VarChar).Value = aluno.Nm_Mae;
            cmd.Parameters.Add("@CD_Resp",      MySqlDbType.Int32).Value = aluno.Cd_Resp;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }
    }
}
