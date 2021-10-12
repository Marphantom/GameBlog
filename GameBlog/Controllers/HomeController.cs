using GameBlog.Entities;
using GameBlog.Models;
using GameBlog.Models.Post;
using GameBlog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GameBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;
        private readonly ILogger<HomeController> _logger;
        private static Category category = new Category();
        private static List<Posts> posts = new List<Posts>();

        public HomeController(ILogger<HomeController> logger, IPostService postService)
        {
            _logger = logger;
            this.postService = postService;
        }

        public IActionResult Index()
        {
            posts = postService.GetAll();
            return View(posts);
        }
        [HttpGet]
        [Route("Home/BlogPage/{PostId}")]
        public IActionResult BlogPage(int PostId)
        {
            var post = postService.Get(PostId);
            var detailPost = new DetailPost()
            {
                CategoryId = post.CategoryId,
                PostId = post.PostId,
                PostName = post.PostName,
                PostContent = post.PostContent,
                Pictures = post.Pictures,
                DateSubmitted = post.DateSubmitted
            };
            ViewBag.Category = category;
            return View(detailPost);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
