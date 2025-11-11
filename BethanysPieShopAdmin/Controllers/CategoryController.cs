using BethanysPieShopAdmin.Models;
using BethanysPieShopAdmin.Models.Repositories;
using BethanysPieShopAdmin.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopAdmin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            CategoryListViewModel model = new()
            {
                Categories = (await _categoryRepository.GetAllCategoriesAsync()).ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selectedCategory = await _categoryRepository.GetCategoryByIdAsync(id.Value);

            return View(selectedCategory);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            try
            {
                // 🔧 Manual validation rules
                if (string.IsNullOrWhiteSpace(category.Name))
                {
                    ModelState.AddModelError("Name", "Name is required");
                }

                if (!string.IsNullOrEmpty(category.Description) && category.Description.Length > 200)
                {
                    ModelState.AddModelError("Description", "Description cannot exceed 200 characters");
                }

                if (category.DateAdded > DateTime.Today)
                {
                    ModelState.AddModelError("DateAdded", "Date cannot be in the future");
                }

                // ✅ Now check validity
                if (ModelState.IsValid)
                {
                    await _categoryRepository.AddCategoryAsync(category);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // General error message (not tied to a specific field)
                ModelState.AddModelError("", $"Adding the category failed, please try again! Error: {ex.Message}");
            }

            // If we reach here, something failed → redisplay form with errors
            return View(category);
        }


    }
}
