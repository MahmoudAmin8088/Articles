using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.core.Model.ModelDto
{
    public class ArticleDto
    {

        public string? ArticleId { get; set; }

        [Required]
        public string? ArticleDetails { get; set; }

        public DateTime ArticleTime { get; set; }
        [Required]
        public string? CatigoryId { get; set; }
        [Required]
        public string? UserId { get; set; }
    }
}
