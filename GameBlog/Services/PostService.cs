using GameBlog.Contexts;
using GameBlog.Entities;
using GameBlog.Models.Post;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBlog.Services
{
    public class PostService : IPostService
    {
        private readonly GameBlogDBContext context;

        public PostService(GameBlogDBContext context)
        {
            this.context = context;
        }
        public bool Create(Posts model)
        {
            try
            {
                context.Add(model);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(EditPost model)
        {
            try
            {
                var post = Get(model.PostId);
                post.PostName = model.PostName;
                post.PostContent = model.PostContent;
                post.Pictures = model.Pictures;
                post.DateSubmitted = model.DateSubmitted;
                post.CategoryId = model.CategoryId;
                context.Attach(post);
                context.Entry(post).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public Posts Get(int PostId)
        {
            return context.Posts.Include(p => p.Category).FirstOrDefault(p => p.PostId == PostId);
        }

        public List<Posts> GetAll()
        {
            return context.Posts.ToList();
        }

        public List<Posts> GetPostByCategoryId(int categoryId)
        {
            return context.Posts.Include(p => p.Category).Where(p => p.CategoryId == categoryId).ToList();
        }

        public bool Remove(int PostId)
        {
                try
                {
                    var post = Get(PostId);
                    context.Remove(post);
                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
        }

        public Posts[] Search(string search)
        {
            
            var s = search.ToLower();
            return context.Posts.Where(p => p.PostName.ToLower().Contains(s)).ToArray();
        }
    }
}
