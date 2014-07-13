using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneAPI.Models
{
    public class EmpModel
    {
        public int emp_Id { get; set; }
        public int rank_Id { get; set; }
        public int dep_Id { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string emp_name { get; set; }
    }
}