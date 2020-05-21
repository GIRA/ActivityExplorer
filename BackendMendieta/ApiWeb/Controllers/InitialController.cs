using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ApiWeb.Controllers
{
    [Route("Home/[controller]")]

    public class InitialController : Controller
    {
        // /Home/Initial
        // GET: Initial

        //[HttpGet]
        //public Activity Get()
        //{
        //    Activity activity1 = new Activity();
        //    activity1.Id = "1";
        //    return activity1;
        //}
        [HttpGet]
        public ViewResult index()
        {

            return View();
        }

    }
}

















//// GET: Initial/Details/5
//public ActionResult Details(int id)
//{
//    return View();
//}

//// GET: Initial/Create
//public ActionResult Create()
//{
//    return View();
//}

//// POST: Initial/Create
//[HttpPost]
//[ValidateAntiForgeryToken]
//public ActionResult Create(IFormCollection collection)
//{
//    try
//    {
//        // TODO: Add insert logic here

//        return RedirectToAction(nameof(Index));
//    }
//    catch
//    {
//        return View();
//    }
//}

//// GET: Initial/Edit/5
//public ActionResult Edit(int id)
//{
//    return View();
//}

//// POST: Initial/Edit/5
//[HttpPost]
//[ValidateAntiForgeryToken]
//public ActionResult Edit(int id, IFormCollection collection)
//{
//    try
//    {
//        // TODO: Add update logic here

//        return RedirectToAction(nameof(Index));
//    }
//    catch
//    {
//        return View();
//    }
//}

//// GET: Initial/Delete/5
//public ActionResult Delete(int id)
//{
//    return View();
//}

//// POST: Initial/Delete/5
//[HttpPost]
//[ValidateAntiForgeryToken]
//public ActionResult Delete(int id, IFormCollection collection)
//{
//    try
//    {
//        // TODO: Add delete logic here

//        return RedirectToAction(nameof(Index));
//    }
//    catch
//    {
//        return View();
//    }
//}