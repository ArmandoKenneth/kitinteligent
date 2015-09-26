using KitInteligente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitInteligente.Data
{
    public class CalcEstoqueSegDb : KitDb
    {
        public CalcEstoqueSeg ObterCalcEstoqueSegDb(int? id)
        {
            try
            {
                return context.CalcEstoqueSegs.Find(id);
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}