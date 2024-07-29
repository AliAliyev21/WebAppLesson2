using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        public List<Product> Products { get; set; } = new List<Product>
        {

           new Product
            {
                Id = 1,
                Name = "Laptop",
                Description = "A high-performance laptop.",
                Price = 1200.00m,
                Discount = 100.00m,
                Image = "/images/laptop.png" 
            },
            new Product
            {
                Id = 2,
                Name = "Phone",
                Description = "A latest model smartphone.",
                Price = 800.00m,
                Discount = 50.00m,
                Image = "/images/phone.png" 
            },
            new Product
            {
                Id = 3,
                Name = "Headphones",
                Description = "Noise-cancelling over-ear headphones.",
                Price = 200.00m,
                Discount = 20.00m,
                Image = "/images/headphones.jpg" 
            },
            new Product
            {
                Id = 4,
                Name = "Smartwatch",
                Description = "A smartwatch with fitness tracking features.",
                Price = 150.00m,
                Discount = 15.00m,
                Image = "/images/smartwatch.jpg" 
            },
            new Product
            {
                Id = 5,
                Name = "Tablet",
                Description = "A tablet with a large display and powerful processor.",
                Price = 600.00m,
                Discount = 40.00m,
                Image = "/images/tablet.jpg" 
            }
        };

        public IActionResult Index()
        {
            var vm = new ProductListViewModel
            {
                Products = Products
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new ProductAddViewModel
            {
                Product = new Product(),
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(ProductAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Product.Id = (new Random()).Next(10, 1000);
                var products = Products;
                products.Add(vm.Product);
                Products = products; 

                System.Diagnostics.Debug.WriteLine($"Added product: {vm.Product.Name}");

                return RedirectToAction("Index");
            }

            return View(vm);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = Products.Find(p => p.Id == id);
            if (product != null)
            {
                Products.Remove(product);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = Products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var vm = new ProductUpdateViewModel
            {
                Product = product,
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(ProductUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var product = Products.Find(p => p.Id == vm.Product.Id);
                if (product != null)
                {
                    product.Name = vm.Product.Name;
                    product.Description = vm.Product.Description;
                    product.Price = vm.Product.Price;
                    product.Discount = vm.Product.Discount;
                    product.Image = vm.Product.Image;

                    return RedirectToAction("Index");
                }
            }

            return View(vm);
        }

    }
}
