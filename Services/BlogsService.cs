using System;
using System.Collections.Generic;
using bloggr.Models;
using bloggr.Repositories;

namespace bloggr.Services
{
    public class BlogsService
    {
        private readonly BlogsRepository _repo;
        public BlogsService(BlogsRepository repo)
        {
            _repo = repo;
        }
        internal IEnumerable<Blog> Get()
        {
            return _repo.GetPublic();
        }

        internal object Create(Blog newBlog)
        {
            return newBlog;
        }
    }
}