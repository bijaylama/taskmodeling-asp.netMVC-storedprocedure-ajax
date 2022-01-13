using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TaskProject.Models
{
    public class TaskModel
    {
        public int TaskID { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string TaskBody { get; set; }
        [Required]

        public DateTime ExpireDate { get; set; }
        [Required]

        public int PriorityID { get; set; }
        [Required]

        public string PriorityName { get; set; }
        public string Image { get; set; }
        [Required]
        public int UserID { get; set; }
        public int TaskCatID { get; set; }
        public string TCName { get; set; }
        public DataTable List { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public DataTable ListPriority { get; set; }
        public DataTable ListCategory { get; set; }
        public DataTable ListUser { get; set; }
        public IEnumerable<SelectListItem> categories { get; set; }
        public IEnumerable<SelectListItem> priorities { get; set; }
        public IEnumerable<SelectListItem> users { get; set; }


    }
}