using libComunes.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using venta_vehiculos_API.Models;
using venta_vehiculos_API.ViewModel;

namespace venta_vehiculos_API.Servicios
{
    public class UsuarioService
    {
        public UsuarioVIewModel usuarioVM { get; set; }

        public Usuario usuario { get; set; }
        public string Error { get; set; }


        public List<Usuario> ConsultarTodos()
        {
            clsConexion oConexion = new clsConexion();

            oConexion.SQL = "usuario_select";
            oConexion.StoredProcedure = true;
            List<Usuario> usuarios = new List<Usuario>();

            if (oConexion.Consultar())
            {
                while (oConexion.Reader.Read())
                {
                    Rol rol = new Rol();
                    usuario = new Usuario();
                    usuario.id = oConexion.Reader.GetInt32(0);
                    usuario.documento = oConexion.Reader.GetString(1);
                    usuario.nombres = oConexion.Reader.GetString(2);
                    usuario.apellidos = oConexion.Reader.GetString(3);
                    usuario.telefono = oConexion.Reader.GetString(4);
                    usuario.email = oConexion.Reader.GetString(5);
                    rol.id = oConexion.Reader.GetInt32(6);
                    rol.nombre_rol = oConexion.Reader.GetString(7);
                    usuario.FKrol = rol;                   


                    usuarios.Add(usuario);
                }
                oConexion.CerrarConexion();
                return usuarios;
            }
            else
            {
                Error = oConexion.Error;
                oConexion.CerrarConexion();
                return null;
            }
        }

        public Usuario ConsultarXDocumento(string id)
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "usuario_doc_select";
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@documento", System.Data.SqlDbType.VarChar, 10, id);

            
            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    usuario = new Usuario();
                    Rol rol = new Rol();
                    oConexion.Reader.Read();
                    usuario.id = oConexion.Reader.GetInt32(0);
                    usuario.documento = oConexion.Reader.GetString(1);
                    usuario.nombres = oConexion.Reader.GetString(2);
                    usuario.apellidos = oConexion.Reader.GetString(3);
                    usuario.telefono = oConexion.Reader.GetString(4);
                    usuario.email = oConexion.Reader.GetString(5);
                    rol.id = oConexion.Reader.GetInt32(6);
                    rol.nombre_rol = oConexion.Reader.GetString(7);
                    usuario.FKrol = rol;

                    oConexion.CerrarConexion();
                }
                else
                {
                    oConexion.CerrarConexion();
                    return null;

                }
            }
            else
            {

                oConexion.CerrarConexion();
                return null;
            }
            return usuario;
        }
        public string Insertar()
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "usuario_insert";
            oConexion.StoredProcedure = true;

            //oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, usuarioVM.id);
            oConexion.AgregarParametro("@documento", System.Data.SqlDbType.VarChar, 10, usuarioVM.documento);
            oConexion.AgregarParametro("@nombres", System.Data.SqlDbType.VarChar, 100, usuarioVM.nombres);
            oConexion.AgregarParametro("@apellidos", System.Data.SqlDbType.VarChar, 200, usuarioVM.apellidos);
            oConexion.AgregarParametro("@telefono", System.Data.SqlDbType.VarChar, 10, usuarioVM.telefono);
            oConexion.AgregarParametro("@email", System.Data.SqlDbType.VarChar, 50, usuarioVM.email);
            oConexion.AgregarParametro("@FKrol", System.Data.SqlDbType.Int, 20, usuarioVM.FKrol);
            



            if (oConexion.EjecutarSentencia())
            {
                return "El usuarioVM: " + usuarioVM.nombres + " se ingresó exitosamente";


            }
            else
            {
                return oConexion.Error;
            }
        }


        public string Actualizar()
        {
            clsConexion oConexion = new clsConexion();
            oConexion.SQL = "usuario_update";
            oConexion.StoredProcedure = true;

            //oConexion.AgregarParametro("@id", System.Data.SqlDbType.Int, 20, usuarioVM.id);
            oConexion.AgregarParametro("@documento", System.Data.SqlDbType.VarChar, 10, usuarioVM.documento);
            oConexion.AgregarParametro("@nombres", System.Data.SqlDbType.VarChar, 100, usuarioVM.nombres);
            oConexion.AgregarParametro("@apellidos", System.Data.SqlDbType.VarChar, 200, usuarioVM.apellidos);
            oConexion.AgregarParametro("@telefono", System.Data.SqlDbType.VarChar, 10, usuarioVM.telefono);
            oConexion.AgregarParametro("@email", System.Data.SqlDbType.VarChar, 50, usuarioVM.email);
            oConexion.AgregarParametro("@FKrol", System.Data.SqlDbType.Int, 20, usuarioVM.FKrol);


            if (oConexion.EjecutarSentencia())
            {
                return "UsuarioVIewModel con documento: " + usuarioVM.documento + " se actualizó exitosamente";
            }
            else
            {
                return oConexion.Error;
            }
        }


        public string Eliminar(string id)
        {
            clsConexion oConexion = new clsConexion();


            usuario = this.ConsultarXDocumento(id);

            if (usuario == null)
            {
                return "No existe usuario con Documento: " + id;
            }


            oConexion.SQL = "usuario_delete";
            oConexion.StoredProcedure = true;

            oConexion.AgregarParametro("@documento", System.Data.SqlDbType.VarChar, 10, usuario.documento);


            if (oConexion.EjecutarSentencia())
            {
                return "el usuarioVM con Documento: " + usuario.documento + " se eliminó exitosamente";
            }
            else
            {
                return oConexion.Error;
            }
        }
    }
}