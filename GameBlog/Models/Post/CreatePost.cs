using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameBlog.Models.Post
{
    public class CreatePost
    {
        [Required]
        [StringLength(500)]
        [Display(Name = "Post name")]
        public string PostName { get; set; }
        [Required]
        [Display(Name = "Post content")]
        [MaxLength]
        public string PostContent { get; set; }
        [Required]
        public string Pictures { get; set; }
        [Display(Name = "Date Submitted")]
        public DateTime DateSubmitted { get; set; }
        public int CategoryId { get; set; }
    }
}
