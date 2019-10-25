using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommerceApp.Models
{
    public class ProductTranslate
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int LanguageId { get; set; }

        public Language Language { get; set; }
        public Product Product { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}