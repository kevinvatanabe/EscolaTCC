using EscolaTCC.Models.BLL;
using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;

namespace EscolaTCC.Models.DAL
{
    public class FuncCargoDal
    {
        Conexao con = new Conexao();

        public string InsertFuncCargoNovo(Funcionario func, FuncCargo funcCargo, Login login, Cargo cargo)
        {
            MySqlCommand cmd = new MySqlCommand
           (
           "CALL sp_InsertFuncCargoNovo" +
           "(@v_noCpfFunc,   @v_dsFormacao," +
            "@v_noSalario,   @v_cdCargo," +
            "@v_nmEmail,     @v_nmSenha)", con.conectarBD());

            cmd.Parameters.AddWithValue("@v_noCpfFunc", MySqlDbType.Int64).Value = func.No_CpfFunc;
            cmd.Parameters.AddWithValue("@v_dsFormacao", MySqlDbType.VarChar).Value = funcCargo.dsFormacao;
            cmd.Parameters.AddWithValue("@v_noSalario", MySqlDbType.Int64).Value = funcCargo.No_Salario;
            cmd.Parameters.AddWithValue("@v_cdCargo", MySqlDbType.Int16).Value = cargo.CdCargo;
            cmd.Parameters.AddWithValue("@v_nmEmail", MySqlDbType.VarChar).Value = login.NmEmail;
            cmd.Parameters.AddWithValue("@v_nmSenha", MySqlDbType.VarChar).Value = login.NmSenha;

            string sucesso = Convert.ToString(cmd.ExecuteScalar());

            con.desconectarBD();

            return sucesso;
        }
    }
}
