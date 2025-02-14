﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIBKMNET_MVCWeb.Context;
using SIBKMNET_MVCWeb.Models;
using SIBKMNET_MVCWeb.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_MVCWeb.Controllers
{
    public class ProvinceController : Controller
    {
        ProvinceRepository ProvinceRepository;

        public ProvinceController(ProvinceRepository ProvinceRepository)
        {
            this.ProvinceRepository = ProvinceRepository;
        }

        // GET ALL
        // GET
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role").Equals("Admin"))
            {
                var data = ProvinceRepository.Get();
                return View(data);
            }
            return RedirectToAction("Unauthorized", "ErrorPage");
            
        }

        // GET BY ID
        // GET
        public IActionResult Details(int id)
        {
            var data = ProvinceRepository.Get(id);
            return View(data);
        }

        // CREATE
        // GET
        public IActionResult Create(int id)
        {
            var data = ProvinceRepository.Post(id);
            return View(data);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Province province)
        {
            if (ModelState.IsValid)
            {
                var result = ProvinceRepository.Post(province);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // UPDATE
        // GET
        public IActionResult Edit(int id)
        {
            var data = ProvinceRepository.Get(id);
            return View(data);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Province province)
        {
            if (ModelState.IsValid)
            {
                var result = ProvinceRepository.Put(id, province);
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }


        // DELETE
        // GET
        public IActionResult Delete(int id)
        {
            var data = ProvinceRepository.Get(id);
            return View(data);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(Province province)
        {
            var result = ProvinceRepository.Delete(province);
            if (result > 0)
                return RedirectToAction("Index");
            return View();
        }
     }
}
