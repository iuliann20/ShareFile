using Microsoft.AspNetCore.Mvc;
using ShareFile.BL.Logic.Interfaces;
using ShareFile.Helpers.Interfaces;
using ShareFile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                var message = _userLogic.AddUser(_accountControllerHelper.BuildDTO(registerViewModel), registerViewModel.RePassword);
            }
            return RedirectToAction("Index", "Share");
        }



    }
}
