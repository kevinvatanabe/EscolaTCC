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

    
    }
}
