using System.ComponentModel.DataAnnotations;

namespace bloggr.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        [Required]
        [MaxLength(240)]
        public string Body { get; set; }
        [Required]
        public int BlogId { get; set; }
    }
}