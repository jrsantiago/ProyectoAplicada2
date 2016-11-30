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

        public DataSet GetData(DataTable dt)
        {
            int id = 0;
            DbVentana cone = new DbVentana();

            if (dt.Rows.Count > 0)
            {
                id = (int)dt.Rows[0]["UsuariosId"];
            }


            string Cs = ConfigurationManager.ConnectionStrings["VentanaDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Cs))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Usuarios where UsuariosId=" + id, con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
        }
    }
}
