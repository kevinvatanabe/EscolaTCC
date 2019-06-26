using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models.BLL
{
    public class TurmaProfessor
    {
            [Display(Name = "Número")]
            public int Contador { get; set; }

        //Descrição da Turma
            [Display(Name = "Código da Turma")]
            public int Cd_Turma { get; set; }

            [Display(Name = "Descrição da série da Turma")]
            public String dsSerie { get; set; }

        [Display(Name = "Descrição da série da Turma")]
        public String Nm_Turma { get; set; }


        //tblAluno
        [Display(Name = "Código do Aluno")]
        public int Cd_Aluno { get; set; }

        [Display(Name = "Nome do Aluno")]
        public String Nm_Aluno { get; set; }

       
        //Informações do Professor
        [Display(Name = "Código do Funcionário")]
        public int Cd_Func{ get; set; }

        [Display(Name = "CPF do Professor")]
            public Int64 Cpf_Prof { get; set; }

            [Display(Name = "Nome do Professor")]
            public String Nm_Professor { get; set; }

        //MatProf
        public int Cd_MatProf { get; set; }
        [Display(Name = "Nome da matéria")]
            public String Nm_Materia { get; set; }

    
    }
}
