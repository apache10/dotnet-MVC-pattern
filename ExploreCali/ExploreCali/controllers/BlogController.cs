using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCali.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExploreCali.controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //return new ContentResult { Content= "Blog Post" };

            var posts = new[]{
                new Post{
                    Title = "My First Blog",
                    Author = "Gaurav",
                    Posted = DateTime.Now,
                    Body = "this is my first post"
                },
                new Post{
                    Title = "My Second Blog",
                    Author = "Gaurav",
                    Posted = DateTime.Now,
                    Body = "this is my Second post"
                },
                new Post{
                    Title = "My Third Blog",
                    Author = "Gaurav",
                    Posted = DateTime.Now,
                    Body = "this is my Third post"
                }
            };
            return View(posts);
        }
        [Route("{year:min(1994)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, String key)
        {
            //return new ContentResult { Content = String.Format(
            //    "year : {0}; month : {1}; key : {2}", year, month, key
            //) };

            var post = new Post
            {
                Title = "My blog Post",
                Posted = DateTime.Now,
                Author = "Gaurav",
                Body = "This is the great post. do you think?",
            };
            return View(post);
        }
    }

}
