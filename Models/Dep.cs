using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel; 

namespace PhoneAPI.Models
{
    public class Dep
    {
        [ScaffoldColumn(false)]
        [Key]
        public int dep_Id { get; set; }
        
        [DisplayName("Department Name")]
        [Required]
        public string dep_name { get; set; }
        
        [ScaffoldColumn(false)]
        [NotMapped]
        public string Self { get; set; }
    }
}