using Pantry.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Pantry.DataAccess.InMemory
{
    public class ProductTypeRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductType> productTypes;

        public ProductTypeRepository()
        {
            productTypes = cache["productTypes"] as List<ProductType>;
            if (productTypes == null)
            {
                productTypes = new List<ProductType>();
            }
        }

        public void Commit()
        {
            cache["productTypes"] = productTypes;
        }

        public void Insert(ProductType p)
        {
            productTypes.Add(p);
        }

        public void Update(ProductType productType)
        {
            ProductType productTypeToUpdate = productTypes.Find(p => p.ID == productType.ID);
            if (productTypeToUpdate != null)
            {
                productTypeToUpdate = productType;
            }
            else
            {
                throw new Exception("Product Type Not Found");
            }
        }

        public ProductType Find(string ID)
        {
            ProductType productType = productTypes.Find(p => p.ID == ID);

            if (productType != null)
            {
                return productType;
            }
            else
            {
                throw new Exception("Product Type Not Found");
            }
        }

        public IQueryable<ProductType> Collection()
        {
            return productTypes.AsQueryable();
        }

        public void Delete(string ID)
        {
            ProductType productTypeToDelete = productTypes.Find(p => p.ID == ID);

            if (productTypeToDelete != null)
            {
                productTypes.Remove(productTypeToDelete);
            }
            else
            {
                throw new Exception("Product Not Found");
            }

        }
    }
}
