using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Models;
using Datalayer.Repositories;
using Datalayer.SQLContext;

namespace VogeltellerV2.Controllers
{
    public class LoginController : Controller
    {
        AccountRepository ar = new AccountRepository(new AccountSQLContext());
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            try
            {
                //Maak een account aan genaamd loggedinuser
                Account loggedInUser = ar.Login(email, password);

                //Sla bepaalde gegevens van de loggedinuser op in een session 
                Session["Rank"] = loggedInUser.IsAdmin;
                Session["Email"] = loggedInUser.Email;
                Session["AccountId"] = loggedInUser.Id;

                //Hier kan je variabelen aanmaken om een loggedinuser naar andere pagina's te sturen
                if (loggedInUser.IsAdmin == false)
                {
                    return RedirectToAction("Index", "Gebied");
                }
                else if (loggedInUser.IsAdmin == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }




            }
            catch (Exception)
            {
                return View("Index");
            }

        }
    }
}