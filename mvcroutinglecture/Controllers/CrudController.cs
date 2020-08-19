using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using mvcroutinglecture.Models;

namespace mvcroutinglecture.Controllers
{
    public class CrudController : Controller
    {
        List<BlogPost> blogPosts = new List<BlogPost>();

        // Sanity
        public IActionResult Index()
        {
            BlogPost testPost = new BlogPost();
            blogPosts = testPost.getPosts();
            return Content(printPostList());
        }

        // Helper method to print all the sample blog posts
        private string printPostList()
        {
            string result = "";
            foreach (BlogPost post in blogPosts)
            {
                result = result + ($"\nPost ID: {post.id}\nPost Title: {post.title}\nPost Text: {post.text}\n");
            }
            return result;
        }

        // Get all posts
        public IActionResult Posts()
        {
            BlogPost testPost = new BlogPost(); // kludgy dummy data
            blogPosts = testPost.getPosts();
            return Content(printPostList());
        }

        // Get a specific post
        public IActionResult Post(int id)
        {
            BlogPost testPost = new BlogPost(); // kludgy dummy data
            blogPosts = testPost.getPosts();
            int index = blogPosts.FindIndex(post => post.id == id);
            if (index >= 0)
            {
                return Content($"\nPost ID: {blogPosts[index].id}\nPost Title: {blogPosts[index].title}\nPost Text: {blogPosts[index].text}\n");
            }
            else
            {
                return Content($"Blog post with ID of {id} was not found!");
            }
        }

        // Create a new post
        [HttpPost]
        public IActionResult CreatePost(int id, string title, string text)
        {
            BlogPost newPost = new BlogPost(id, title, text);
            return Content($"\nNew Post Created!\nPost ID: {newPost.id}\nPost Title: {newPost.title}\nPost Text: {newPost.text}\n");
        }

        // Update a post
        [HttpPut]
        public IActionResult UpdatePost(int id, string title, string text)
        {
            // lookup the item to update
            BlogPost testPost = new BlogPost(); // kludgy dummy data
            blogPosts = testPost.getPosts();
            int index = blogPosts.FindIndex(post => post.id == id);
            if (index >= 0) // if found
            {
                // Make the updates
                blogPosts[index].id = id;
                blogPosts[index].title = title;
                blogPosts[index].text = text;
                // return the updated post    
                return Content($"\nUpdated post:\nPost ID: {blogPosts[index].id}\nPost Title: {blogPosts[index].title}\nPost Text: {blogPosts[index].text}\n");
            }
            else
            {
                return Content($"Blog post with ID of {id} was not found!");
            }
        }

        // delete post
        [HttpDelete]
        public IActionResult DeletePost(int id)
        {
            BlogPost testPost = new BlogPost(); // kludgy dummy data
            blogPosts = testPost.getPosts();
            int index = blogPosts.FindIndex(post => post.id == id);
            if (index >= 0)
            {
                // pretend delete
                return Content($"\nPOST DELETED!!\nPost ID: {blogPosts[index].id}\nPost Title: {blogPosts[index].title}\nPost Text: {blogPosts[index].text}\n");
            }
            else
            {
                return Content($"Blog post with ID of {id} was not found!");
            }
        }
    }
}










