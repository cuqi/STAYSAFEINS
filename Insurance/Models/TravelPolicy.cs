using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Insurance.Models
{
    public class TravelPolicy
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Тип")]
        public string TypeTravel { get; set; } // Classic , Classic Plus and Visa

        [Display(Name = "Осигурани денови")]
        public int DayCount { get; set; } // number of days for the policy

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
