using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Registro_Detalle6.DAL;
using Registro_Detalle6.Entidades;

namespace Registro_Detalle6.BLL
{
    public class OrdenesBLL
    {
        //=====================================================[ GUARDAR ]=====================================================
        public static bool Guardar(Ordenes ordenes)
        {
            if (!Existe(ordenes.OrdenId))
                return Insertar(ordenes);
            else
                return Modificar(ordenes);
        }
        //=====================================================[ INSERTAR ]=====================================================
        private static bool Insertar( Ordenes ordenes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Ordenes.Add(ordenes);
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
        //=====================================================[ MODIFICAR ]=====================================================
        public static bool Modificar(Ordenes ordenes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //-------------------------------------------[ REGISTRO DETALLADO ]-------------------------------------------------
                contexto.Database.ExecuteSqlRaw($"Delete FROM ordenesDetalle Where MoraId={ordenes.OrdenId}");

                foreach (var item in ordenes.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                //------------------------------------------------------------------------------------------------------------------

                contexto.Entry(ordenes).State = EntityState.Modified;
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
        //=====================================================[ ELIMINAR ]=====================================================
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var ordenes = contexto.Ordenes.Find(id);
                if (ordenes != null)
                {
                    contexto.Ordenes.Remove(ordenes);
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
        //=====================================================[ BUSCAR ]=====================================================
        public static Ordenes Buscar(int id)
        {
            //-------------------[ REGISTRO DETALLADO ] -------------------
            Ordenes ordenes = new Ordenes();
            //-------------------------------------------------------------
            Contexto contexto = new Contexto();
            //ordenes ordenes;
            try
            {
                //-------------------[ REGISTRO DETALLADO ] -------------------
                ordenes = contexto.Ordenes.Include(x => x.Detalle)
                    .Where(x => x.OrdenId == id)
                    .SingleOrDefault();
                //-------------------------------------------------------------
                //ordenes = contexto.ordenes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ordenes;
        }
        //=====================================================[ GET LIST ]===================================================== 
        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> criterio)
        {
            List<Ordenes> lista = new List<Ordenes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Ordenes.Where(criterio).ToList();
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
        //=====================================================[ EXISTE ]===================================================== 
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {

                encontrado = contexto.Ordenes.Any(d => d.OrdenId == id);
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
    }
}