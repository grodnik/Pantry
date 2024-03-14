using Pantry.Core.Models;
using Pantry.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pantry.WebUI.Controllers
{
    public class ProductTypeManagerController : Controller
    {
        InMemoryRepository<ProductType> context;

        public ProductTypeManagerController()
        {
            context = new InMemoryRepository<ProductType>();
        }

        // GET: ProductTypeManager
        public ActionResult Index()
        {
            List<ProductType> productTypes = context.Collection().ToList();
            return View(productTypes);
        }

        public ActionResult Create()
        {
            ProductType productType = new ProductType();
            return View(productType);
        }

        [HttpPost]
        public ActionResult Create(ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return View(productType);
            }
            else
            {
                context.Insert(productType);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string ID)
        {
            ProductType productType = context.Find(ID);
            if (productType == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productType);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductType productType, string ID)
        {
            ProductType productTypeToEdit = context.Find(ID);

            if (productTypeToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productType);
                }

                productTypeToEdit.Type = productType.Type;
             

                context.Commit();

                return RedirectToAction("Index");

            }
        }

        public ActionResult Delete(string ID)
        {
            ProductType productTypeToDelete = context.Find(ID);

            if (productTypeToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productTypeToDelete);
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string ID)
        {
            ProductType productTypeToDelete = context.Find(ID);

            if (productTypeToDelete == null)
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