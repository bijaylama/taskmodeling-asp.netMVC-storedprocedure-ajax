using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TaskProject.CommonClass;
using TaskProject.Models;

namespace TaskProject.Repo
{
    public class User
    {
        Common cm = new Common();
        public UserModel Login(UserModel user)
        {
                string data = "exec spUser @flag='j',@email = '" + user.Email + "', @password = '" + user.Password + "'";
                DataTable dt = cm.ExecuteDataset(data);
                UserModel result = new UserModel();
                if (dt != null)
                {
                    if(dt.Rows[0][0].ToString() == "ERROR"){
                        result.Error= dt.Rows[0][1].ToString();
                    }
                    else{
                        result.UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
                    result.FullName = dt.Rows[0]["Email"].ToString();
                    }
                    
                }

            else
            {
                result.Error = "Somthing went Wrong";
            }
                return result;
        }
        public string Register(UserModel user)
        {
            string result = "";

            try
            {
                string data = "exec spUser @flag = 'i', @fullname = '"+user.FullName+"', @email='"+user.Email+"', @password='"+user.Password+"', @address='"+user.Address+"', @contact='"+user.Contact+"'";
                DataTable dt = cm.ExecuteDataset(data);
                if (dt != null)
                {
                    if(dt.Rows[0][0].ToString() == "Sucess")
                    result = dt.Rows[0][1].ToString();
                }
            }
            catch
            {
                result = "Error";

            }
            return result;

        }

        // USER LIST
        public DataTable UserList()
        {
            string data = "exec spUser @flag = 'k'";
            DataTable dt = cm.ExecuteDataset(data);
            return dt;
        }

        // GET: USER /EDIT
        public UserModel UserEdit(int id)
        {
            string data = "exec spUser @flag = 'l', @id = '"+id+"'";
            UserModel user = new UserModel();
            DataTable dt = cm.ExecuteDataset(data);
            if (dt != null)
            {
                user.UserID =  Convert.ToInt32(dt.Rows[0]["UserID"]);
                user.FullName = dt.Rows[0]["FullName"].ToString();
                user.Email = dt.Rows[0]["Email"].ToString();
                user.Password = dt.Rows[0]["Password"].ToString();
                user.Address = dt.Rows[0]["Address"].ToString();
                user.Contact = dt.Rows[0]["Contact"].ToString();


            }
            else
            {
                user.Error = "Error";
            }
            return user;
        }
        // POST: USER/ EDIT
        public string UserEditSave(UserModel user)
        {
            string result = "";
            string data = "exec spUser @flag = 'm', @id = '" + user.UserID + "', @fullname = '" + user.FullName + "', @email='" + user.Email + "', @password='" + user.Password + "', @address='" + user.Address + "', @contact='" + user.Contact + "'";
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
                result = "Failed";
            }
           
            return result;

        }

        // EDIT: USER/ DETAIL
        public UserModel UserDetails(int id)
        {
            string data = "exec spUser @flag = 'l', @id = '"+id+"'";
            DataTable dt = cm.ExecuteDataset(data);
            UserModel user = new UserModel();
            if (dt != null)
            {
                user.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                user.FullName = dt.Rows[0]["FullName"].ToString();
                user.Email = dt.Rows[0]["Email"].ToString();
                user.Password = dt.Rows[0]["Password"].ToString();
                user.Address = dt.Rows[0]["Address"].ToString();
                user.Contact = dt.Rows[0]["Contact"].ToString();
            }
            else
            {
                user.Error = "Error";
            }
            return user;
        }
        public string UserDelete(int id)
        {
            string result = "";
            string data = "exec spUser @flag = 'n', @id = '"+id+"'";
            DataTable dt = cm.ExecuteDataset(data);
            if (dt != null)
            {
                if (dt.Rows[0][0].ToString() == "Success")
                result = dt.Rows[0][1].ToString();
            }
            else
            {
                result = "error";
            }
            return result;
        }
    }
}