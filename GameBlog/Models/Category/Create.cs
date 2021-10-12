using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameBlog.Models.Category
{
    public class Create
    {
        [Required]
        [StringLength(200)]
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }
        [Required]
        [StringLength(500)]
        public string Picture { get; set; }
        public bool Status { get; set; }
    }
}
