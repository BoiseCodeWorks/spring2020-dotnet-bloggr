using System;
using System.Collections.Generic;
using System.Data;
using bloggr.Models;
using Dapper;

namespace bloggr.Repositories
{
    public class TagsRepository
    {
        private readonly IDbConnection _db;
        public TagsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Tag> Get()
        {
            string sql = "SELECT * FROM tags";
            return _db.Query<Tag>(sql);
        }

        internal Tag Create(Tag newTag)
        {
            string sql = @"
            INSERT INTO tags 
            (name) 
            VALUES 
            (@Name);
            SELECT LAST_INSERT_ID()";
            newTag.Id = _db.ExecuteScalar<int>(sql, newTag);
            return newTag;
        }
    }
}