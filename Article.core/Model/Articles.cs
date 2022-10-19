using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.core.Model
{
    public class Articles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ArticleId { get; set; }
        [Required]
        public string ArticleDetails { get; set; }
        public DateTime ArticleTime { get; set; }
        public string CatigoryId { get; set; }
        [ForeignKey("CatigoryId")]
        [Required]
        public Catagory Catigory { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}
