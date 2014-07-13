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
    public class Rank
    {
        [ScaffoldColumn(false)]
        [Key]
        public int rank_Id { get; set; }

         
        [DisplayName("Rank Name")]
        [Required]
        public string rank_name { get; set; }
        [ScaffoldColumn(false)]
        [NotMapped]
        public string Self { get; set; }

    }
}