using FirstMvcProject.Application.FluentValidation;
using FirstMvcProject.Application.Services.AccountServices;
using FirstMvcProject.Domain.Dtos;
using FirstMvcProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcProject.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;    

        public AccountController(IAccountService accountService, SignInManager<User> signInManager)
        {
            _accountService = accountService;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Get: Registor/Create
        [HttpGet]
        public IActionResult Registor()
        {
            return View();
        }
        // Post: Registor/Create
        [HttpPost]

        public async Task<IActionResult> Registor([Bind("Name,Email,ConfirmPassword,Password,Role")] RegistorDto registorDto)
        {
            var validator = await new RegistorValidator().ValidateAsync(registorDto);
            if (!validator.IsValid)
            {
                foreach (var error in validator.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(registorDto);
            }

            if (ModelState.IsValid)
            {
                var a = await _accountService.Registor(registorDto);
                return RedirectToAction("Index", "Product");
            }
            return View(registorDto);
        }
        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        // Post: Login/Create

        public async Task<IActionResult> Login([Bind("Password,Email")] LoginDto loginDto)
        {
           
            var validator = await new LoginValidator().ValidateAsync(loginDto);
            if (!validator.IsValid)
            {
                foreach (var error in validator.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(loginDto);

            }

            

            if (ModelState.IsValid)
            {
                await _accountService.Login(loginDto);
                return RedirectToAction("Index", "Product");
            }
            return View(loginDto);
        }

    }
}
