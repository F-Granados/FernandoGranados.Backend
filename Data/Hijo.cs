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
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("splistar_hijo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drlector = cmd.ExecuteReader();

            while (drlector.Read())
            {
                HijoEntity oHijoEntity = new HijoEntity();
                oHijoEntity.IdPersonal = Convert.ToInt32(drlector["IdPersonal"]);
                oHijoEntity.IdDerHab = Convert.ToInt32(drlector["IdDerHab"]);
                oHijoEntity.ApPaterno = drlector["ApPaterno"].ToString().Trim();
                oHijoEntity.ApMaterno = drlector["ApMaterno"].ToString().Trim();
                oHijoEntity.Nombre1 = drlector["Nombre1"].ToString().Trim();
                oHijoEntity.Nombre2 = drlector["Nombre2"].ToString().Trim();
                oHijoEntity.NombreCompleto = drlector["NombreCompleto"].ToString().Trim();
                oHijoEntity.FchNac = Convert.ToDateTime(drlector["FchNac"]).ToString("dd/MM/yyyy");
                lista.Add(oHijoEntity);


            }
            return lista;
        }


        public static List<HijoEntity> FiltrarHijo(int id)
        {
            var lista = new List<HijoEntity>();
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("spfiltrarhijo");
            cmd.Parameters.Add(new SqlParameter("@IdPersonal", SqlDbType.VarChar, 50)).Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drlector = cmd.ExecuteReader();

            while (drlector.Read())
            {
                HijoEntity oHijoEntity = new HijoEntity();
                oHijoEntity.IdDerHab = Convert.ToInt32(drlector["IdDerHab"]);
                oHijoEntity.ApPaterno = drlector["Apeliido_parterno"].ToString().Trim();
                oHijoEntity.ApMaterno = drlector["Apellido:materno"].ToString().Trim();
                oHijoEntity.Nombre1 = drlector["Nombre_1"].ToString().Trim();
                oHijoEntity.Nombre2 = drlector["Nombre_2"].ToString().Trim();
                oHijoEntity.NombreCompleto = drlector["NombreCompleto"].ToString().Trim();
                oHijoEntity.FchNac = Convert.ToDateTime(drlector["FchNac"]).ToString("dd/MM/yyyy");
                lista.Add(oHijoEntity);

            }
            return lista;
        }

        public static List<HijoEntity> FiltrarHijosId(int id)
        {
            var lista = new List<HijoEntity>();
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados;Integrated Security=True";

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("spfiltrar_hiijoid", cn);
            cmd.Parameters.Add(new SqlParameter("@idderhab", SqlDbType.VarChar, 100)).Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drlector = cmd.ExecuteReader();

            while (drlector.Read())
            {
                HijoEntity oHijoEntity = new HijoEntity();
                oHijoEntity.IdDerHab = Convert.ToInt32(drlector["IdDerHab"]);
                oHijoEntity.IdPersonal = Convert.ToInt32(drlector["IdPersonal"]);
                oHijoEntity.ApPaterno = drlector["ApPaterno"].ToString().Trim();
                oHijoEntity.ApMaterno = drlector["ApMaterno"].ToString().Trim();
                oHijoEntity.Nombre1 = drlector["Nombre1"].ToString().Trim();
                oHijoEntity.Nombre2 = drlector["Nombre2"].ToString().Trim();
                oHijoEntity.NombreCompleto = drlector["NombreCompleto"].ToString().Trim();
                oHijoEntity.FchNac = Convert.ToDateTime(drlector["FchNac"]).ToString("dd/MM/yyyy");

                lista.Add(oHijoEntity);
            }
            return lista;
        }


        public static string Registrar(HijoEntity entidad)
        {
            var lista = new List<HijoEntity>();
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            SqlCommand cmd = new SqlCommand("spguardar_hijo", cn);
            cmd.Parameters.Add(new SqlParameter("@idpersonal", SqlDbType.Int)).Value = entidad.IdPersonal;
            cmd.Parameters.Add(new SqlParameter("@appaterno", SqlDbType.VarChar, 50)).Value = entidad.ApPaterno;
            cmd.Parameters.Add(new SqlParameter("@apmaterno", SqlDbType.VarChar, 50)).Value = entidad.ApMaterno;
            cmd.Parameters.Add(new SqlParameter("@nombre1", SqlDbType.VarChar, 50)).Value = entidad.Nombre1;
            cmd.Parameters.Add(new SqlParameter("@nombre2", SqlDbType.VarChar, 50)).Value = entidad.Nombre2;
            cmd.Parameters.Add(new SqlParameter("@nombrecompleto", SqlDbType.VarChar, 200)).Value = entidad.NombreCompleto;
            cmd.Parameters.Add(new SqlParameter("@fchnac", SqlDbType.DateTime)).Value = DateTime.Parse(entidad.FchNac);


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            return "Registro exitoso";


        }

        public static string Modificar(HijoEntity entidad)
        {

            var lista = new List<HijoEntity>();
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            SqlCommand cmd = new SqlCommand("spmodificarhijo", cn);
            cmd.Parameters.Add(new SqlParameter("@idderhab", SqlDbType.Int)).Value = entidad.IdDerHab;
            cmd.Parameters.Add(new SqlParameter("@idpersonal", SqlDbType.Int)).Value = entidad.IdPersonal;
            cmd.Parameters.Add(new SqlParameter("@appaterno", SqlDbType.VarChar, 50)).Value = entidad.ApPaterno;
            cmd.Parameters.Add(new SqlParameter("@apmaterno", SqlDbType.VarChar, 50)).Value = entidad.ApMaterno;
            cmd.Parameters.Add(new SqlParameter("@nombre1", SqlDbType.VarChar, 50)).Value = entidad.Nombre1;
            cmd.Parameters.Add(new SqlParameter("@nombre2", SqlDbType.VarChar, 50)).Value = entidad.Nombre2;
            cmd.Parameters.Add(new SqlParameter("@nombrecompleto", SqlDbType.VarChar, 200)).Value = entidad.NombreCompleto;
            cmd.Parameters.Add(new SqlParameter("@fchnac", SqlDbType.DateTime)).Value = DateTime.Parse(entidad.FchNac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Modificacion exitosa";
        }


        public static string Eliminar(int id)
        {

            var lista = new List<HijoEntity>();
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            SqlCommand cmd = new SqlCommand("speliminar_hijo", cn);
            cmd.Parameters.Add(new SqlParameter("@IdDerhab", SqlDbType.Int)).Value = id;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Eliminacion exitosa";

        }


    }
}
