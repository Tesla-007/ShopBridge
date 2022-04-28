using Product.Domain.Entities;
using Product.Domain.ProductDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeProduct.ShopModels
{
    public class ProductModel
    {
      

        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CatId { get; set; }
        
    }
}
