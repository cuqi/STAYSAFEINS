using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Insurance.Models;

namespace Insurance.ViewModels
{
    public class ReportCaseViewModel
    {
        public User User { get; set; } // info about the policy

        public int UserId { get; set; }
        public string Description { get; set; }

        public string CaseNumber { get; set; }

        [Display(Name = "Датум на незгодата")]
        [DataType(DataType.Date)] // accidentdate for case
        public DateTime? AccidentDate { get; set; }

        [Required(ErrorMessage = "Please upload images of the case!")]
        [Display(Name = "Слики од незгодата")]
        public IFormFile UploadPicture { get; set; }
    }
}
