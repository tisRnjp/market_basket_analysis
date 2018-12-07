using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Major_Project.Models
{
    public class CartViewModel
    {
        [Key]
        public int CartID { get; set; }
        public virtual List<item> SelectedProducts { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual item items { get; set; }
    }
}