using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Web.Mvc;
using MVC_Assessment.Models;
namespace MVC_Assessment.Controllers
{
    public class CodeController : Controller
    {
        // GET: Code
        northwindEntities db = new northwindEntities();
        public ActionResult Customers()
        {
            var customers = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customers);
        }

        public ActionResult CustomerOrder()
        {
            var custorder = db.Orders.Where(o => o.OrderID == 10248).Select(o => o.Customer).FirstOrDefault();

            if (custorder == null)
            {
                return HttpNotFound();
            }
            return View(custorder);
        }
    }
}