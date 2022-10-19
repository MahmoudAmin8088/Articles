using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.core.Model
{
    public class Catagory
    {
        [Key]
        public string CatigoryId { get; set; }
        public string CatigoryName { get; set; }
    }
}
