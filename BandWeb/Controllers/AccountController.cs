using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandWeb.Models;
using Newtonsoft.Json;
using BandWeb.Logic;
using BandWeb.Factory;
using BandWeb.Models.ViewModels;
using BandWeb.Logic.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BandWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountLogic _iaccountLogic;
        private readonly IConfiguration _iconfiguration;
        public AccountController(IConfiguration configuration)
        {
            _iconfiguration = configuration;
            _iaccountLogic = AccountFactory.CreateSqlLogic(_iconfiguration);
        }
        public IActionResult LoginForm()
        {
            return View();
        }
        public IActionResult LoginPage()
        {
            return View();
        }
        public IActionResult RegistrationSystem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPage(LoginViewModel login)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrate(string username, string email, string password, string streetname, int housenumber, string city)
        {
            User user = new User(username, email, password, streetname, housenumber, city);

            try
            {
                _iaccountLogic.CreateUser(user);
                var accObject = user;
                HttpContext.Session.SetString("Account", JsonConvert.SerializeObject(accObject));
                return RedirectToAction("LoginPage", "Account");
            }
            catch (Exception e)
            {
                return Ok();
            }
        }
    }
}