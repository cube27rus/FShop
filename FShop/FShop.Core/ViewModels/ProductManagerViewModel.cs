using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FShop.Core.Models;

namespace FShop.Core.ViewModels
{
    public class ProductManagerViewModel
    {
        public Product Product { get; set; }

        public IEnumerable<ProductCategory> ProductCategories { get; set; }


    }
}
