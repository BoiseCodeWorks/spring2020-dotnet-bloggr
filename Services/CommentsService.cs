using System;
using System.Collections.Generic;
using bloggr.Models;
using bloggr.Repositories;

namespace bloggr.Services
{
    public class CommentsService
    {
        private readonly CommentsRepository _repo;
        public CommentsService(CommentsRepository repo)
        {
            _repo = repo;
        }
        internal IEnumerable<Comment> GetByBlogId(int blogId)
        {
            return _repo.GetByBlogId(blogId);
        }

        internal Comment Create(Comment newComment)
        {
            return _repo.Create(newComment);
        }

        private Comment Get(int id)
        {
            //NOTE If you do not null check you could get a 204 (No Context) if the Comment was not found
            Comment found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Comment Edit(Comment updatedComment)
        {
            Comment found = Get(updatedComment.Id);
            if (found.AuthorId != updatedComment.AuthorId)
            {
                throw new Exception("Invalid Request");
            }
            found.Body = updatedComment.Body;
            return _repo.Edit(found);
        }

        internal Comment Delete(int id, string userId)
        {
            Comment found = Get(id);
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