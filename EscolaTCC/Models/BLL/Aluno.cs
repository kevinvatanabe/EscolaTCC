using System;
using System.ComponentModel.DataAnnotations;

namespace EscolaTCC.Models
{
    public class Aluno
    {
        [Key]
        [Display(Name = "Código do Aluno")]
        public int Cd_Aluno      { get; set; }

        [Display(Name = "Nome do Aluno")]
        [Required(ErrorMessage = "Nome deve ser informado!")]
        public String Nm_Aluno   { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Data de nascimento deve ser informada!")]
        public DateTime Dt_NascAluno { get; set; }

        [Display(Name = "CPF")]
        public Int64 No_CpfAluno     { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "RG deve ser informado!")]
        public Int64 No_RgAluno { get; set; }

        [Display(Name = "Último Digito do RG")]
        [Required(ErrorMessage = "Último dígito do RG deve ser informado!")]
        public string Dig_RgAluno { get; set; }

        [Display(Name = "Nome do Pai")]
        public String Nm_Pai    { get; set; }

        [Display(Name = "Nome da Mãe")]
        [Required(ErrorMessage = "Nome da mãe deve ser informado!")]
        public String Nm_Mae    { get; set; }

        //Chave Estrangeira
        [Display(Name = "CPF do Responsável")]
        [Required(ErrorMessage = "CPF do responsável deve ser informado!")]
        public Int64 Cpf_Resp  { get; set; }

        [Display(Name = "Código da Turma")]
        [Required(ErrorMessage = "Código da turma deve ser informado!")]
        public int Cd_Turma { get; set; }

        //Atributos de Turma
        [Display(Name = "Nome da Turma")]
        public string nmTurma { get; set; }

        [Display(Name = "Período da Turma")]
        public string nmTurno { get; set; }

        [Display(Name = "Descrição da Turma")]
        public string dsSerie { get; set; }


    }
}
