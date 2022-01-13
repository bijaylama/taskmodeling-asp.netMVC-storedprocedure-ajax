using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskProject.CommonClass;
using TaskProject.Models;

namespace TaskProject.Repo
{
    public class Tasks
    {
        Common cm = new Common();

        //
        // GET: TASK/CREATE LIST WITH CATEGORY
        public DataTable TaskList()
        {
            string data = "exec spTask @flag = 'd'";
            DataTable dt = cm.ExecuteDataset(data);

            return dt;
        }
        // POST: CREATE TASK CATEGORY
        public string TaskCatCreate(TaskModel task)
        {
            string result = "";
            try
            {
                string data = "exec spTask @flag = 'c', @taskcatid = '" + task.TaskCatID + "', @tcname='" + task.TCName + "'";
                DataTable dt = cm.ExecuteDataset(data);
                if (dt != null)
                {
                    result = dt.Rows[0][0].ToString();
                }
            }
            catch
            {
                result = "Error";

            }
            return result;
        }

      // <LIST> CATEGORIES /TASK/CREATE
        public List<SelectListItem> getallcategory()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string cat = "select TaskCatID, TCName from TaskCategory";
            DataTable dt = cm.ExecuteDataset(cat);
            foreach (DataRow dr in dt.Rows)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text = dr["TCName"].ToString(),
                        Value = dr["TaskCatID"].ToString()
                    }
                    );
            }
            return items;
        }

        // <LIST> PRIORITY /TASK/CREATE
        public List<SelectListItem> getallpriority()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string cat = "select * from Priority";
            DataTable dt = cm.ExecuteDataset(cat);
            foreach (DataRow dr in dt.Rows)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text = dr["PriorityName"].ToString(),
                        Value = dr["PriorityID"].ToString()
                    }
                    );
            }
            return items;
        }

        // <LIST> USERS /TASK/CREATE
        public List<SelectListItem> getallusers()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string cat = "select UserID, FullName from [User]";
            DataTable dt = cm.ExecuteDataset(cat);
            foreach (DataRow dr in dt.Rows)
            {
                items.Add(
                    new SelectListItem
                    {
                        Text = dr["FullName"].ToString(),
                        Value = dr["UserID"].ToString()
                    }
                    );
            }
            return items;
        }


        //GET: TASK/CREATE SELECT ALL CATEGORY
        public DataTable GetCategory()
        {

            string cat = "select TaskCatID, TCName from TaskCategory";
            DataTable dt = cm.ExecuteDataset(cat);
            return dt;
        }

        //GET: TASK/CREATE SELECT ALL PRIORITY
        public DataTable GetPriority()
        {

            string dropdown = "select * from Priority";
            DataTable dt = cm.ExecuteDataset(dropdown);
            
            return dt;
        }

        //GET: TASK/CREATE SELECT ALL USER
        public DataTable GetUser()
        {
            string dropdown = "select UserID, FullName from [User]";
            DataTable dt = cm.ExecuteDataset(dropdown);

            return dt;
        }


        // POST: TASK CREATE
        public string SaveTaskCreate(TaskModel model)
        {
            string result = "";
            DateTime now = DateTime.Now;
            TaskModel tm = new TaskModel();
            try
            {
                string data = "exec spTask @flag = 'a', @title = '" + model.Title + "', @taskbody ='" + model.TaskBody + "', @date ='" + now + "', @expiredate='" + model.ExpireDate + "', @priorityid ='" + model.PriorityID + "', @taskcatid = '" + model.TaskCatID + "', @userid = '"+model.UserID+"'";
                DataTable dt = cm.ExecuteDataset(data);
                if (dt != null)
                {
                    if (dt.Rows[0][0].ToString() == "success..")
                    {
                        result = dt.Rows[0][1].ToString();
                    }
                }
            }
            catch
            {
                result = "Error";

            }
            return result;
        }

        public string UpdateTaskPriority(string id, string priority)
        {
            string result = "";
            string data = "exec spTask @flag = 'b', @priorityid = '" + priority + "', @taskid = '"+id+"'";
            DataTable dt = cm.ExecuteDataset(data);
            if (dt != null)
            {
                if (dt.Rows[0][0].ToString() == "success..")
                {
                    result = dt.Rows[0][1].ToString();
                }
            }
            else
            {
                result = "Error";
            }
            return result;
        }
        // TASK/EDIT UPDATE CATEGORY DROPDOWN
        public string UpdateTaskCategory(string id, string category)
        {
            string result = "";
            string data = "exec spTask @flag = 'e', @taskcatid = '" + category + "', @taskid = '" + id + "'";
            DataTable dt = cm.ExecuteDataset(data);
            if (dt != null)
            {
                if (dt.Rows[0][0].ToString() == "success..")
                {
                    result = dt.Rows[0][1].ToString();
                }
            }
            else
            {
                result = "Error";
            }
            return result;
        }

        // TASK/EDIT UPDATE USERS DROPDOWN
        public string UpdateTaskUser(string id, string user)
        {
            string result = "";
            string data = "exec spTask @flag = 'f', @userid = '" + user + "', @taskid = '" + id + "'";
            DataTable dt = cm.ExecuteDataset(data);
            if (dt != null)
            {
                if (dt.Rows[0][0].ToString() == "success..")
                {
                    result = dt.Rows[0][1].ToString();
                }
            }
            else
            {
                result = "Error";
            }
            return result;
        }
    }
}