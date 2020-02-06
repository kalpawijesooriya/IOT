using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IOTProject.Models
{
    public class Issues
    {
        [Key]
        public int ID { get; set; }
        public string DefectID { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime ResponceTime { get; set; }
        public bool status { get; set; }
    }
}