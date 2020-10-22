using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Registro_Detalle6.DAL;
using Registro_Detalle6.Entidades;

namespace Registro_Detalle6.BLL
{
   public class SuplidoresBLL
    {
        public static bool Guardar(Suplidores suplidores)
        {
            if (!Existe(suplidores.SuplidorId))
                return Insetar(suplidores);
            else
            {
                return Modificar(suplidores);
            }

        }
        private static bool Insetar(Suplidores suplidores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //agregar la entidad que decea insertar en el contexto
                contexto.Suplidores.Add(suplidores);
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
        private static bool Modificar(Suplidores suplidores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //marcar la intidad como modificada para que el contexto sepa proceder
                contexto.Entry(suplidores).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //buscar la entidad que se desea eliminar
                var suplidores = contexto.Suplidores.Find(id);
                if (suplidores != null)
                {
                    contexto.Suplidores.Remove(suplidores); //remover la entidad
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

        public static Suplidores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Suplidores suplidores;
            try
            {
                suplidores = contexto.Suplidores.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return suplidores;

        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Suplidores.Any(e => e.SuplidorId == id);
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
        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> criterio)
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto contexto = new Contexto();
            try
            {
                //Obtener la lista y filtrarla segun el criterio recibido por parametro.
                lista = contexto.Suplidores.Where(criterio).ToList();

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

        public static List<Suplidores> GetSuplidores()
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Suplidores.ToList();

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
    }
}
