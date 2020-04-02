using System;
using System.Collections.Generic;
using System.Data;
using bloggr.Models;
using Dapper;

namespace bloggr.Repositories
{
    public class CommentsRepository
    {
        private readonly IDbConnection _db;
        public CommentsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Comment> GetByBlogId(int BlogId)
        {
            string sql = "SELECT * FROM comments WHERE blogId = @BlogId";
            return _db.Query<Comment>(sql, new { BlogId });
        }

        internal Comment Create(Comment newComment)
        {
            string sql = @"
            INSERT INTO comments 
            (body, authorId, blogId) 
            VALUES 
            (@Body, @AuthorId, @BlogId);
            SELECT LAST_INSERT_ID()";
            newComment.Id = _db.ExecuteScalar<int>(sql, newComment);
            return newComment;
        }

        internal Comment Get(int id)
        {
            string sql = "SELECT * FROM comments WHERE id = @Id";
            return _db.QueryFirstOrDefault<Comment>(sql, new { Id = id });
        }

        internal Comment Edit(Comment updatedComment)
        {
            string sql = @"
            UPDATE comments
            SET

                body = @Body
            WHERE id = @id
            ";
            _db.Execute(sql, updatedComment);
            return updatedComment;
        }

        internal bool Delete(int Id)
        {
            string sql = "DELETE FROM comments WHERE id = @Id LIMIT 1";
            int removed = _db.Execute(sql, new { Id });
            return removed == 1;
        }
    }
}