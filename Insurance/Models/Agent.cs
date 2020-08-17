using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Insurance.Models
{
    public class Agent
    {
        [Key] // id for autoincrement
        public int Id { get; set; }

        [Required]
        [StringLength(5)] // agentnumber is a unique 5 character string(made of numbers)
        public string AgentNumber { get; set; }

        [Required]
        [StringLength(50)] // agent firstname
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)] // agent lastname
        public string LastName { get; set; }

        public int Age
        { // age of the agent
            get
            {
                TimeSpan span = DateTime.Now - BirthDate;
                double years = (double)span.TotalDays / 365.2425;
                return (int)years;
            }
        }

        public int PolicyCount { get; set; } // the number of policies the agent has

        [Display(Name = "Датум на раѓање")]
        [DataType(DataType.Date)] // birthdate of agent
        public DateTime BirthDate { get; set; }

        [Display(Name = "Датум на вработување")]
        [DataType(DataType.Date)] // hiredate of agent
        public DateTime HireDate { get; set; }

        public string ProfilePicture { get; set; }

        public List<Policy> Policies { get; set; } // list of policies the agent has
    }
}
