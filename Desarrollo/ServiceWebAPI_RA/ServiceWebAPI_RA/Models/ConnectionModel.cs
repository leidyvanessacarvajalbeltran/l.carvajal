using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServiceWebAPI_RA.Models
{
    public class ConnectionModel
    {
        Procedimiento obj;
        public ConnectionModel()
        {
            obj = new Procedimiento();
        }

        SqlConnection cnx = new SqlConnection();
        private SqlCommand cmd;

        /*Verifica el estado de la disponibilidad de la bd*/
        public string TestConnection()
        {
            string conexion = string.Empty;
            try
            {

                conexion = ConfigurationManager.ConnectionStrings["cnxString"].ConnectionString;
                using (cnx = new SqlConnection(conexion))
                {
                    if (cnx.State != ConnectionState.Open) { cnx.Open(); /*Console.WriteLine("Test de Conexión Exitoso"); */ conexion = "Test de Conexión Exitoso"; }
                }
            }
            catch (Exception ex) {
                conexion = "Test de Conexión Fallido:" + ex.Message.ToString() + ". Verifique si el servidor de Base de Datos esta encendido.";
                /*Console.WriteLine("Test de Conexión Fallido:" + ex.Message.ToString() + ". Verifique si el servidor de Base de Datos esta encendido."); */}
            return conexion;
        }

        /*Optiene las credenciales de conexion de la bd, guardadas en el webconfig*/
        public string getConnection()
        {
            return ConfigurationManager.ConnectionStrings["cnxString"].ConnectionString;
        }

        /*Metodo el cual invoca la función FN_CARGARINFORMACION almacenada en la base de datos*/
        public DataTable getInformacionEstudiante()
        {
            DataTable dtemployees = new DataTable();
            SqlConnection con = new SqlConnection(getConnection());
            try
            {

                string query = string.Format("SELECT * FROM FN_INFORMACIONESTUDIANTE()");
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter READER = new SqlDataAdapter();
                READER.SelectCommand = cmd;
                READER.Fill(dtemployees);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dtemployees;
        }

        public DataTable ConsultarEjercicios()
        {
            DataTable dtemployees = new DataTable();
            SqlConnection con = new SqlConnection(getConnection());
            try
            {

                string query = string.Format("SELECT * FROM FN_EJERCICIOS()");
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter READER = new SqlDataAdapter();
                READER.SelectCommand = cmd;
                READER.Fill(dtemployees);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dtemployees;
        }

        public DataTable getInformacionComponente(int id)
        {
            DataTable dtemployees = new DataTable();
            SqlConnection con = new SqlConnection(getConnection());
            try
            {

                string query = string.Format("SELECT * FROM FN_INFORMACIONCOMPONENTES('{0}')", id);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter READER = new SqlDataAdapter();
                READER.SelectCommand = cmd;
                READER.Fill(dtemployees);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dtemployees;
        }

        public DataTable ConsultarSolucion(string id)
        {
            DataTable dtemployees = new DataTable();
            SqlConnection con = new SqlConnection(getConnection());
            try
            {

                string query = string.Format("SELECT * FROM FN_INFORMACIONCOMPONENTES('{0}')", id);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter READER = new SqlDataAdapter();
                READER.SelectCommand = cmd;
                READER.Fill(dtemployees);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dtemployees;
        }

        public string GuardarInformacion(string ESTU_ID, string identificacion, string pnombre, string snombre, string papellido, string spaellido, string correo)
        {
            
            SqlConnection con = new SqlConnection(getConnection());
            try
            {
                List<PAPROAD> objdatos = new List<PAPROAD>();                

                objdatos.Add(new PAPROAD("@ESTU_ID", ESTU_ID, "NUMBER", System.Data.ParameterDirection.Input));
                objdatos.Add(new PAPROAD("@IDENTI", identificacion, "VARCHAR2", System.Data.ParameterDirection.Input));
                objdatos.Add(new PAPROAD("@PNOMB", pnombre.ToUpper(), "VARCHAR2", System.Data.ParameterDirection.Input));
                objdatos.Add(new PAPROAD("@SNOM", snombre.Equals("") ? null : snombre.ToUpper(), "VARCHAR2", System.Data.ParameterDirection.Input));
                objdatos.Add(new PAPROAD("@PAPE", papellido.ToUpper(), "VARCHAR2", System.Data.ParameterDirection.Input));
                objdatos.Add(new PAPROAD("@SAPE", spaellido.Equals("") ? null : spaellido.ToUpper(), "VARCHAR2", System.Data.ParameterDirection.Input));
                objdatos.Add(new PAPROAD("@EMAIL", correo.ToUpper().Equals("") ? null : correo, "VARCHAR2", System.Data.ParameterDirection.Input));

                objdatos.Add(new PAPROAD("@result", null, null, System.Data.ParameterDirection.Output));

                return EjecutarProcedimientoDML("PR_GESTIONARESTUDIANTE", objdatos);

            }
            catch { throw; }
        }

        public string GuardarEvaluacion(string ESTU_ID,string ejer_id,string evaluacion)
        {

            SqlConnection con = new SqlConnection(getConnection());
            try
            {
                List<PAPROAD> objdatos = new List<PAPROAD>();

                //objdatos.Add(new PAPROAD("@ESTU_ID", ESTU_ID, "NUMBER", System.Data.ParameterDirection.Input));
                //objdatos.Add(new PAPROAD("@IDENTI", identificacion, "VARCHAR2", System.Data.ParameterDirection.Input));
                //objdatos.Add(new PAPROAD("@PNOMB", pnombre.ToUpper(), "VARCHAR2", System.Data.ParameterDirection.Input));
                //objdatos.Add(new PAPROAD("@SNOM", snombre.Equals("") ? null : snombre.ToUpper(), "VARCHAR2", System.Data.ParameterDirection.Input));
                //objdatos.Add(new PAPROAD("@PAPE", papellido.ToUpper(), "VARCHAR2", System.Data.ParameterDirection.Input));
                //objdatos.Add(new PAPROAD("@SAPE", spaellido.Equals("") ? null : spaellido.ToUpper(), "VARCHAR2", System.Data.ParameterDirection.Input));
                //objdatos.Add(new PAPROAD("@EMAIL", correo.ToUpper().Equals("") ? null : correo, "VARCHAR2", System.Data.ParameterDirection.Input));

                objdatos.Add(new PAPROAD("@result", null, null, System.Data.ParameterDirection.Output));

                return EjecutarProcedimientoDML("PR_GESTIONARESTUDIANTE", objdatos);

            }
            catch { throw; }
        }

        public string EjecutarProcedimientoDML(string procedimiento, List<PAPROAD> parametros)
        {
            obj = new Procedimiento();
            string resultado = "";
            obj.CadenaConexion = this.getConnection();
            obj.Nombre = procedimiento;
            try
            {
                #region Parametros
                foreach (PAPROAD p in parametros)
                {
                    obj.crear_parametro(p.Nombre, p.Valor, p.Tipo, p.Size, p.Direccion);
                }
                #endregion
                resultado = obj.Ejecutar_Sql();
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
    }
}