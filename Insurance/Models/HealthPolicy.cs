using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Insurance.Models
{
    public class HealthPolicy
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Тип")]
        public string TypeHealth { get; set; } // A B or C type 

        [Display(Name = "Премија")]
        public int Premium { get; set; } // total premium for the policy

        [Display(Name = "Датум на потпишување")]
        [DataType(DataType.Date)] // agreedate for policy
        public DateTime? AgreeDate { get; set; }

        public int InsuredId { get; set; } // foreign key of insured
        public User Insured { get; set; } // info about the insured user

        public int PolicyId { get; set; } // foreign key of policy 
        public Policy Policy { get; set; } // info about the policy
    }
}
