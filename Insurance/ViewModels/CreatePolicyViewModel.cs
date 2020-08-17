using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.ViewModels
{
    public class CreatePolicyViewModel
    {
        [Required]
        [Display(Name = "Тип на полиса")]
        public SelectList PolicyType { get; set; }

        public int OwnerId { get; set; }

        public IList<int> AgentIds { get; set; }

        public SelectList Agents { get; set; }


    }
}
