using FoundrySupportDataModel.FoundryDataOPerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace _3DFTCustomerSolution.Controllers
{
    public class CustomerController : Controller
    {
        readonly CustomerOperations customerOperations =null;
        public CustomerController()
        {
            customerOperations = new CustomerOperations();
        }
        // GET: Customer
        public ActionResult GetAllCustomers()
        {
            var result= customerOperations.GetCustomerList();
            return View(result);
        }
        public ActionResult ResisterCustomer()
        {
            return View("ResisterCustomer");
        }
    }
}