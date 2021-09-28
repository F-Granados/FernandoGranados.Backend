using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Data;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public class Hijo
    {
        public static List<HijoEntity> Listar()
        {
            var lista = new List<HijoEntity>();
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados1;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("splistartodo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drlector = cmd.ExecuteReader();

            while (drlector.Read())
            {
                HijoEntity oHijoEntity = new HijoEntity();
                oHijoEntity.IdDerhab = Convert.ToInt32(drlector["IdDerhab"]);
                oHijoEntity.ApPaterno = drlector["ApPaterno"].ToString().Trim();
                oHijoEntity.ApMaterno = drlector["ApMaterno"].ToString().Trim();
                oHijoEntity.Nombre1 = drlector["Nombre1"].ToString().Trim();
                oHijoEntity.Nombre2 = drlector["Nombre2"].ToString().Trim();
                oHijoEntity.NombreCompleto = drlector["NombreCompleto"].ToString().Trim();
                lista.Add(oHijoEntity);


            }
            return lista;
        }


        public static List<HijoEntity> Filtrar(HijoEntity entidad)
        {
            var lista = new List<HijoEntity>();
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados1;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("spfiltrarpersona");
            cmd.Parameters.Add(new SqlParameter("@ApPaterno", SqlDbType.VarChar, 50)).Value = entidad.ApPaterno;
            cmd.Parameters.Add(new SqlParameter("@ApMaterno", SqlDbType.VarChar, 50)).Value = entidad.ApMaterno;

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drlector = cmd.ExecuteReader();

            while (drlector.Read())
            {
                HijoEntity oHijoEntity = new HijoEntity();
                oHijoEntity.IdDerhab = Convert.ToInt32(drlector["IdDerhab"]);
                oHijoEntity.ApPaterno = drlector["Apeliido_parterno"].ToString().Trim();
                oHijoEntity.ApMaterno = drlector["Apellido:materno"].ToString().Trim();
                oHijoEntity.Nombre1 = drlector["Nombre_1"].ToString().Trim();
                oHijoEntity.Nombre2 = drlector["Nombre_2"].ToString().Trim();
                oHijoEntity.NombreCompleto = drlector["Nombre"].ToString().Trim();
                lista.Add(oHijoEntity);

            }
            return lista;
        }


        public static string Registrar(HijoEntity entidad)
        {
            var lista = new List<HijoEntity>();
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados1;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            SqlCommand cmd = new SqlCommand("spguardarpersona", cn);
            cmd.Parameters.Add(new SqlParameter("@ApPaterno", SqlDbType.VarChar, 50)).Value = entidad.ApPaterno;
            cmd.Parameters.Add(new SqlParameter("@ApMaterno", SqlDbType.VarChar, 50)).Value = entidad.ApMaterno;
            cmd.Parameters.Add(new SqlParameter("@Nombre1", SqlDbType.VarChar, 50)).Value = entidad.Nombre1;
            cmd.Parameters.Add(new SqlParameter("@Nombre2", SqlDbType.VarChar, 50)).Value = entidad.Nombre2;
            cmd.Parameters.Add(new SqlParameter("@FchNac", SqlDbType.DateTime)).Value = "1/1/9999 ";
            cmd.Parameters.Add(new SqlParameter("@FchIngreso", SqlDbType.DateTime)).Value = "1/1/9999";


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            return "Registro exitoso";


        }

        public static string Modificar(HijoEntity entidad)
        {

            var lista = new List<HijoEntity>();
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados1;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            SqlCommand cmd = new SqlCommand("spmodificarpersona", cn);
            cmd.Parameters.Add(new SqlParameter("@ApPaterno", SqlDbType.VarChar, 50)).Value = entidad.ApPaterno;
            cmd.Parameters.Add(new SqlParameter("@ApMaterno", SqlDbType.VarChar, 50)).Value = entidad.ApMaterno;
            cmd.Parameters.Add(new SqlParameter("@Nombre1", SqlDbType.VarChar, 50)).Value = entidad.Nombre1;
            cmd.Parameters.Add(new SqlParameter("@Nombre2", SqlDbType.VarChar, 50)).Value = entidad.Nombre2;
            cmd.Parameters.Add(new SqlParameter("@NombreCompleto", SqlDbType.VarChar, 50)).Value = entidad.NombreCompleto;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Modificacion exitosa";
        }


        public static string Eliminar(HijoEntity entidad)
        {

            var lista = new List<HijoEntity>();
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados1;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            SqlCommand cmd = new SqlCommand("speliminarpersonal", cn);
            cmd.Parameters.Add(new SqlParameter("@IdDerhab", SqlDbType.Int)).Value = entidad.IdDerhab;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Eliminacion exitosa";

        }


    }
}
