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

    }
}
