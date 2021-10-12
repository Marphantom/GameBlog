using GameBlog.Entities;
using GameBlog.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBlog.Services
{
    public interface IPostService
    {
        List<Posts> GetPostByCategoryId(int categoryId);
        bool Create(Posts model);
        Posts Get(int PostId);
        bool Remove(int PostId);
        bool Edit(EditPost model);
        List<Posts> GetAll();
        Posts[] Search(string search);

    }
}
