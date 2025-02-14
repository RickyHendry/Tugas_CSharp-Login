﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIBKMNET_MVCWeb.Repositories.Data;
using SIBKMNET_MVCWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_MVCWeb.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Forgot()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult EditAcc()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditAcc(int id, EditAcc editAcc)
        {
            //MASIH BELOM

            var data = accountRepository.EditAcc(id, editAcc);
            if (data > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            var data = accountRepository.Register(register);
            if (data > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                //statement mengambil data dari database sesuai dengan email dan password
                //return Id employee, FullName, Email, Role -> Masukkan ke ViewModels
                var data = accountRepository.Login(login);

                if (data != null)
                {
                    //inisialisasi nilai pada session
                    HttpContext.Session.SetString("Role", data.Role);
                    HttpContext.Session.SetInt32("Id", data.Id);
                    return RedirectToAction("Index", "Province");
                }
                return RedirectToAction("Unauthorized", "ErrorPage");
            }
            return View();
        }
        [HttpPost]

        public IActionResult Forgot(Forgot forgot)
        {
            if (ModelState.IsValid)
            {
                //statement mengambil data dari database sesuai dengan email dan password
                //return Id employee, FullName, Email, Role -> Masukkan ke ViewModels
                var data = accountRepository.Forgot(forgot);

                if (data != null)
                {
                    //inisialisasi nilai pada session
                    HttpContext.Session.SetString("Role", data.Role);
                    return RedirectToAction("Index", "Province");
                }
                return RedirectToAction("Unauthorized", "ErrorPage");
            }
            return View();
        }
    }
}
