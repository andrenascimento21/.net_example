using Riba.Common.Helpers;
using Riba.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Riba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculatorHelper _calculatorHelper;

        private List<Order> Orders
        {
            get { return Session["Orders"] as List<Order>; }
            set { Session["Orders"] = value; }
        }

        public HomeController(ICalculatorHelper calculatorHelper)
        {
            _calculatorHelper = calculatorHelper;
        }

        public ActionResult Index()
        {
            var model = new Order();
            return View(model);
        }
    }
}