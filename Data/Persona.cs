using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    public class Persona
    {
        public static List<PersonaEntity> Listar()
        {
            var lista = new List<PersonaEntity>();
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados1;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("splistartodo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drlector = cmd.ExecuteReader();

            while (drlector.Read())
            {
                PersonaEntity oPersonaEntity = new PersonaEntity();
                oPersonaEntity.IdPersonal = Convert.ToInt32(drlector["IdPersonal"]);
                oPersonaEntity.ApPaterno = drlector["ApPaterno"].ToString().Trim();
                oPersonaEntity.ApMaterno = drlector["ApMaterno"].ToString().Trim();
                oPersonaEntity.Nombre1 = drlector["Nombre1"].ToString().Trim();
                oPersonaEntity.Nombre2 = drlector["Nombre2"].ToString().Trim();
                oPersonaEntity.NombreCompleto = drlector["NombreCompleto"].ToString().Trim();
                oPersonaEntity.FchNac = Convert.ToDateTime(drlector["FchNac"]).ToString("dd/MM/yyyy");
                oPersonaEntity.FchIngreso = Convert.ToDateTime(drlector["FchIngreso"]).ToString("dd/MM/yyyy");
                oPersonaEntity.Dni = drlector["Dni"].ToString().Trim();
                lista.Add(oPersonaEntity);


            }
            return lista;
        }

        public static PersonaEntity ListarPorId(int id)
        {
           
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados1;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open(); 
            SqlCommand cmd = new SqlCommand("select * from PERSONAL where idPersonal=1", cn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader drlector = cmd.ExecuteReader();
            PersonaEntity oPersonaEntity = new PersonaEntity();
            while (drlector.Read())
            {
              
                oPersonaEntity.IdPersonal = Convert.ToInt32(drlector["IdPersonal"]);
                oPersonaEntity.ApPaterno = drlector["ApPaterno"].ToString().Trim();
                oPersonaEntity.ApMaterno = drlector["ApMaterno"].ToString().Trim();
                oPersonaEntity.Nombre1 = drlector["Nombre1"].ToString().Trim();
                oPersonaEntity.Nombre2 = drlector["Nombre2"].ToString().Trim();
                //oPersonaEntity.NombreCompleto = drlector["NombreCompleto"].ToString().Trim();
                //oPersonaEntity.FchNac = Convert.ToDateTime(drlector["FchNac"]).ToString("dd/MM/yyyy");
                //oPersonaEntity.FchIngreso = Convert.ToDateTime(drlector["FchIngreso"]).ToString("dd/MM/yyyy");
                oPersonaEntity.Dni = drlector["Dni"].ToString().Trim();
              


            }
            return oPersonaEntity;
        }

        public static List<PersonaEntity> Filtrar(PersonaEntity entidad)
        {
            var lista = new List<PersonaEntity>();
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
                PersonaEntity oPersonaEntity = new PersonaEntity();
                oPersonaEntity.IdPersonal = Convert.ToInt32(drlector["Id_personal"]);
                oPersonaEntity.ApPaterno = drlector["Apeliido_parterno"].ToString().Trim();
                oPersonaEntity.ApMaterno = drlector["Apellido:materno"].ToString().Trim();
                oPersonaEntity.Nombre1 = drlector["Nombre_1"].ToString().Trim();
                oPersonaEntity.Nombre2 = drlector["Nombre_2"].ToString().Trim();
                oPersonaEntity.NombreCompleto = drlector["Nombre"].ToString().Trim();
                oPersonaEntity.FchNac = Convert.ToDateTime(drlector["Fecha_Nacimiento"]).ToString("dd/MM/yyyy");
                oPersonaEntity.FchIngreso = Convert.ToDateTime(drlector["Fecha_ingreso"]).ToString("dd/MM/yyyy");
                oPersonaEntity.Dni = drlector["Dni"].ToString().Trim();
                lista.Add(oPersonaEntity);

            }
            return lista;
        }


        public static string Registrar(PersonaEntity entidad)
        {
            var lista = new List<PersonaEntity>();
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
            cmd.Parameters.Add(new SqlParameter("@Dni", SqlDbType.VarChar, 50)).Value = entidad.Dni;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            
            return "Registro exitoso";


        }

        public static string Modificar(PersonaEntity entidad)
        {

            var lista = new List<PersonaEntity>();
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados1;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            SqlCommand cmd = new SqlCommand("spmodificarpersona", cn);
            cmd.Parameters.Add(new SqlParameter("@ApPaterno", SqlDbType.VarChar, 50)).Value = entidad.ApPaterno;
            cmd.Parameters.Add(new SqlParameter("@ApMaterno", SqlDbType.VarChar, 50)).Value = entidad.ApMaterno;
            cmd.Parameters.Add(new SqlParameter("@Nombre1", SqlDbType.VarChar, 50)).Value = entidad.Nombre1;
            cmd.Parameters.Add(new SqlParameter("@Nombre2", SqlDbType.VarChar, 50)).Value = entidad.Nombre2;
            cmd.Parameters.Add(new SqlParameter("@NombreCompleto", SqlDbType.VarChar, 50)).Value = entidad.NombreCompleto;
            cmd.Parameters.Add(new SqlParameter("@FchNac", SqlDbType.DateTime)).Value = DateTime.Parse(entidad.FchNac);
            cmd.Parameters.Add(new SqlParameter("@FchIngreso", SqlDbType.DateTime, 50)).Value = DateTime.Parse(entidad.FchIngreso);
            cmd.Parameters.Add(new SqlParameter("@Dni", SqlDbType.VarChar, 50)).Value = entidad.Dni;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Modificacion exitosa";
        }


        public static string Eliminar(PersonaEntity entidad)
        {

            var lista = new List<PersonaEntity>();
            string cadenaConexion = @"Data Source=LAPTOP-HE8D4VTA\SQLEXPRESS;Initial Catalog=FernandoGranados1;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            SqlCommand cmd = new SqlCommand("speliminarpersonal", cn);
            cmd.Parameters.Add(new SqlParameter("@IdPersonal", SqlDbType.Int)).Value = entidad.IdPersonal;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Eliminacion exitosa";

        }
    }
}











//        public long Registar(PersonaEntity persona)
//        {


//            long id = 0;
//            string conexion = "workstation id=serviceApp.mssql.somee.com;packet size=4096;user id=jonito_or_SQLLogin_1;pwd=y18991h9ru;data source=serviceApp.mssql.somee.com;persist security info=False;initial catalog=serviceApp";
//            //  conexion = "Data Source =.; Initial Catalog = serviceApp; Integrated Security = True";
//            try
//            {
//                using (SqlConnection connection = new SqlConnection(conexion))
//                {
//                    connection.Open();
//                    string sql = " ";
//                    using (SqlCommand cmd = new SqlCommand(sql, connection))
//                    {
//                        cmd.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = "";//envio.datos.FirstOrDefault().nombre_usuario;
//                         cmd.CommandType = CommandType.Text;

//                        id = (int)cmd.ExecuteScalar();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {

//                throw new Exception(ex.Message);
//            }
//            return id;


//        }

//        public List<PersonaEntity> listar()
//        {
//            PersonaEntity personaEntity = new PersonaEntity();
//            List<PersonaEntity> lPersonaEntity = new List<PersonaEntity>();
//            string conexion = @"Data Source=LAPTOP-HE8D4VTA\\SQLEXPRESS;Initial Catalog=FernandoGranados;Integrated Security=True";
//            using (SqlConnection connection = new SqlConnection(conexion))
//            {
//                connection.Open();

//                string sql = " SELECT TOP (1000) [IdPersonal],[ApPaterno] ,[ApMaterno],[Nombre1],[Nombre2],[NombreCompleto],[FchNac] ,[FchIngreso],[Dni] FROM PERSONAL";

//                using (SqlCommand command = new SqlCommand(sql, connection))
//                {
//                    SqlDataReader reader = command.ExecuteReader();
//                    while (reader.Read())
//                    {

//                        personaEntity = new PersonaEntity();
//                        personaEntity.ApPaterno = reader["ApPaterno"].ToString();
//                        personaEntity.ApMaterno = reader["ApMaterno"].ToString();
//                        personaEntity.Dni = reader["Dni"].ToString();
//                        personaEntity.Nombre1 = reader["Nombre1"].ToString();
//                        personaEntity.Nombre2 = reader["Nombre2"].ToString();
//                        personaEntity.FchNac = reader["FchNac"].ToString();
//                        lPersonaEntity.Add(personaEntity);
//                    }

//                }
//            }


//            return lPersonaEntity;
//        }



//    }
//}
