using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication.Arch.Models
{
    public class mCategory
    {


        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category name is a required feild.")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Category description is a required feild.")]
        public string Description { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }


        public string CategoryTitle { get { return CategoryName + Description; } }

        public string Title() => CategoryName + Description;


    }
}