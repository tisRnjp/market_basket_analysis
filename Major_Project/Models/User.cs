using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Major_Project.Models
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
    
}