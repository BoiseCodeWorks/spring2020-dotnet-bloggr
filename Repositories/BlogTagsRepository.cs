using System;
using System.Collections.Generic;
using System.Data;
using bloggr.Models;
using Dapper;

namespace bloggr.Repositories
{
    public class BlogTagsRepository
    {
        private readonly IDbConnection _db;
        public BlogTagsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal BlogTag Create(BlogTag newBlogTag)
        {
            string sql = @"
            INSERT INTO blogtags 
            (blogId, tagId, authorId) 
            VALUES 
            (@BlogId, @TagId, @AuthorId);
            SELECT LAST_INSERT_ID()";
            newBlogTag.Id = _db.ExecuteScalar<int>(sql, newBlogTag);
            return newBlogTag;
        }

        internal BlogTag Get(int Id)
        {
            string sql = "SELECT * FROM blogtags WHERE id = @Id";
            return _db.QueryFirstOrDefault<BlogTag>(sql, new { Id });
        }

        internal bool Delete(int Id)
        {
            string sql = "DELETE FROM blogtags WHERE id = @Id LIMIT 1";
            int removed = _db.Execute(sql, new { Id });
            return removed == 1;
        }
    }
}