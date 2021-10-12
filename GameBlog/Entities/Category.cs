using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameBlog.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(200)]
        public string CategoryName { get; set; }
        [Required]
        [StringLength(500)]
        public string Picture { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public bool Status { get; set; }
    }
}
