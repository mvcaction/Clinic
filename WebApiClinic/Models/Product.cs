using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiClinic.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public System.DateTime SaveDate { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }
}