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
    public class Emp
    {
        [ScaffoldColumn(false)]
        [Key]
        public int emp_Id { get; set; }
        
        [DisplayName("Rank")]
        [Required]
        
        public int rank_Id { get; set; }
        [ForeignKey("rank_Id")]
        public virtual Rank rank { get; set; }

        [DisplayName("Department")]
        [Required]
        
        public int dep_Id { get; set; }
        [ForeignKey("dep_Id")]
        public virtual Dep dep { get; set; }
        [DisplayName("Phone")]
        [Required]
        [RegularExpression("([0-9-]{10})", ErrorMessage = "Enter only 10 numbers for phone and 10 digits")]
        [StringLength(10, ErrorMessage = "Phone Number length Should be 10 digits")] 
        public string phone { get; set; }
        
        [DisplayName("Mobile")]
        [Required]
        [RegularExpression("([0-9-]{10})", ErrorMessage = "Enter only numbers for mobile and 10 digits")]
        [StringLength(10, ErrorMessage = "Mobile Number length Should be 10 digits")] 
        public string mobile { get; set; }
        
        [DisplayName("Employee Name")]
        [Required]
        public string emp_name { get; set; }

        [ScaffoldColumn(false)]
        [NotMapped]
        public string Self { get; set; }
    }
}