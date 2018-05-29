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
    public class AccountController : Controller
    {
        AccountRepository ar = new AccountRepository(new AccountSQLContext());
        // GET: Account


        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Account account = new Account(collection["Email"], collection["Voornaam"], collection["Achternaam"], collection["Wachtwoord"], Convert.ToBoolean(collection["IsAdmin"]));
                ar.InsertAccount(account);
                return RedirectToAction("Index", "Login");
            }
            catch
            {
                return View();
            }
        }
    }
}