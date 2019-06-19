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
        [Display(Name = "Código do Aluno")]
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
        public String Nm_Pai    { get; set; }

        [Display(Name = "Nome da Mãe")]
        public String Nm_Mae    { get; set; }

        //Chave Estrangeira
        //Associação
        [Display(Name = "CPF do Responsável")]
        public int Cd_Resp  { get; set; }

        [Display(Name = "Código da Turma")]
        public int Cd_Turma { get; set; }

    
    }
}
