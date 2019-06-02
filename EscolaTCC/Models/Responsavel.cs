﻿using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaTCC.Models
{
    public class Responsavel
    {
        //Conexão
        Conexao con = new Conexao();

        //Informações básicas
        [Key]
        public int CD_Resp           { get; set; }

        [Display(Name = "Nome do Responsável")]
        public String NM_Resp        { get; set; }

        [Display(Name = "Data de Nascimento")]
        public int Dt_Nasc_Resp      { get; set; }

        //Números Importantes
        [Display(Name = "CPF")]
        public int NO_CPF_Resp       { get; set; }

        [Display(Name = "RG")]
        public int NO_RG_Resp        { get; set; }

        [Display(Name = "Último dígito do RG")]
        public int Dig_RG_Resp       { get; set; }


        //Contato
        [Display(Name = "E-mail")]
        public String NM_Email_Resp  { get; set; }

        [Display(Name = "Telefone")]
        public int NO_Tel_Resp       { get; set; }

        //Endereço
        //Chave Estrangeira
        [Display(Name = "CEP do Responsável")]
        public Endereco CEP_End      { get; set; }


        //CRUD
        public void CadastroResponsavel(Responsavel resp)
        {
            MySqlCommand cmd = new MySqlCommand
           ("INSERT INTO tblResponsavel VALUES(@CD_Resp,@NM_Resp,@Dt_Nasc_Resp,@NO_CPF_Resp,@NO_RG_Resp,@Dig_RG_Resp,@NM_Email_Resp,@NO_Tel_Resp,@CEP_End)", con.conectarBD());

            cmd.Parameters.Add("@CD_Resp",       MySqlDbType.Int32).Value =     resp.CD_Resp;
            cmd.Parameters.Add("@NM_Resp",       MySqlDbType.VarChar).Value =   resp.NM_Resp;
            cmd.Parameters.Add("@Dt_Nasc_Resp",  MySqlDbType.Date).Value =      resp.Dt_Nasc_Resp;
            cmd.Parameters.Add("@NO_CPF_Resp",   MySqlDbType.Int32).Value =     resp.NO_CPF_Resp;
            cmd.Parameters.Add("@NO_RG_Resp",    MySqlDbType.Int32).Value =     resp.NO_RG_Resp;
            cmd.Parameters.Add("@Dig_RG_Resp",   MySqlDbType.VarChar).Value =   resp.Dig_RG_Resp;
            cmd.Parameters.Add("@NM_Email_Resp", MySqlDbType.VarChar).Value =   resp.NM_Email_Resp;
            cmd.Parameters.Add("@NO_Tel_Resp",   MySqlDbType.Int32).Value =     resp.NO_Tel_Resp;
            cmd.Parameters.Add("@CEP_End",       MySqlDbType.Int32).Value =     resp.CEP_End;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }
    }
}