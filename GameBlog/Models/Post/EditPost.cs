using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBlog.Models.Post
{
    public class EditPost : CreatePost
    {
        public int PostId { get; set; }
    }
}
