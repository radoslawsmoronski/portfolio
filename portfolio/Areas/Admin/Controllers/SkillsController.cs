﻿using Microsoft.AspNetCore.Mvc;
using portfolio.DataAccess.Data;
using portfolio.DataAccess.Repository.IRepository;
using portfolio.Models;

namespace portfolioASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SkillsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Skill> objSkillsList = _unitOfWork.SkillRepository.GetAll().ToList();
            return View(objSkillsList);
        }

        public IActionResult Upsert(int? id)
        {

            if(id == null || id == 0)
            {
                return View(new Skill());
            }
            else
            {
                Skill? skillFromDb = _unitOfWork.SkillRepository.Get(u => u.Id == id);

                if (skillFromDb == null)
                {
                    return NotFound();
                }

                return View(skillFromDb);
            }
            
        }

        [HttpPost]
        public IActionResult Upsert(Skill skill, IFormFile? file)
        {
            if(ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\skills");

                    if(string.IsNullOrEmpty(skill.ImageUrl) == false)
                    {
                        var oldImagePath = 
                            Path.Combine(wwwRootPath,skill.ImageUrl.TrimStart('\\'));

                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    skill.ImageUrl = @"\images\skills\" + fileName;
                }

                if(skill.Id == 0)
                {
                    _unitOfWork.SkillRepository.Add(skill);
                }
                else
                {
                    _unitOfWork.SkillRepository.Update(skill);
                }

                _unitOfWork.Save();
                TempData["success"] = "Umiejętność zostałą utworzona";
                return RedirectToAction("Index");
                
            }

            return View(skill);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Skill? skillFromDb = _unitOfWork.SkillRepository.Get(u => u.Id == id);

            if (skillFromDb == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.SkillRepository.Remove(skillFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Umiejętność została usunięta.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
