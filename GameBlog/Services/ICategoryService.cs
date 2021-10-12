using GameBlog.Entities;
using GameBlog.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBlog.Services
{
    public interface ICategoryService
    {
        List<Category> Gets();
        Category Get(int CategoryId);
        bool Create(Create create);
        bool Edit(Edit edit);
        bool ChangeStatus(int categoryId);
    }
}
