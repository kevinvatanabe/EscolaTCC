using EscolaTCC.Models.BLL;
using EscolaTCC.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace EscolaTCC.Models.DAL
{
    public class FuncionarioDal
    {
        public string InsertFuncNovo(Funcionario func, FuncCargo funcCargo, Login login, int cdCargo)
        {
            Conexao con = new Conexao();

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

            string sucesso = Convert.ToString(cmd.ExecuteScalar());

            con.desconectarBD();
            return sucesso;
        }

        public List<Funcionario> SelectAllDiretores()
        {
            Conexao con = new Conexao();

            MySqlDataAdapter msda = new MySqlDataAdapter
           ("SELECT F.cdFunc, F.nmFunc, F.noCpfFunc, F.noRgFunc, F.Rg_DigFunc, F.noTelFunc, F.nmEmailFunc," +
             "F.noCepFunc, F.dtNascFunc, F.noEndFunc, F.dsCompleFunc," +
             "C.cdCargo, C.cdLogin, C.dsFormacao, C.noSalario "+
             "FROM tblfuncionario F "+
             "INNER JOIN tblFuncCargo C "+
             "ON F.cdFunc = C.cdFunc "+
             "WHERE C.cdCargo = 4;", con.conectarBD());

            DataSet ds = new DataSet();
            msda.Fill(ds);

            con.desconectarBD();

            List<Funcionario> lista = new List<Funcionario>();
            
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Funcionario item = new Funcionario();
                item.Cd_Func = int.Parse(dr["cdFunc"].ToString());
                item.Nm_Func = dr["nmFunc"].ToString();
                item.No_CpfFunc = Int64.Parse(dr["noCpffunc"].ToString());
                item.No_RgFunc = Int64.Parse(dr["noRgFunc"].ToString());
                item.Rg_DigFunc = dr["Rg_DigFunc"].ToString();
                item.No_TelFunc = Int64.Parse(dr["noTelFunc"].ToString());
                item.Nm_EmailFunc = dr["nmEmailFunc"].ToString();
                item.No_CepFunc = int.Parse(dr["noCepFunc"].ToString());
                item.Dt_NascFunc = DateTime.Parse(dr["dtNascFunc"].ToString());
                item.No_EndFunc = int.Parse(dr["noEndFunc"].ToString());
                item.Ds_CompleFunc = dr["dsCompleFunc"].ToString();
                //tabela tblFuncCargo na BLL Funcionario
                item.Cd_Cargo = int.Parse(dr["cdCargo"].ToString());
                item.Cd_Login = int.Parse(dr["cdLogin"].ToString());
                item.No_Salario = double.Parse(dr["noSalario"].ToString());
                item.Ds_Formacao = dr["dsFormacao"].ToString();


                lista.Add(item);
            }

            return lista;
        }

        public List<Funcionario> SelectAllProfessores()
        {
            Conexao con = new Conexao();

            MySqlDataAdapter msda = new MySqlDataAdapter
           ("SELECT F.cdFunc, F.nmFunc, F.noCpfFunc, F.noRgFunc, F.Rg_DigFunc, F.noTelFunc, F.nmEmailFunc," +
             "F.noCepFunc, F.dtNascFunc, F.noEndFunc, F.dsCompleFunc," +
             "C.cdCargo, C.cdLogin, C.dsFormacao, C.noSalario " +
             "FROM tblfuncionario F " +
             "INNER JOIN tblFuncCargo C " +
             "ON F.cdFunc = C.cdFunc " +
             "WHERE C.cdCargo = 1;", con.conectarBD());

            DataSet ds = new DataSet();
            msda.Fill(ds);

            con.desconectarBD();

            List<Funcionario> lista = new List<Funcionario>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Funcionario item = new Funcionario();
                item.Cd_Func = int.Parse(dr["cdFunc"].ToString());
                item.Nm_Func = dr["nmFunc"].ToString();
                item.No_CpfFunc = Int64.Parse(dr["noCpffunc"].ToString());
                item.No_RgFunc = Int64.Parse(dr["noRgFunc"].ToString());
                item.Rg_DigFunc = dr["Rg_DigFunc"].ToString();
                item.No_TelFunc = Int64.Parse(dr["noTelFunc"].ToString());
                item.Nm_EmailFunc = dr["nmEmailFunc"].ToString();
                item.No_CepFunc = int.Parse(dr["noCepFunc"].ToString());
                item.Dt_NascFunc = DateTime.Parse(dr["dtNascFunc"].ToString());
                item.No_EndFunc = int.Parse(dr["noEndFunc"].ToString());
                item.Ds_CompleFunc = dr["dsCompleFunc"].ToString();
                //tabela tblFuncCargo na BLL Funcionario
                item.Cd_Cargo = int.Parse(dr["cdCargo"].ToString());
                item.Cd_Login = int.Parse(dr["cdLogin"].ToString());
                item.No_Salario = int.Parse(dr["noSalario"].ToString());
                item.Ds_Formacao = dr["dsFormacao"].ToString();


                lista.Add(item);
            }

            return lista;
        }

        public List<Funcionario> SelectAllSecretaria()
        {
            Conexao con = new Conexao();

            MySqlDataAdapter msda = new MySqlDataAdapter
            ("SELECT F.cdFunc, F.nmFunc, F.noCpfFunc, F.noRgFunc, F.Rg_DigFunc, F.noTelFunc, F.nmEmailFunc," +
             "F.noCepFunc, F.dtNascFunc, F.noEndFunc, F.dsCompleFunc," +
             "C.cdCargo, C.cdLogin, C.dsFormacao, C.noSalario " +
             "FROM tblfuncionario F " +
             "INNER JOIN tblFuncCargo C " +
             "ON F.cdFunc = C.cdFunc " +
             "WHERE C.cdCargo = 3;", con.conectarBD());

            DataSet ds = new DataSet();
            msda.Fill(ds);

            con.desconectarBD();

            List<Funcionario> lista = new List<Funcionario>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Funcionario item = new Funcionario();
                item.Cd_Func = int.Parse(dr["cdFunc"].ToString());
                item.Nm_Func = dr["nmFunc"].ToString();
                item.No_CpfFunc = Int64.Parse(dr["noCpffunc"].ToString());
                item.No_RgFunc = Int64.Parse(dr["noRgFunc"].ToString());
                item.Rg_DigFunc = dr["Rg_DigFunc"].ToString();
                item.No_TelFunc = Int64.Parse(dr["noTelFunc"].ToString());
                item.Nm_EmailFunc = dr["nmEmailFunc"].ToString();
                item.No_CepFunc = int.Parse(dr["noCepFunc"].ToString());
                item.Dt_NascFunc = DateTime.Parse(dr["dtNascFunc"].ToString());
                item.No_EndFunc = int.Parse(dr["noEndFunc"].ToString());
                item.Ds_CompleFunc = dr["dsCompleFunc"].ToString();
                //tabela tblFuncCargo na BLL Funcionario
                item.Cd_Cargo = int.Parse(dr["cdCargo"].ToString());
                item.Cd_Login = int.Parse(dr["cdLogin"].ToString());
                item.No_Salario = int.Parse(dr["noSalario"].ToString());
                item.Ds_Formacao = dr["dsFormacao"].ToString();


                lista.Add(item);
            }

            return lista;
        }

        public Funcionario SelectOneDiretor(Int64 cpf)
        {
            Conexao con = new Conexao();

            MySqlDataAdapter msda = new MySqlDataAdapter
            ("SELECT F.cdFunc, F.nmFunc, F.noCpfFunc, F.noRgFunc, F.Rg_DigFunc, F.noTelFunc, F.nmEmailFunc," +
             "F.noCepFunc, F.dtNascFunc, F.noEndFunc, F.dsCompleFunc," +
             "C.cdCargo, C.cdLogin, C.dsFormacao, C.noSalario " +
             "FROM tblfuncionario F " +
             "INNER JOIN tblFuncCargo C " +
             "ON F.cdFunc = C.cdFunc " +
             "WHERE C.cdCargo = 4 AND F.noCpfFunc = " + cpf + ";", con.conectarBD());
            DataSet ds = new DataSet();
            msda.Fill(ds);

            con.desconectarBD();

            List<Funcionario> lista = new List<Funcionario>();

            Funcionario item = new Funcionario();
            if (ds.Tables[0].Rows.Count > 0)
            {
                item.Cd_Func = int.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Nm_Func = ds.Tables[0].Rows[0]["nmFunc"].ToString();
                item.No_CpfFunc = Int64.Parse(ds.Tables[0].Rows[0]["noCpffunc"].ToString());
                item.No_RgFunc = Int64.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Rg_DigFunc = ds.Tables[0].Rows[0]["cdFunc"].ToString();
                item.No_TelFunc = Int64.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Nm_EmailFunc = ds.Tables[0].Rows[0]["cdFunc"].ToString();
                item.No_CepFunc = int.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Dt_NascFunc = DateTime.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.No_EndFunc = int.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Ds_CompleFunc = ds.Tables[0].Rows[0]["cdFunc"].ToString();
                //tabela tblFuncCargo na BLL Funcionario
                item.Cd_Cargo = int.Parse(ds.Tables[0].Rows[0]["cdCargo"].ToString());
                item.Cd_Login = int.Parse(ds.Tables[0].Rows[0]["cdLogin"].ToString());
                item.No_Salario = double.Parse(ds.Tables[0].Rows[0]["noSalario"].ToString());
                item.Ds_Formacao = ds.Tables[0].Rows[0]["dsFormacao"].ToString();
            }

            return item;
        }

        public Funcionario SelectOneProfessor(Int64 cpf)
        {
            Conexao con = new Conexao();

            MySqlDataAdapter msda = new MySqlDataAdapter
            ("SELECT F.cdFunc, F.nmFunc, F.noCpfFunc, F.noRgFunc, F.Rg_DigFunc, F.noTelFunc, F.nmEmailFunc," +
             "F.noCepFunc, F.dtNascFunc, F.noEndFunc, F.dsCompleFunc," +
             "C.cdCargo, C.cdLogin, C.dsFormacao, C.noSalario " +
             "FROM tblfuncionario F " +
             "INNER JOIN tblFuncCargo C " +
             "ON F.cdFunc = C.cdFunc " +
             "WHERE C.cdCargo = 1 AND F.noCpfFunc = " + cpf + ";", con.conectarBD());
            DataSet ds = new DataSet();
            msda.Fill(ds);

            con.desconectarBD();

            List<Funcionario> lista = new List<Funcionario>();

            Funcionario item = new Funcionario();
            if (ds.Tables[0].Rows.Count > 0)
            {
                item.Cd_Func = int.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Nm_Func = ds.Tables[0].Rows[0]["nmFunc"].ToString();
                item.No_CpfFunc = Int64.Parse(ds.Tables[0].Rows[0]["noCpffunc"].ToString());
                item.No_RgFunc = Int64.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Rg_DigFunc = ds.Tables[0].Rows[0]["cdFunc"].ToString();
                item.No_TelFunc = Int64.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Nm_EmailFunc = ds.Tables[0].Rows[0]["cdFunc"].ToString();
                item.No_CepFunc = int.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Dt_NascFunc = DateTime.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.No_EndFunc = int.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Ds_CompleFunc = ds.Tables[0].Rows[0]["cdFunc"].ToString();
                //tabela tblFuncCargo na BLL Funcionario
                item.Cd_Cargo = int.Parse(ds.Tables[0].Rows[0]["cdCargo"].ToString());
                item.Cd_Login = int.Parse(ds.Tables[0].Rows[0]["cdLogin"].ToString());
                item.No_Salario = double.Parse(ds.Tables[0].Rows[0]["noSalario"].ToString());
                item.Ds_Formacao = ds.Tables[0].Rows[0]["dsFormacao"].ToString();
            }

            return item;
        }

        public Funcionario SelectOneSecretaria(Int64 cpf)
        {
            Conexao con = new Conexao();

            MySqlDataAdapter msda = new MySqlDataAdapter
            ("SELECT F.cdFunc, F.nmFunc, F.noCpfFunc, F.noRgFunc, F.Rg_DigFunc, F.noTelFunc, F.nmEmailFunc," +
             "F.noCepFunc, F.dtNascFunc, F.noEndFunc, F.dsCompleFunc," +
             "C.cdCargo, C.cdLogin, C.dsFormacao, C.noSalario " +
             "FROM tblfuncionario F " +
             "INNER JOIN tblFuncCargo C " +
             "ON F.cdFunc = C.cdFunc " +
             "WHERE C.cdCargo = 3 AND F.noCpfFunc = " + cpf + ";", con.conectarBD());
            DataSet ds = new DataSet();
            msda.Fill(ds);

            con.desconectarBD();

            List<Funcionario> lista = new List<Funcionario>();

            Funcionario item = new Funcionario();
            if (ds.Tables[0].Rows.Count > 0)
            {
                item.Cd_Func = int.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Nm_Func = ds.Tables[0].Rows[0]["nmFunc"].ToString();
                item.No_CpfFunc = Int64.Parse(ds.Tables[0].Rows[0]["noCpffunc"].ToString());
                item.No_RgFunc = Int64.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Rg_DigFunc = ds.Tables[0].Rows[0]["cdFunc"].ToString();
                item.No_TelFunc = Int64.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Nm_EmailFunc = ds.Tables[0].Rows[0]["cdFunc"].ToString();
                item.No_CepFunc = int.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Dt_NascFunc = DateTime.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.No_EndFunc = int.Parse(ds.Tables[0].Rows[0]["cdFunc"].ToString());
                item.Ds_CompleFunc = ds.Tables[0].Rows[0]["cdFunc"].ToString();
                //tabela tblFuncCargo na BLL Funcionario
                item.Cd_Cargo = int.Parse(ds.Tables[0].Rows[0]["cdCargo"].ToString());
                item.Cd_Login = int.Parse(ds.Tables[0].Rows[0]["cdLogin"].ToString());
                item.No_Salario = double.Parse(ds.Tables[0].Rows[0]["noSalario"].ToString());
                item.Ds_Formacao = ds.Tables[0].Rows[0]["dsFormacao"].ToString();
            }

            return item;
        }
    }
}
