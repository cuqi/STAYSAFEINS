using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Insurance.ViewModels
{
    public class CreateAgentViewModel
    {
        [Required]
        [StringLength(50)] // agent firstname
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)] // agent lastname
        [Display(Name = "Презиме")]
        public string LastName { get; set; }

        [Required]
        [StringLength(5)] // agentnumber is a unique 5 character string(made of numbers)
        public string AgentNumber { get; set; }

        [Display(Name = "Датум на раѓање")]
        [DataType(DataType.Date)] // birthdate of agent
        public DateTime BirthDate { get; set; }

        [Display(Name = "Датум на вработување")]
        [DataType(DataType.Date)] // hiredate of agent
        public DateTime HireDate { get; set; }

        public IFormFile UploadPicture { get; set; }
    }
}
