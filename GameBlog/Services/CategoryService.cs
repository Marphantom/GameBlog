using GameBlog.Contexts;
using GameBlog.Entities;
using GameBlog.Models.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBlog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly GameBlogDBContext context;

        public CategoryService(GameBlogDBContext context)
        {
            this.context = context;
        }

        public bool ChangeStatus(int categoryId)
        {
            try
            {
                var category = Get(categoryId);
                category.Status = !category.Status;
                context.Attach(category);
                context.Entry(category).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Create(Create create)
        {
            try
            {
                var category = new Category()
                {
                    CategoryName = create.CategoryName,
                    Picture = create.Picture,
                    Status = create.Status
                };
                context.Add(category);
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Edit edit)
        {
            try
            {
                var category = Get(edit.CategoryId);
                category.CategoryName = edit.CategoryName;
                category.Picture = edit.Picture;
                category.CategoryId = edit.CategoryId;
                category.Status = edit.Status;
                context.Attach(category);
                context.Entry(category).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public Category Get(int CategoryId)
        {
            return context.Categories.FirstOrDefault(c => c.CategoryId == CategoryId);
        }

        public List<Category> Gets()
        {
            return context.Categories.Include(p => p.Posts).ToList();
        }
    }
}
