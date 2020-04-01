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
}
