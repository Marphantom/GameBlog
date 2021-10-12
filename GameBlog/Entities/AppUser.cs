using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameBlog.Entities
{
    public class AppUser : IdentityUser
    {
        [StringLength(500)]
        public string Avatar { get; set; }
    }
}
