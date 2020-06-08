using Microsoft.EntityFrameworkCore;
using RegistroDeUsuario.DAL;
using RegistroDeUsuario.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroDeUsuario.BLL
{
    class UsuarioBLL
    {
        public static bool Guardar(Usuario usuario)
        {
            if (!Existe(usuario.UsuarioId)) // Si no existe insertamos
                return Insertar(usuario);
            else
                return Modificar(usuario);
        }

        private static bool Insertar(Usuario usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Usuario.Add(usuario);
                paso = contexto.SaveChanges() > 0;
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Usuario usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(usuario).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }

            catch (Exception)
            {
                throw;

            }

            finally
            {
                contexto.Dispose();
            }

            return paso;

        }


        public static Usuario Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuario usuario;


            try
            {
                usuario = contexto.Usuario.Find(id);
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }
            return usuario;
        }

        public static List<Usuario> GetList(Expression<Func<Usuario, bool>> criterio)
        {

            List<Usuario> lista = new List<Usuario>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Usuario.Where(criterio).ToList();

            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Usuario.Any(e => e.UsuarioId == id);
            }

            catch (Exception)
            {
                throw;

            }

            finally
            {

                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //buscar la entidad que se desea eliminar
                var vehiculos = contexto.Usuario.Find(id);

                if (vehiculos != null)
                {
                    contexto.Usuario.Remove(vehiculos);
                    paso = contexto.SaveChanges() > 0;

                }


            }

            catch (Exception)
            {
                throw;
            }

            finally
            {

                contexto.Dispose();

            }

            return paso;

        }

    }
}
