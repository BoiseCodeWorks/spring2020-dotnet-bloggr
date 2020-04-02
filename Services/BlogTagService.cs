using System;
using System.Collections.Generic;
using bloggr.Models;
using bloggr.Repositories;

namespace bloggr.Services
{
    public class BlogTagsService
    {
        private readonly BlogTagsRepository _repo;
        public BlogTagsService(BlogTagsRepository repo)
        {
            _repo = repo;
        }
        internal BlogTag Create(BlogTag newBlogTag)
        {
            return _repo.Create(newBlogTag);
        }

        internal BlogTag Delete(int id, string UserId)
        {
            BlogTag found = _repo.Get(id);
            if (found.AuthorId != UserId)
            {
                throw new UnauthorizedAccessException("Invalid Request");
            }
            if (_repo.Delete(id))
            {
                return found;
            }
            throw new Exception("Something went terribly wrong");
        }
    }
}