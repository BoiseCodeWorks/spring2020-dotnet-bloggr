using System;
using System.Collections.Generic;
using System.Data;
using bloggr.Models;
using Dapper;

namespace bloggr.Repositories
{
    public class BlogsRepository
    {
        private readonly IDbConnection _db;
        public BlogsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Blog> GetPublic()
        {
            string sql = "SELECT * FROM blogs WHERE isPrivate = 0";
            return _db.Query<Blog>(sql);
        }
    }
}