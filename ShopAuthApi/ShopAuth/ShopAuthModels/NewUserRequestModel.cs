using ShopAuth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAuth.ShopAuthModels
{
    public class NewUserRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public NewAdminRequest BindModel()
        {
            NewAdminRequest req = new();
            req.Age = Age;
            req.ApprovalStatus = Approval.Pending;
            req.FullName = Name;
            req.Gender = Gender;
            req.Email = Email;
            return req;
        }
    }
}
