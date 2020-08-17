using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Insurance.Models
{
    public class User
    {
        [Key] //autoincrement id 
        public int Id { get; set; }

        [Required]
        [StringLength(50)] // user firstname
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)] // user lastname
        public string LastName { get; set; }

        [Required]
        [StringLength(13)] //user unique number
        public string EMBG { get; set; }

        [Display(Name = "Датум на раѓање")]
        [DataType(DataType.Date)] // birthdate of user
        public DateTime BirthDate { get; set; }

        public int Age
        { // age of the agent
            get
            {
                TimeSpan span = DateTime.Now - BirthDate;
                double years = (double)span.TotalDays / 365.2425;
                return (int)years;
            }
        }
        public List<Policy> Policies { get; set; } // list of policies the user has

        public List<Case> Cases { get; set; } // list of cases the user has
    }
}
