using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.core.Model
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CommentId { get; set; }
        [Required]
        public string CommentDetails { get; set; }

        public DateTime CommentTime { get; set; }
        [Required]
        public string ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public Articles Article { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public string UserId { get; set; }

       
    }
}
