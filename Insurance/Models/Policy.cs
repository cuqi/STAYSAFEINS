using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Insurance.Models
{
    public class Policy
    {
        [Key] // autoincrement id for policy
        public int Id { get; set; }

        [Required] // policynumber is a unique 5 character string(made of numbers)
        [StringLength(5)]
        public string PolicyNumber { get; set; }

        [Display(Name = "Тип")]
        public string PolicyType { get; set; } // the type of policy

        public int OwnerId { get; set; } // insured user id

        [Display(Name = "Осигуреник")]
        public User Owner { get; set; } // info about insured

        public int AgentId { get; set; } // agent for the policy

        [Display(Name = "Агент")]
        public Agent Agent { get; set; } // info about the agent

        [Display(Name = "Каско полиса")]
        public CascoPolicy CP { get; set; }

        [Display(Name = "Патничко")]
        public TravelPolicy TP { get; set; }

        [Display(Name = "Здравствено")]
        public HealthPolicy HP { get; set; }

    }
}
