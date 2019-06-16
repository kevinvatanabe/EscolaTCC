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
        [Required(ErrorMessage = "Informe o CEP!")]
        public int No_Cep            { get; set; }

        //Dados do local
        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "Informe o nome do endereço!")]
        public String Nm_Logra       { get; set; }

        [Display(Name = "Nome do Bairro")]
        [Required(ErrorMessage = "Informe o nome do bairro!")]
        public String Nm_Bairro      { get; set; }

        [Display(Name = "Nome da Cidade")]
        [Required(ErrorMessage = "Informe o nome da cidade!")]
        public String Nm_Cidade      { get; set; }

        [Display(Name = "Unidade Federativa")]
        [Required(ErrorMessage = "Informe a sigla do Estado!")]
        public String Sg_Uf          { get; set; }

    }
}
