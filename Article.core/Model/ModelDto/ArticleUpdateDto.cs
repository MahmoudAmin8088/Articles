using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.core.Model.ModelDto
{
    public class ArticleUpdateDto
    {
        public string? ArticleId { get; set; }
        [Required]
        public string? ArticleDetails { get; set; }

    }  
}
