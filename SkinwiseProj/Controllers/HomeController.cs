
using Microsoft.AspNetCore.Mvc;

namespace SkinwiseProj.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        public IActionResult UserHome()
        {
            ViewData["Title"] = "User Dashboard";

            ViewBag.UserName = "SkinWise User";

            // Sample skincare products
            ViewBag.Products = new[]
            {
                new
                {
                    ArtClass = "product-yellow",
                    Icon = "☼",
                    Category = "Cleanser",
                    Name = "Gentle Face Wash",
                    Description = "A gentle daily cleanser.",
                    Price = "₨ 850"
                },
                new
                {
                    ArtClass = "product-blue",
                    Icon = "✿",
                    Category = "Moisturizer",
                    Name = "Daily Moisturizer",
                    Description = "Lightweight daily hydration.",
                    Price = "₨ 950"
                },
                new
                {
                    ArtClass = "product-pink",
                    Icon = "☁",
                    Category = "Serum",
                    Name = "Hydrating Serum",
                    Description = "A sample hydrating serum.",
                    Price = "₨ 650"
                },
                new
                {
                    ArtClass = "product-yellow",
                    Icon = "☀",
                    Category = "Sunscreen",
                    Name = "Daily Sunscreen",
                    Description = "Daily sun protection.",
                    Price = "₨ 1,000"
                }
            };

            return View();
        }

        public IActionResult AdminHome()
        {
            ViewData["Title"] = "Admin Dashboard";

            // Sample dashboard statistics
            ViewBag.TotalUsers = 25;
            ViewBag.TotalBrands = 6;
            ViewBag.TotalProducts = 12;
            ViewBag.TotalCategories = 4;

            return View();
        }
    }
}
