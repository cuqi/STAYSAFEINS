using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Insurance.Models
{
    public class Case
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string CaseNumber { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Датум на незгодата")]
        [DataType(DataType.Date)] // accidentdate for case
        public DateTime? AccidentDate { get; set; }
        public int UserId { get; set; } // foreign key of policy
        public User User { get; set; } // info about the policy
    
        public string Picture { get; set; }
    }
}