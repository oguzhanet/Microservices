using FreeCourseProjectWebUI.Models;
using FreeCourseProjectWebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FreeCourseProjectWebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SingInInput singInInput)
        {
            if (!ModelState.IsValid) { return View(); }

            var response = await _identityService.SignIn(singInInput);

            if (response.IsSuccessful)
            {
                response.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(String.Empty, x);
                });
                
                return View();
            }

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
