using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        ShopContext Db;
        public HomeController(ShopContext context)
        {
            Db = context;

        }
        public IActionResult Index()
        {
            return View(Db.Shops.Include(s=>s.Schedule).ToList());
        }

        public IActionResult GetProducts(int Id)
        {

            List<Product> products =  Db.ShopProduct.Where(c => c.ShopId == Id).Select(s => s.Product).ToList();
            return View(products);
        }

        public IActionResult About()
        {
            //InitializeDb();
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void InitializeDb()
        {
            List<Schedule> SchedulesList = new List<Schedule>();
            Schedule s1 = new Schedule { Start_at = 8, Finish_at = 16, WorkDays = "Wednsday Tuseday Monday" };
            Schedule s2 = new Schedule { Start_at = 10, Finish_at = 18, WorkDays = "Wednsday Tuseday Monday" };
            Schedule s3 = new Schedule { Start_at = 2, Finish_at = 22, WorkDays = "Wednsday Tuseday Monday Sunday" };
            Db.Schedules.AddRange(s1, s2, s3);
            List<Product> ProductList = new List<Product>();
            Product pr1 = new Product { Name = "Samsung TV", Description = "sdfbsdfdsfdskfnfererfr" };
            Product pr2 = new Product { Name = "LG TV", Description = "sdfbsdfdsfdscsdcsdsdkfnfererfr" };
            Product pr3 = new Product { Name = "APPLE TV", Description = "sdfbsdfdsdcfdvfdsdsfdskfnfererfr" };
            Product pr4 = new Product { Name = "Xiaomi Tv", Description = "sdfbsdfdsfdsqwwqewqfekfnfererfr" };
            Product pr5 = new Product { Name = "KeyBoard", Description = "sdfbsdfdsfdskfnfererfr" };
            Product pr6 = new Product { Name = "Mouse", Description = "sdfbsdfdsfdskfnfdscsdererfr" };
            Product pr7 = new Product { Name = "Smth else", Description = "sdfbsdfdsfdasdsaskfnfererfr" };
            Db.Products.AddRange(new List<Product> { pr1, pr2, pr3, pr4, pr5, pr6 });
            List<Shop> ShopList = new List<Shop>();
            Shop sh1 = new Shop { Address = "scsdsdsd", Name = "Evroopt", Schedule = s1 };
            Shop sh2 = new Shop { Address = "scsdsdsd", Name = "Vitalur", Schedule = s2 };
            Shop sh3 = new Shop { Address = "scsdsdsd", Name = "Hippo", Schedule = s3 };
            Db.Shops.AddRange(new List<Shop> { sh1, sh2, sh3 });
            sh1.Products.Add(new ShopProduct { ProductId = pr1.Id, ShopId = sh1.Id });
            sh1.Products.Add(new ShopProduct { ProductId = pr2.Id, ShopId = sh1.Id });
            sh1.Products.Add(new ShopProduct { ProductId = pr5.Id, ShopId = sh1.Id });
            sh1.Products.Add(new ShopProduct { ProductId = pr6.Id, ShopId = sh1.Id });
            sh2.Products.Add(new ShopProduct { ProductId = pr3.Id, ShopId = sh2.Id });
            sh2.Products.Add(new ShopProduct { ProductId = pr5.Id, ShopId = sh2.Id });
            sh2.Products.Add(new ShopProduct { ProductId = pr6.Id, ShopId = sh2.Id });
            sh3.Products.Add(new ShopProduct { ProductId = pr2.Id, ShopId = sh3.Id });
            sh3.Products.Add(new ShopProduct { ProductId = pr3.Id, ShopId = sh3.Id });
            sh3.Products.Add(new ShopProduct { ProductId = pr4.Id, ShopId = sh3.Id });
            Db.SaveChanges();
        }
    }
}
