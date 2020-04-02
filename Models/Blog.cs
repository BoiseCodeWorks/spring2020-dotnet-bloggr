using System.ComponentModel.DataAnnotations;

namespace bloggr.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        public string Body { get; set; }
        public string AuthorId { get; set; }
        public bool IsPrivate { get; set; }
    }

    public class BlogTagViewModel : Blog
    {
        public int blogTagId { get; set; }
    }

    // NOTE for Many-To-Many Table
    public class BlogTag
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int TagId { get; set; }
        public string AuthorId { get; set; }
    }
}
