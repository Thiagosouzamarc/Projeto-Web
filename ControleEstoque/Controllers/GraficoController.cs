using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoque.Controllers
{
    public class GraficoController : Controller
    {
        // GET: Grafico
       
        [Authorize]
        public ActionResult PerdaMes()
        {
            return View();
        }
        
        [Authorize]
        public ActionResult EntradaSaidaMes()
        {
            return View();
        }
    }
}