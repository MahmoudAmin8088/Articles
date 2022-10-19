using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.core.Model.ModelDto
{
    public class CommentUpdateDto
    {
        public string? CommentId { get; set; }
        [Required]
        public string? CommentDetails { get; set; }
    }
}
