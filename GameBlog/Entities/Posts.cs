using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameBlog.Entities
{
    public class Posts
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        [StringLength(500)]
        public string PostName { get; set; }
        [Required]
        [StringLength(10000)]
        public string PostContent { get; set; }
        [Required]
        public string Pictures { get; set; }
        public DateTime DateSubmitted { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
