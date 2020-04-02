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

        internal Blog Create(Blog newBlog)
        {
            string sql = @"
            INSERT INTO blogs 
            (title, body, authorId, isPrivate) 
            VALUES 
            (@Title, @Body, @AuthorId, @IsPrivate);
            SELECT LAST_INSERT_ID()";
            newBlog.Id = _db.ExecuteScalar<int>(sql, newBlog);
            return newBlog;
        }

        internal Blog Get(int id)
        {
            string sql = "SELECT * FROM blogs WHERE id = @Id";
            return _db.QueryFirstOrDefault<Blog>(sql, new { Id = id });
        }

        internal IEnumerable<Blog> GetUserBlogs(string UserId)
        {
            string sql = "SELECT * FROM blogs WHERE authorId = @UserId";
            return _db.Query<Blog>(sql, new { UserId });
        }

        internal Blog Edit(Blog updatedBlog)
        {
            string sql = @"
            UPDATE blogs
            SET
                title = @Title,
                body = @Body
            WHERE id = @id
            ";
            _db.Execute(sql, updatedBlog);
            return updatedBlog;
        }

        internal IEnumerable<BlogTagViewModel> GetByTagId(int tagId)
        {
            string sql = @"
                SELECT 
                b.*
                bt.id AS blogTagId
                FROM blogtags bt
                INNER JOIN blogs b ON b.id = bt.blogId
                WHERE tagId = @tagId";
            return _db.Query<BlogTagViewModel>(sql, new { tagId });

        }

        internal bool Delete(int Id)
        {
            string sql = "DELETE FROM blogs WHERE id = @Id LIMIT 1";
            int removed = _db.Execute(sql, new { Id });
            return removed == 1;
        }
    }
}