using DataModelInterface;
using FoundrySupportDataModel.FoundryDataOPerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _3DFTCustomerSolution.Controllers
{

    public class AccountController : Controller
    {
        readonly LoginOperatins loginOperatins = null;
        public AccountController()
        {
            loginOperatins = new LoginOperatins();
        }
        [HandleError]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
               var isValid= loginOperatins.IsValidUser(loginModel.UserName, loginModel.Password);
                if(isValid)
                {
                   FormsAuthentication.SetAuthCookie(loginModel.UserName, false);
                    return RedirectToAction("GetAllCustomers", "Customer");
                }
                else
                {
                    ModelState.AddModelError(" ","Invalid Username and Password");
                return View();
            }
          
        }
        public ActionResult SingUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SingUp(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
               int id= loginOperatins.AddUser(loginModel);
                if(id>0)
                {
                   return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("","Database failed");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
     
    }
}