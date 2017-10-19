using Riba.Common.Helpers;
using Riba.Model;
using Riba.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Riba.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICalculatorHelper _calculatorHelper;

        private List<Order> Orders
        {
            get { return Session["Orders"] as List<Order>; }
            set { Session["Orders"] = value; }
        }

        public OrderController(ICalculatorHelper calculatorHelper)
        {
            _calculatorHelper = calculatorHelper;
        }

        public JsonResult GetOrders()
        {
            var orders = Orders;
            orders.ForEach(x => x.Cost = _calculatorHelper.CalculateDiscount(x.UnitPrice, x.Quantity));
            
            return Json(new JsonResponseViewModel(true, orders), JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult AddOrder(Order model)
        {
            if (ModelState.IsValid)
            {
                model.OrderId = Orders.Count + 1;
                model.Cost = _calculatorHelper.CalculateDiscount(model.UnitPrice, model.Quantity);

                Orders.Add(model);
                return Json(new JsonResponseViewModel(true, model), JsonRequestBehavior.AllowGet);
            }
            else
            {
                //get errors from model state
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return Json(new JsonResponseViewModel(false, null, errors), JsonRequestBehavior.AllowGet);
            }
        }
    }
}