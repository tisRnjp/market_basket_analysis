using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Major_Project.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Display(Name = "Category")]
        public string Title { get; set; }

       // public virtual ICollection<Product> Products { get; set; }
    }
}