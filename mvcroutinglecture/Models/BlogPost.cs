using System;
using System.Collections.Generic;

namespace mvcroutinglecture.Models
{
    class BlogPost
    {
        public int id {get;set;}
        public string title {get;set;}
        public string text {get;set;}

        public BlogPost() // default no arg constructor
        {

        }
        public BlogPost(int id, string title, string text) // main constructor
        {
            this.id = id;
            this.title = title;
            this.text = text;
        }

        public List<BlogPost> getPosts() // kludgy way get some test post data
        {
            List<BlogPost> posts = new List<BlogPost>();
            posts.Add(new BlogPost(10, "First Post!", "Here is my post"));
            posts.Add(new BlogPost(1, "New Post!", "Here is my New post"));
            posts.Add(new BlogPost(15, "Last Post!", "Here is my Last post"));
            return posts;
        }
    }
}