﻿using Microsoft.AspNetCore.Mvc;
using portfolio.DataAccess.Data;
using portfolio.DataAccess.Json;
using portfolio.DataAccess.Repository.IRepository;
using portfolio.Models;

namespace portfolioASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NavbarLogoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public NavbarLogoController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(JsonFileManager<NavbarLogo>.Get());
        }

        //[HttpPost]
        //public IActionResult Upsert(Project project, IFormFile? file)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        string wwwRootPath = _webHostEnvironment.WebRootPath;
        //        if(file != null)
        //        {
        //            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //            string productPath = Path.Combine(wwwRootPath, @"images\projects");

        //            if(string.IsNullOrEmpty(project.ImageUrl) == false)
        //            {
        //                var oldImagePath = 
        //                    Path.Combine(wwwRootPath,project.ImageUrl.TrimStart('\\'));

        //                if(System.IO.File.Exists(oldImagePath))
        //                {
        //                    System.IO.File.Delete(oldImagePath);
        //                }
        //            }

        //            using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
        //            {
        //                file.CopyTo(fileStream);
        //            }

        //            project.ImageUrl = @"\images\projects\" + fileName;
        //        }

        //        if(project.Id == 0)
        //        {
        //            _unitOfWork.ProjectRepository.Add(project);
        //        }
        //        else
        //        {
        //            _unitOfWork.ProjectRepository.Update(project);
        //        }

        //        _unitOfWork.Save();
        //        TempData["success"] = "Projekt został utworzony.";
        //        return RedirectToAction("Index");

        //    }

        //    return View(project);
        //}

    }
}