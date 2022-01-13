using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskProject.CommonClass;
using TaskProject.Models;
using TaskProject.Repo;

namespace TaskProject.Controllers
{
    public class UserController : Controller
    {
        Common cm = new Common();
        User us = new User();
        //
        // GET: /User/
        public ActionResult Index()
        {
            if (Session["FullName"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View("Index");
            }
        }
        // GET: USER/LOGIN
        public ActionResult Login()
        {
            if (Session["FullName"] != null)
            {
                return RedirectToAction("Index");

            }
            else
            {
                return View();

            }
        }

        // POST: USER/LOGIN
        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            UserModel res = new UserModel();
            res = us.Login(user);
            string m = "";
                if (res.Error == null)
                {
                    Session["UserID"] = res.UserID;
                    Session["FullName"] = res.FullName;
                    m = "success";
                    return Json(m, JsonRequestBehavior.AllowGet);
                    
                }
                else
                {
                    m = res.Error.ToString();
                    return Json(m, JsonRequestBehavior.AllowGet);
                }
        

        }

        // GET: USER/LIST
        public ActionResult UserList()
        {
            if (Session["FullName"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                UserModel user = new UserModel();
                user.List = us.UserList();


                return PartialView("UserListPartial", user);
            }
            
        }

        //
        // GET: /User/Details/5
        public ActionResult Details(int id)
        {
            UserModel users = new UserModel();

            users = us.UserDetails(id);
            return PartialView("UserDetailsPartial", users);
        }

        //
        // GET: /User/Create
        public ActionResult Create()
        {
            return PartialView("UserCreatePartial");
        }

        //
        // POST: /User/Create
        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            try
            {
                string res = us.Register(user);

                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5
        public ActionResult Edit(int id)
        {
            UserModel user = new UserModel();
            user = us.UserEdit(id);
            return PartialView("UserEditPartial", user);
        }

        //
        // POST: /User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            try
            {
                string data = us.UserEditSave(user);
                    //string d = data.Status.ToString(); 
                return Json(data, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                return View();
            }

        }

    

        //
        // POST: /User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                string data = us.UserDelete(id);
                
                    return Json(data, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}
