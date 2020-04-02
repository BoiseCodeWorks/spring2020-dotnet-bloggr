using System;
using System.Collections.Generic;
using bloggr.Models;
using bloggr.Repositories;

namespace bloggr.Services
{
    public class TagsService
    {
        private readonly TagsRepository _repo;
        public TagsService(TagsRepository repo)
        {
            _repo = repo;
        }
        internal IEnumerable<Tag> Get()
        {
            return _repo.Get();
        }

        internal Tag Create(Tag newTag)
        {
            return _repo.Create(newTag);
        }

    }
}