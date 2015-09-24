using KitInteligente.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KitInteligente.Data
{
    public class CategoriaDb : KitDb
    {
        public ICollection<Categoria> obterTodasCategorias()
        {
            try
            {
                return context.Categorias.ToList();
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public Categoria obterCategoria(int? id)
        {
            try
            {
                return context.Categorias.Find(id);
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public void salvarCategoria(Categoria categoria)
        {
            try
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void editarCategoria(Categoria categoria)
        {
            try
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void removerCategoria(int id)
        {
            try
            {
                Categoria categoria = this.obterCategoria(id);
                context.Categorias.Remove(categoria);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}