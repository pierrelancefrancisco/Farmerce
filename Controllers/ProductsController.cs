using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farmerce.Data;
using Farmerce.Models;


namespace Farmerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Products.ToList();
            return View(list);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Products record)
        {
            var product = new Products();
            product.ProductName = record.ProductName;
            product.ProductPrice = record.ProductPrice;
            product.ProductMeasurement = record.ProductMeasurement;
            product.StocksLeft = record.StocksLeft;
            product.Category = record.Category;
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

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


        [HttpPost]
        public IActionResult Update(int? id, Products record)
        {
            var products = _context.Products.Where(i => i.ProductID == id).SingleOrDefault();
            products.ProductName = record.ProductName;
            products.ProductPrice = record.ProductPrice;
            products.ProductMeasurement = record.ProductMeasurement;
            products.StocksLeft = record.StocksLeft;
            products.Category = record.Category;

            _context.Products.Update(products);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

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

