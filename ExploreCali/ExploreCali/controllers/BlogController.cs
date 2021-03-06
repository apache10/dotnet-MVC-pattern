﻿using System;
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
        private readonly BlogDataContext _db;
        public BlogController(BlogDataContext db){
            _db =  db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            //return new ContentResult { Content= "Blog Post" };

            var posts = _db.Posts.OrderByDescending(x => x.Posted).Take(5).ToArray();
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
        [HttpGet,Route("create")]
        public IActionResult Create(){
            return View();
        }
        [HttpPost,Route("create")]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View();
            //over writing the field
            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;

            _db.Posts.Add(post);
            _db.SaveChanges();

            return RedirectToAction("Post", "Blog", new
            {
                year = post.Posted.Year,
                month = post.Posted.Month,
                key = post.Key
            });
        }
        //public class CreatePostRequest {
        //    public string Title { get; set; }
        //    public string Body{ get; set; }
        //}

    }

}
