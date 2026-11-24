using Microsoft.AspNetCore.Mvc;
using SkinwiseProj.Repositories.Interfaces;

namespace SkinwiseProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public HomeController(
            IProductRepository productRepository,
            IBrandRepository brandRepository,
            IIngredientRepository ingredientRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _ingredientRepository = ingredientRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserHome()
        {
            var products = await _productRepository.GetAllAsync();

            // Prevent null results from breaking the Razor view.
            ViewBag.Products = (object?)products ?? Array.Empty<object>();

            ViewBag.UserName = "User";

            return View();
        }

        public async Task<IActionResult> AdminHome()
        {
            var products = await _productRepository.GetAllAsync();
            var brands = await _brandRepository.GetAllAsync();
            var ingredients = await _ingredientRepository.GetAllAsync();

            ViewBag.Products = (object?)products ?? Array.Empty<object>();

            ViewBag.TotalProducts = products?.Count() ?? 0;
            ViewBag.TotalBrands = brands?.Count() ?? 0;
            ViewBag.TotalCategories = 0;

            // Replace with the actual registered-user count when
            // your Identity user repository is connected.
            ViewBag.TotalUsers = 0;

            return View();
        }

        // Display products from SQL Server.
        public async Task<IActionResult> Products()
        {
            var products = await _productRepository.GetAllAsync();

            ViewBag.Brands = await _brandRepository.GetAllAsync();
            ViewBag.Ingredients = await _ingredientRepository.GetAllAsync();

            return View(products);
        }

        // AJAX product search.
        [HttpGet]
        public async Task<IActionResult> SearchProducts(string? term)
        {
            var products = await _productRepository.SearchAsync(term);

            return Json(products ?? Enumerable.Empty<object>());
        }
    }
}