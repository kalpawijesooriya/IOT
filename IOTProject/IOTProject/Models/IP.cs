using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IOTProject.Models
{
    public class IP
    {
        [Key]
        public int RaspBerryID { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
       
    }
}