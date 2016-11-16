using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAL
{
   public class DbVentana
    {
        SqlConnection cone;
        SqlCommand coma;

        public DbVentana()
        {
            cone = new SqlConnection(ConfigurationManager.ConnectionStrings["VentanaDb"].ConnectionString);
            coma = new SqlCommand();
        }
        public bool Ejecutar(String CommandSql)
        {
            bool retornar = false;

           try
            {
                cone.Open();
                coma.Connection = cone;
                coma.CommandText = CommandSql;
                coma.ExecuteNonQuery();
                retornar = true;

            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                cone.Close();
            }
            return retornar;
        }
        public DataTable ObtenerDatos(String CommandSql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter;

            try
            {
                cone.Open();
                coma.Connection = cone;
                coma.CommandText = CommandSql;

                adapter = new SqlDataAdapter(coma);
                adapter.Fill(dt);

            }catch(Exception ex)
            {
                throw ex;

            }finally
            {
                cone.Close();
            }
            return dt;
        }
        public Object ObtenerValor(String CommandSql)
        {
            Object retornar = null;
            try
            {
                cone.Open();
                coma.Connection = cone;
                coma.CommandText = CommandSql;

                retornar = coma.ExecuteScalar();

            }catch(Exception ex)
            {
                throw ex;

            }finally
            {
                cone.Close();
            }
            return retornar;
        }
    }
}
