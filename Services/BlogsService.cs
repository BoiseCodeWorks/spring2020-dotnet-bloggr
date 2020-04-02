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

        internal Blog Create(Blog newBlog)
        {
            return _repo.Create(newBlog);
        }

        internal IEnumerable<Blog> GetUserBlogs(string userId)
        {
            return _repo.GetUserBlogs(userId);
        }

        internal Blog Get(int id)
        {
            //NOTE If you do not null check you could get a 204 (No Context) if the blog was not found
            Blog found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Blog Edit(Blog updatedBlog)
        {
            Blog found = Get(updatedBlog.Id);
            if (found.AuthorId != updatedBlog.AuthorId)
            {
                throw new Exception("Invalid Request");
            }
            found.Title = updatedBlog.Title;
            found.Body = updatedBlog.Body != null ? updatedBlog.Body : found.Body;
            return _repo.Edit(found);
        }

        internal Blog Delete(int id, string userId)
        {
            Blog found = Get(id);
            if (found.AuthorId != userId)
            {
                throw new Exception("Invalid Request");
            }
            if (_repo.Delete(id))
            {
                return found;
            }
            throw new Exception("Something went terribly wrong");
        }
    }
}