using Microsoft.AspNetCore.Mvc;
using ShareFile.BL.Logic.Interfaces;
using ShareFile.Helpers.Interfaces;
using ShareFile.Models;

namespace ShareFile.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserLogic _userLogic;
        private readonly IAccountControllerHelper _accountControllerHelper;
        public AccountController(IUserLogic userLogic, IAccountControllerHelper accountControllerHelper)
        {
            _userLogic = userLogic;
            _accountControllerHelper = accountControllerHelper;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (registerViewModel != null)
            {
                TL.Helpers.Response message = _userLogic.AddUser(_accountControllerHelper.BuildDTO(registerViewModel), registerViewModel.RePassword);
            }
            return RedirectToAction("Index", "Share");
        }



    }
}
