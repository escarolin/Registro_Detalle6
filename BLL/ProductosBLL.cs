using System;
using System.Linq;
using System.Linq.Expressions;
using Registro_Detalle6.DAL;
using System.Collections.Generic;
using Registro_Detalle6.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Registro_Detalle6.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos productos)
        {
            if (!Existe(productos.ProductoId))
                return Insertar(productos);
            else
            {
                return Modificar(productos);
            }
        }

        private static bool Insertar(Productos productos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                 //Productos.Costop += productos.Cantidad;
                //agregar la entidad que decea insertar en el contexto
                contexto.Productos.Add(productos);
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

        private static bool Modificar(Productos productos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(productos).State = EntityState.Modified;
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
                //buscar la entida que se desea eliminar
                var productos = contexto.Productos.Find(id);
                if (productos != null)
                {
                    contexto.Productos.Remove(productos); //remover la entidad
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

        public static Productos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos productos;
            try
            {
                productos = contexto.Productos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return productos;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Productos.Any(e => e.ProductoId == id);
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

        public static List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>();
            Contexto contexto = new Contexto();
            try
            {
                //Obtener la lista y filtrarla segun el criterio recibido por parametro.
                lista = contexto.Productos.Where(criterio).ToList();

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

        public static List<Productos> Getproductos()
        {
            List<Productos> lista = new List<Productos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Productos.ToList();

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