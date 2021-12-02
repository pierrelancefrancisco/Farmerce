using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farmerce.Data;
using Farmerce.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Farmerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var list = _context.Products.Include(p => p.Category).ToList();
            return View(list);
        }
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Products record, IFormFile ImagePath)
        {
           
            var selectedCategory = _context.Category
           .Where(c => c.CatID == record.CatID).SingleOrDefault();

            var product = new Products()
            {
                ProductName = record.ProductName,
                ProductPrice = record.ProductPrice,
                ProductMeasurement = record.ProductMeasurement,
                StocksLeft = record.StocksLeft,
                Category = selectedCategory,
                CatID = record.CatID

             };

            if(ImagePath != null)
            {
                if(ImagePath.Length > 0 )
                {
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/products", ImagePath.FileName);

                        using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        ImagePath.CopyTo(stream);
                    }
                    product.ImagePath = ImagePath.FileName;
                }
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var products = _context.Products.Where(i => i.ProductID == id).SingleOrDefault();
            if (products == null)
            {
                return RedirectToAction("Index");
            }
            return View(products);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(int? id, Products record)
        {
            var selectedCategory = _context.Category
           .Where(c => c.CatID == record.CatID).SingleOrDefault();

            int cut = 0;
            

            var product = _context.Products.Where(p => p.ProductID == id).SingleOrDefault();

            cut = product.StocksLeft;
            cut = cut - 1;
            product.ProductName = record.ProductName;
            product.ProductPrice = record.ProductPrice;
            product.ProductMeasurement = record.ProductMeasurement;
            cut = record.StocksLeft;
            product.Category = selectedCategory;
            product.CatID = record.CatID;

          

            _context.Products.Update(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var products = _context.Products.Where(i => i.ProductID == id).SingleOrDefault();
            if (products == null)
            {
                return RedirectToAction("Index");
            }

            _context.Products.Remove(products);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}

