using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using FShop.Core.Models;

namespace FShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;

        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory p)
        {
            ProductCategory productCategoryToUpdate = productCategories.Find(v => v.Id == p.Id);

            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = p;
            }
            else
            {
                throw new Exception("ProductCategory not found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory productCategoryToFind = productCategories.Find(v => v.Id == Id);


            if (productCategoryToFind != null)
            {
                return productCategoryToFind;
            }
            else
            {
                throw new Exception("ProductCategory not found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productCategories.Find(v => v.Id == Id);

            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
