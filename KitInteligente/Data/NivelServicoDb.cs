using KitInteligente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitInteligente.Data
{
    public class NivelServicoDb : KitDb
    {
        public ICollection<NivelServico> obterNiveisServico()
        {
            try
            {
                return context.NivelServicos.ToList();
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public double ObterFator(int id)
        {
            try
            {
                return context.NivelServicos.Find(id).Fator;
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}