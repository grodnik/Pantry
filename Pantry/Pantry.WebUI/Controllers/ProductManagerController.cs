using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pantry.Core.Models;
using Pantry.Core.ViewModels;
using Pantry.DataAccess.InMemory;

namespace Pantry.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        InMemoryRepository<Product> context;
        InMemoryRepository<ProductType> productTypes;

        public ProductManagerController()
        {
            context = new InMemoryRepository<Product>();
            productTypes = new InMemoryRepository<ProductType>(); 
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();

            viewModel.Product = new Product();
            viewModel.ProductTypes = productTypes.Collection();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string ID)
        {
            Product product = context.Find(ID);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = product;
                viewModel.ProductTypes = productTypes.Collection();

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string ID)
        {
            Product productToEdit = context.Find(ID);

            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }

                productToEdit.Category = product.Category;
                productToEdit.Name = product.Name;
                productToEdit.Type = product.Type;
                productToEdit.Price = product.Price;

                context.Commit();

                return RedirectToAction("Index");

            }
        }

        public ActionResult Delete(string ID)
        {
            Product productToDelete = context.Find(ID);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string ID)
        {
            Product productToDelete = context.Find(ID);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(ID);
                context.Commit();
                return RedirectToAction("Index");

            }
        }
    }
}