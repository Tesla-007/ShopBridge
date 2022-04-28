using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShopAuth.ShopAuthModels
{
    public class ProductModel
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CatId { get; set; }

        public HttpRequestMessage BindModel()
        {
            HttpRequestMessage requestMessage = new();
            requestMessage.Method = HttpMethod.Post;
            requestMessage.RequestUri = new Uri("http://localhost:5002/api/Product/AddProduct");
            requestMessage.Content = JsonContent.Create(this);
            return requestMessage;
        }
    }
}
