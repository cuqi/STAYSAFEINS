using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Insurance.Models
{
    public class CascoPolicy
    {
        [Key] //autoincrement for cascopolicy id
        public int Id { get; set; }

        [Required]
        [StringLength(17)] // the chassis number of the vehicle
        [Display(Name = "Број на шасија")]
        public string Chassis { get; set; }

        [Required]
        [StringLength(8)] // the registration number of the vehicle
        [Display(Name = "Број на регистрација")]
        public string Registration { get; set; }

        [Display(Name = "KW")]
        public int Power { get; set; } // horsepower of the vehicle

        [Display(Name = "Зафатнина")]
        public int Volume { get; set; } // volume of the vehicle

        [Display(Name = "Премија")]
        public int Premium { get; set; } // total premium for the policy

        [Display(Name = "Боја на автомобилот")]
        public string VehicleColor { get; set; } // the color of the vehicle

        [Display(Name = "Датум на потпишување")]
        [DataType(DataType.Date)] // agreedate for policy
        public DateTime? AgreeDate { get; set; }

        public int PolicyId { get; set; } // foreign key of policy 

        public Policy Policy { get; set; }

    }
}
