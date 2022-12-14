using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webapp_backend.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }  
        public string Photo { get; set; }

        public static implicit operator Product(ActionResult<Product> v)
        {
            throw new NotImplementedException();
        }
    }
}