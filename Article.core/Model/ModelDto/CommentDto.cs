using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.core.Model.ModelDto
{
    public class CommentDto
    {
        public string? CommentId { get; set; }
        [Required]
        public string? CommentDetails { get; set; }
        public DateTime CommentTime { get; set; }
        [Required]
        public string? UserId { get; set; }
        [Required]
        public string? ArticleId { get; set; }
    }
}
