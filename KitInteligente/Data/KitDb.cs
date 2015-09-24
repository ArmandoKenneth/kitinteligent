using KitInteligente.Db;
using KitInteligente.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitInteligente.Data
{
    public class KitDb
    {
        protected KitContext context = new KitContext();

        public void dispose()
        {
            try
            {
                context.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
    }
}