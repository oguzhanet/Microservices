using FreeCourseProjectWebUI.Models.Catalog;
using FreeCourseProjectWebUI.Services.Abstract;
using FreeCourseShared.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public CourseController(ICatalogService catalogService, ISharedIdentityService sharedIdentityService)
        {
            _catalogService = catalogService;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _catalogService.GetAllCourseByUserIdAsync(_sharedIdentityService.GetUserId);
            return View(courses);
        }

        public async Task<IActionResult> Create()
        {
            var categories=await _catalogService.GetAllCategoriesAsync();

            ViewBag.categoryList = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateInput courseCreateInput)
        {
            var categories = await _catalogService.GetAllCategoriesAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            if (!ModelState.IsValid)
            {
                return View();
            }

            courseCreateInput.UserId = _sharedIdentityService.GetUserId;

            await _catalogService.CreateCourseAsync(courseCreateInput);

            return RedirectToAction(nameof(Index));
        } 

        public async Task<IActionResult> Update(string id)
        {
            var course=await _catalogService.GetByCourseIdAsync(id);
            var categories = await _catalogService.GetAllCategoriesAsync();
            

            if (course == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.categoryList = new SelectList(categories, "Id", "Name",course.Id);

            CourseUpdateInput courseUpdateInput = new()
            {
                Id = course.Id,
                Name = course.Name,
                CategoryId = course.CategoryId,
                Description = course.Description,
                Feature = course.Feature,
                Picture = course.Picture,
                Price = course.Price,
                UserId = course.UserId
            };

            return View(courseUpdateInput);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CourseUpdateInput courseUpdateInput)
        {
            var categories = await _catalogService.GetAllCategoriesAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name", courseUpdateInput.Id);

            if (!ModelState.IsValid)
            {
                return View();
            }

            await _catalogService.UpdateCourseAsync(courseUpdateInput);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _catalogService.DeleteCourseAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
