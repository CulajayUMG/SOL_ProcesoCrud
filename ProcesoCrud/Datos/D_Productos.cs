using ProcesoCrud.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesoCrud.Datos
{
    public class D_Productos
    {
        public DataTable Listado_prod(string cTexto) {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LISTADO_PROD", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto",SqlDbType.VarChar).Value = cTexto; 
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();   
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { 
            if(SqlCon.State == ConnectionState.Open)SqlCon.Close();
            }

        }

        public string Guardar_Prod(int nOpcion, E_Productos oPro) {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_GUARDAR_PROD",SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Opcion", SqlDbType.Int).Value = nOpcion;
                Comando.Parameters.Add("@nCodigo_prod", SqlDbType.Int).Value = oPro.Codigo_Prod;
                Comando.Parameters.Add("@cDescripcion_prod", SqlDbType.VarChar).Value = oPro.Descripcion_prod;
                Comando.Parameters.Add("@cMarca_Prod", SqlDbType.VarChar).Value = oPro.Marca_prod;
                //Comando.Parameters.Add("@nCodigo_prod", SqlDbType.Int).Value = oPro.Codigo_Prod;
                Comando.Parameters.Add("@nCodigo_med", SqlDbType.Int).Value = oPro.Codigo_med;
                Comando.Parameters.Add("@nCodigo_cat", SqlDbType.Int).Value = oPro.Codigo_cat;
                Comando.Parameters.Add("@nStock_actual", SqlDbType.Decimal).Value = oPro.Stock_actual;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "Guardado Correctamente":"NO SE PUDO GUARDAR LOS DATOS";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return Rpta;
        
        
        }

        public string Activo_prod(int nCodigo_prod, bool bEstado_Activo) {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ACTIVO_PROD", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nCodigo_prod", SqlDbType.Int).Value = nCodigo_prod;
                Comando.Parameters.Add("@bEstado_activo", SqlDbType.Bit).Value = bEstado_Activo;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "CORRECTO" : "NO SE PUDO CAMBIAR EL ESTADO DE PRODUCTO";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return Rpta;

        }

        public DataTable Listado_med()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LISTADO_MED", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

        }
        public DataTable Listado_cat()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LISTADO_CAT", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

        }


    }
}
