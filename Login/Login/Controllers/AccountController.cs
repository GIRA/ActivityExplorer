using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis.Options;
using Login.Data;
using Login.Models;

namespace Login.Controllers
{
    public class AccountController : Controller
    {
        public static CAETIContext caetiContext;
        public static SignInManager<SystemUser> signInManager;
        public static UserManager<SystemUser> userManager;
        public AccountController(CAETIContext context, UserManager<SystemUser> user, SignInManager<SystemUser> signIn)
        {
            caetiContext = context;
            userManager = user;
            signInManager = signIn;
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
        public async Task<ActionResult> Create(RegisterViewModel registerViewModel) 
        {
            try
            {
                SystemUser systemUser = new SystemUser(registerViewModel.Id, registerViewModel.FirstName, registerViewModel.LastName,
                    registerViewModel.City, registerViewModel.Dni, registerViewModel.Email,
                    registerViewModel.PhoneNumber, registerViewModel.Institution,
                    registerViewModel.ImageFileName, registerViewModel.Password);

                if (caetiContext.SystemUser.Count() == 0)
                {
                    systemUser.Id = "0";
                }
                else
                {
                    systemUser.Id = (Convert.ToInt32(caetiContext.SystemUser.Max(u => u.Id)) + 1).ToString();
                }

                //await userManager.AddPasswordAsync(systemUser, registerViewModel.Password);
                await userManager.UpdateSecurityStampAsync(systemUser);
                caetiContext.SystemUser.Add(systemUser);
                await caetiContext.SaveChangesAsync();
                return Redirect("/Home/Index");
            }
            catch(Exception ex) 
            {
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