using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeProduct.ShopModels
{
    public class CategoryModel
    {
        [Required]
        public string Name { get; set; }

        public Category BindModel()
        {
            Category category = new()
            {
                Name = Name
            };
            return category;
        }
    }
}
