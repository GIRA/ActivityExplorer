using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Login.Data;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity;

namespace Login.Controllers
{
    public class AccountController : Controller
    {
        public static CAETIContext caetiContext;
        public static SignInManager<SystemUser> signInManager;
        public static UserManager<SystemUser> userManager;
        public AccountController()
        {
           caetiContext = new CAETIContext();
        }
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        // GET: Register/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemUser systemUser)
        {
            try
            {
                if (caetiContext.SystemUser.Count() == 0)
                {
                    systemUser.SystemUserId = 0;
                }
                else
                {
                    systemUser.SystemUserId = caetiContext.SystemUser.Max(u => u.SystemUserId) + 1;
                }                
                caetiContext.SystemUser.Add(systemUser);
                caetiContext.SaveChanges();
                signInManager.SignInAsync(systemUser, false);
                return Redirect("/Home/Index");
            }
            catch(Exception ex)
            {
                string message = ex.Message;
                return View();
            }
        }

        // GET: Register/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Register/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Register/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Register/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}