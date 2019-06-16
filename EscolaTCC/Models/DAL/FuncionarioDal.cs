using EscolaTCC.Models.BLL;
using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;

namespace EscolaTCC.Models.DAL
{
    public class FuncionarioDal
    {
        Conexao con = new Conexao();

        public string InsertFuncNovo(Funcionario func, FuncCargo funcCargo, Login login, int cdCargo)
        {
            MySqlCommand cmd = new MySqlCommand
           (
           "CALL sp_InsertFuncNovo" +
           "(@v_noCep," +
            "@v_nmFunc,      @v_noCpfFunc,@v_noRgFunc," +
            "@v_Rg_DigFunc,  @v_noTelFunc,@v_noSalario," +
            "@v_dtNascFunc,  @v_cdCargo,  @v_dsFormacao," +
            "@v_dsCompleFunc,@v_noEndFunc,@v_nmEmailFunc," +
            "@v_nmEmail,     @v_nmSenha)", con.conectarBD());

            cmd.Parameters.AddWithValue("@v_noCep", MySqlDbType.Int64).Value = func.No_CepFunc;
            cmd.Parameters.AddWithValue("@v_nmFunc", MySqlDbType.VarChar).Value = func.Nm_Func;
            cmd.Parameters.AddWithValue("@v_noCpfFunc", MySqlDbType.Int64).Value = func.No_CpfFunc;
            cmd.Parameters.AddWithValue("@v_noRgFunc", MySqlDbType.Int64).Value = func.No_RgFunc;
            cmd.Parameters.AddWithValue("@v_Rg_DigFunc", MySqlDbType.VarChar).Value = func.Rg_DigFunc;
            cmd.Parameters.AddWithValue("@v_noTelFunc", MySqlDbType.VarChar).Value = func.No_TelFunc;
            cmd.Parameters.AddWithValue("@v_noSalario", MySqlDbType.Int64).Value = funcCargo.No_Salario;
            cmd.Parameters.AddWithValue("@v_dtNascFunc", MySqlDbType.Date).Value = func.Dt_NascFunc;
            cmd.Parameters.AddWithValue("@v_cdCargo", MySqlDbType.Int16).Value = cdCargo;
            cmd.Parameters.AddWithValue("@v_dsFormacao", MySqlDbType.VarChar).Value = funcCargo.dsFormacao;
            cmd.Parameters.AddWithValue("@v_dsCompleFunc", MySqlDbType.VarChar).Value = func.Ds_CompleFunc;
            cmd.Parameters.AddWithValue("@v_noEndFunc", MySqlDbType.Int64).Value = func.No_EndFunc;
            cmd.Parameters.AddWithValue("@v_nmEmailFunc", MySqlDbType.VarChar).Value = func.Nm_EmailFunc;
            cmd.Parameters.AddWithValue("@v_nmEmail", MySqlDbType.VarChar).Value = login.NmEmail;
            cmd.Parameters.AddWithValue("@v_nmSenha", MySqlDbType.VarChar).Value = login.NmSenha;

            string sucesso2 = Convert.ToString(cmd.ExecuteScalar());

            con.desconectarBD();

            return sucesso2;
        }
    }
}
