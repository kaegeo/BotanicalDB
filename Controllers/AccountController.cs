using BotanicalDB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BotanicalDB.Controllers
{
    /*
     * Brett Fowler
     * Course CPT-231-424 - C# Programming II
     * Module 12 Assignnent
     * 2023 Fall
     */
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //login view get action
        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult Login(string returnURL = "")
        {
            //string username
            //string password
            //bool keeplogin
            //string returnURL
            LoginViewModel model = new LoginViewModel(); //{ ReturnURL = returnURL };
            return View(model);
        }

        // login view post action
        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(
                    model.UserName, model.Password, isPersistent : model.KeepLogin, lockoutOnFailure : false
                    );
                if (result.Succeeded)
                {
                    //if (!string.IsNullOrEmpty(model.ReturnURL) && Url.IsLocalUrl(model.ReturnURL))
                    //{
                    //    return Redirect(model.ReturnURL);
                    //}
                    //else
                    //{
                        return RedirectToAction("Index", "Home");
                    //}
                }
            }
            return View(model);
        }

        //logout view action
        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //register view action
        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult Register(string returnURL = "")
        {
            //string username
            //string password
            //string confirmpassword
            //bool keeplogin
            //string returnURL
            RegisterViewModel model = new RegisterViewModel(); //{ ReturnURL = returnURL };
            return View(model);
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = new IdentityUser { UserName = model.UserName };
                IdentityResult result = await userManager.CreateAsync(identityUser, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(identityUser, isPersistent: model.KeepLogin);
                    //if (!string.IsNullOrEmpty(model.ReturnURL) && Url.IsLocalUrl(model.ReturnURL))
                    //{
                    //    return Redirect(model.ReturnURL);
                    //}
                    //else
                    //{
                        return RedirectToAction("Index", "Home");
                    //}
                }
            }
            return View(model);
        }

        // Access denied view action
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
