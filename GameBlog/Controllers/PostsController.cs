using GameBlog.Contexts;
using GameBlog.Entities;
using GameBlog.Models.Post;
using GameBlog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBlog.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private static Category category = new Category();

        public PostsController(IPostService postService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            this.postService = postService;
            this.categoryService = categoryService;
            this.webHostEnvironment = webHostEnvironment;

        }
        [Route("/Posts/Index/{catId}")]
        public IActionResult Index(int catId)
        {
            category = categoryService.Get(catId);
            ViewBag.Category = category;
            return View(postService.GetPostByCategoryId(catId));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePost model)
        {
            if(ModelState.IsValid)
            {
                var posts = new Posts()
                {
                    CategoryId = model.CategoryId,
                    PostName = model.PostName,
                    PostContent = model.PostContent,
                    Pictures = model.Pictures,
                    DateSubmitted = DateTime.Now
                };
                if(postService.Create(posts))
                {
                    return RedirectToAction("index", new { catId = category.CategoryId });
                }
            }
            ViewBag.Category = category;
            return View(model);
        }

        [HttpGet]
        [Route("Posts/Detail/{PostId}")]
        public IActionResult Detail(int PostId)
        {
            var post = postService.Get(PostId);
            var detailPost = new DetailPost()
            {
                CategoryId = post.CategoryId,
                PostId = post.PostId,
                PostName = post.PostName,
                PostContent = post.PostContent,
                Pictures = post.Pictures,
                DateSubmitted = DateTime.Now
            };
            ViewBag.Category = category;
            return View(detailPost);
        }

        [HttpGet]
        [Route("Product/Remove/{PostId}")]
        public IActionResult Remove(int PostId)
        {
            if (postService.Remove(PostId))
            {
                return RedirectToAction("Index", "Posts", new { catId = category.CategoryId });
            }
            return RedirectToAction("Index", "Detail", new { postId = PostId });
        }

        [HttpGet]
        [Route("Posts/Edit/{PostId}")]
        public IActionResult Edit(int PostId)
        {
            var post = postService.Get(PostId);
            var editpost = new EditPost()
            {
                CategoryId = post.CategoryId,
                PostId = post.PostId,
                PostName = post.PostName,
                PostContent = post.PostContent,
                Pictures = post.Pictures,
                DateSubmitted = post.DateSubmitted
            };
            ViewBag.Category = category;
            return View(editpost);
        }

        [HttpPost]
        public IActionResult Edit(EditPost model)
        {
            if (ModelState.IsValid)
            {
                if (postService.Edit(model))
                {
                    return RedirectToAction("Index", "Posts", new { catId = category.CategoryId });
                }
            }
            return View(model);
        }

        public IActionResult ViewAllPost()
        {
            ViewBag.Category = category;
            return View(postService.GetAll());
        }

        public IActionResult Search(string term)
        {
            return View("ViewAllPost", postService.Search(term));
        }
    }
}
