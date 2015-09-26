using KitInteligente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitInteligente.Data
{
    public class DemandaDb : KitDb
    {
        public ICollection<Demanda> ObterTodasDemandas(int id)
        {
            try
            {
                return context.Demandas.Where(d => d.CalcEstoqueSegID == id).ToList();
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}