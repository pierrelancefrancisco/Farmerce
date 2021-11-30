using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farmerce.Models;
using Farmerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Farmerce.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var products = _context.Products.Include(p => p.Category).ToList();

            var categories = _context.Category.OrderBy(c => c.CatName).ToList();

            var record = new StoreViewModel()
            {
                ProductList = products,
                CategoryList = categories
            };
            
            return View(record);
        }




    }
}
