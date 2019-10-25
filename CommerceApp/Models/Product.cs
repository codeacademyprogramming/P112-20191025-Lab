using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommerceApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public List<ProductTranslate> ProductTranslates { get; set; }
    }
}