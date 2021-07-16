using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models;
using Inventario.ViewModels;
using System.Data.SqlClient;

namespace Inventario.AccesoDatos
{
    public class AD_Usuario
    {
        public static List<VMInventario> ListarUsuarios()
        {
            List<VMInventario> resultado = new List<VMInventario>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql =
                    @"SELECT u.ID_USUARIO, 
                        u.CODIGO_USUARIO usuario, 
                        u.APELLIDO_USUARIO +' '+ u.NOMBRE_USUARIO NOMBRE, 
                        u.MAIL_USUARIO mail , 
                        u.HABILITADO_USUARIO,
                        r.DESCRIPCION_ROL rol
                        FROM USUARIOS u left join ROLES r on u.id_rol = r.ID_ROL 
                        order by 2;";

                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consultaSql;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        VMInventario aux = new VMInventario();
                        aux.Id_usuario = int.Parse(dr["Id_usuario"].ToString());
                        aux.Codigo_usuario = dr["usuario"].ToString();
                        aux.Nombre_usuario = dr["nombre"].ToString();
                        aux.Mail_usuario = dr["mail"].ToString();
                        aux.Habilitado_usuario = bool.Parse(dr["Habilitado_usuario"].ToString());
                        aux.Descripcion_rol = dr["rol"].ToString();


                        resultado.Add(aux);


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }
        public static bool InsertarUsuario(VMInventario usuario)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql = "INSERT INTO usuarios VALUES(@Codigo_usuario, @Password_usuario, @Nombre_usuario, @Apellido_usuario, @Mail_usuario,@Habilitado_usuario,@Id_rol)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Codigo_usuario", usuario.Codigo_usuario);
                cmd.Parameters.AddWithValue("@Password_usuario", usuario.Password_usuario);
                cmd.Parameters.AddWithValue("@Nombre_usuario", usuario.Nombre_usuario);
                cmd.Parameters.AddWithValue("@Apellido_usuario", usuario.Apellido_usuario);
                cmd.Parameters.AddWithValue("@Mail_usuario", usuario.Mail_usuario);
                cmd.Parameters.AddWithValue("@Habilitado_usuario", usuario.Habilitado_usuario);
                cmd.Parameters.AddWithValue("@Id_rol", usuario.Id_rol);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consultaSql;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }
        public static bool registrarUsuario(VMInventario usuario)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql = "INSERT INTO usuarios VALUES(@Codigo_usuario, @Password_usuario, @Nombre_usuario, @Apellido_usuario, @Mail_usuario,1,3)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Codigo_usuario", usuario.Codigo_usuario);
                cmd.Parameters.AddWithValue("@Password_usuario", usuario.Password_usuario);
                cmd.Parameters.AddWithValue("@Nombre_usuario", usuario.Nombre_usuario);
                cmd.Parameters.AddWithValue("@Apellido_usuario", usuario.Apellido_usuario);
                cmd.Parameters.AddWithValue("@Mail_usuario", usuario.Mail_usuario);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consultaSql;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }
        public static VMInventario ObtenerUsuario(int Id_usuario)
        {
            VMInventario resultado = new VMInventario();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM usuarios WHERE Id_usuario =@Id_usuario";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id_usuario", Id_usuario);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;


                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)

                {
                    while (dr.Read())
                    {

                        resultado.Id_usuario = int.Parse(dr["Id_usuario"].ToString());
                        resultado.Codigo_usuario = dr["Codigo_usuario"].ToString();
                        resultado.Password_usuario = dr["Password_usuario"].ToString();
                        resultado.Nombre_usuario = dr["Nombre_usuario"].ToString();
                        resultado.Apellido_usuario = dr["Apellido_usuario"].ToString();
                        resultado.Mail_usuario = dr["Mail_usuario"].ToString();
                        resultado.Habilitado_usuario = bool.Parse(dr["Habilitado_usuario"].ToString());
                        resultado.Id_rol = int.Parse(dr["Id_rol"].ToString());
                       
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                cn.Close();
            }

            return resultado;
        }
        public static bool ActualizarDatosUsuarios(VMInventario usuario)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "UPDATE usuarios SET Codigo_usuario = @Codigo_usuario, Password_usuario = @Password_usuario, Nombre_usuario = @Nombre_usuario, Apellido_usuario = @Apellido_usuario, Mail_usuario = @Mail_usuario, Habilitado_usuario = @Habilitado_usuario, Id_rol = @Id_rol where Id_usuario = @Id_usuario";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id_usuario", usuario.Id_usuario);
                cmd.Parameters.AddWithValue("@Codigo_usuario", usuario.Codigo_usuario);
                cmd.Parameters.AddWithValue("@Password_usuario", usuario.Password_usuario);
                cmd.Parameters.AddWithValue("@Nombre_usuario", usuario.Nombre_usuario);
                cmd.Parameters.AddWithValue("@Apellido_usuario", usuario.Apellido_usuario);
                cmd.Parameters.AddWithValue("@Mail_usuario", usuario.Mail_usuario);
                cmd.Parameters.AddWithValue("@Habilitado_usuario", usuario.Habilitado_usuario);
                cmd.Parameters.AddWithValue("@Id_rol", usuario.Id_rol);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open
                ();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                cn.Close();
            }

            return resultado;
        }
        public static List<TipoRoles> ListarTipoRoles()
        {
            List<TipoRoles> resultado = new List<TipoRoles>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql = "SELECT Id_rol, Descripcion_rol FROM roles  order by 2;";
                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consultaSql;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        TipoRoles aux = new TipoRoles();
                        aux.Id_rol = int.Parse(dr["Id_rol"].ToString());
                        aux.Descripcion_rol = dr["Descripcion_rol"].ToString();
                        resultado.Add(aux);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }
        public static VMInventario ObtenerRecuperarUsuario(string codigo_usuario)
        {
            VMInventario resultado = new VMInventario();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM usuarios WHERE codigo_usuario =@codigo_usuario";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@codigo_usuario", codigo_usuario);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;


                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)

                {
                    while (dr.Read())
                    {

                        resultado.Id_usuario = int.Parse(dr["Id_usuario"].ToString());
                        resultado.Codigo_usuario = dr["Codigo_usuario"].ToString();
                        resultado.Password_usuario = dr["Password_usuario"].ToString();
                        resultado.Nombre_usuario = dr["Nombre_usuario"].ToString();
                        resultado.Apellido_usuario = dr["Apellido_usuario"].ToString();
                        resultado.Mail_usuario = dr["Mail_usuario"].ToString();
                        resultado.Habilitado_usuario = bool.Parse(dr["Habilitado_usuario"].ToString());
                        resultado.Id_rol = int.Parse(dr["Id_rol"].ToString());

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                cn.Close();
            }

            return resultado;
        }
        public static bool ActualizarDatosRecuperarUsuarios(VMInventario usuario)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "UPDATE usuarios SET Password_usuario = @Password_usuario where Codigo_usuario = @Codigo_usuario";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Codigo_usuario", usuario.Codigo_usuario);
                cmd.Parameters.AddWithValue("@Password_usuario", usuario.Password_usuario);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
                cn.Open
                ();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                cn.Close();
            }

            return resultado;
        }

    }
}