using KitInteligente.Data;
using KitInteligente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KitInteligente.Controllers
{
    public class CalculoEstoqueSegurancaController : Controller
    {
        private ProdutoDb produtoDb = new ProdutoDb();
        private NivelServicoDb nvServicoDb = new NivelServicoDb();
        private CalcEstoqueSegDb calculoEstoqueDb = new CalcEstoqueSegDb();
        private DemandaDb demandaDb = new DemandaDb();

        public ActionResult Resetar()
        {
            return RedirectToAction("Index", "Produtoes");
        }

        // GET: CalculoEstoqueSeguranca
        public ActionResult Index(int? id)
        {
            
            if (id != null && id != 0)
            {
                try
                {
                    CalculoEstoque model = new CalculoEstoque();
                    // obter produto
                    model.Produto = produtoDb.obterProduto(id);
                    if (model.Produto != null)
                    {
                        // obter niveis servico
                        model.NiveisServico = nvServicoDb.obterNiveisServico();
                        return View(model);
                    }
                    return Resetar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return Resetar();
        }

        [HttpPost]
        public JsonResult Calcular(JsonCalculo obj)
        {
            double desvioPadrao = 0;
            int p = 0;
            double temp = 0 ;
            if (obj.PeriodoSelecionado == 1)
                p = 10;
            else
                p = obj.PeriodoSelecionado;
                for (int i = 0; i < p; i++)
            {
                temp += Math.Pow((obj.Demandas[i] - obj.Media), 2); 
            }
            desvioPadrao = Math.Sqrt((temp / (p-1)));
            
            double fator = nvServicoDb.ObterFator(obj.NivelServicoID);
            double estoqueSeguranca = (fator * desvioPadrao) * Math.Sqrt( ((double) obj.LeadTime)/((double) obj.PeriodoSelecionado));
            //double estoqueSeguranca = Math.Round((fator * desvioPadrao) * Math.Sqrt(obj.LeadTime / 10));

            double pontoRessuprimento = Math.Round((obj.Media * obj.LeadTime) + estoqueSeguranca);

            double estoqueMaximo = Math.Round((estoqueSeguranca + obj.Media) * obj.LeadTime);

            obj.DesvioPadrao = desvioPadrao;
            obj.EstoqueSeguro = Math.Round(estoqueSeguranca);
            obj.PontoRessuprimento = pontoRessuprimento;
            obj.EstoqueMaximo = estoqueMaximo;
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
    
}