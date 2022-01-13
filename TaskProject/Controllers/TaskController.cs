using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskProject.Models;
using TaskProject.Repo;
using TaskProject.CommonClass;


namespace TaskProject.Controllers

{
    public class TaskController : Controller
    {
        Common cm = new Common();
        Tasks tk = new Tasks();
        //
        // GET: /Task/
        public ActionResult Index()
        {
            if (Session["FullName"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View();

            }
        }

        // GET: TASK/LIST WITH CATEGORY
        public ActionResult TaskList()
        {
            if (Session["FullName"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                TaskModel task = new TaskModel();

                //task.ListCategory = tk.GetCategory();
                //task.ListPriority = tk.GetPriority();
                //task.ListUser = tk.GetUser();
                //task.List = tk.TaskList();

                task.ListCategory = tk.GetCategory();
                task.ListPriority = tk.GetPriority();
                task.ListUser = tk.GetUser();
                task.List = tk.TaskList();

                return PartialView("TaskListPartial", task);
            }
            
        }

        // GET: TASK/CATEGORY
        public ActionResult TaskCategoryCreate()
        {
            return PartialView("TaskCategoryCreatePartial");
        }
        // POST: TASK/CATEGORY
        [HttpPost]
        public ActionResult TaskCategoryCreate(TaskModel task)
        {
            return View();
        }
        
        //
        // GET: /Task/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Task/Create TASK
        public ActionResult Create()
        {
            TaskModel ut = new TaskModel();


            ut.categories = tk.getallcategory();
            ut.priorities = tk.getallpriority();
            ut.users = tk.getallusers();
            
            ut.users = tk.getallusers();
            //ViewBag.Cat = cm.ExecuteDataset("select TaskCatID, TCName from TaskCategory");

           
            return PartialView("TaskCreatePartial", ut);
        }

        //
        // POST: /Task/Create TASK
        [HttpPost]
        public ActionResult Create(TaskModel task)
        {
            try
            {
                string res = tk.SaveTaskCreate(task);
                
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Task/Edit/5
        [HttpPost]
       


        public ActionResult Edit(string id, string taskid, string type)
        {
            try
            {
                string result = "";
                if (type == "p")
                {
                var res = tk.UpdateTaskPriority(id, taskid);
                result = res;
                }
                else if (type == "c")
                {
                    var resCat = tk.UpdateTaskCategory(id, taskid);
                    result = resCat;
                }
                else if (type == "u")
                {
                    var resUser = tk.UpdateTaskUser(id, taskid);
                    result = resUser;
                }
                else
                {
                    result = "fuck";
                }


                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return View();
            }
        }
        //
        // GET: /Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
