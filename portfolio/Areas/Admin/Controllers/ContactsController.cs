﻿using Microsoft.AspNetCore.Mvc;
using portfolio.DataAccess.Data;
using portfolio.DataAccess.Repository.IRepository;
using portfolio.Models;

namespace portfolioASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ContactsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Contact> objContactsList = _unitOfWork.ContactRepository.GetAll().ToList();
            return View(objContactsList);
        }

        public IActionResult Details(int? id)
        {
            if (id != null || id != 0)
            {
                Contact? contactFromDb = _unitOfWork.ContactRepository.Get(u => u.Id == id);

                if (contactFromDb == null)
                {
                    return NotFound();
                }

                return View(contactFromDb);
            }
            else
            {
                return NotFound();
            }

        }

        public IActionResult Upsert(int? id)
        {

            if (id == null || id == 0)
            {
                return View(new Contact());
            }
            else
            {
                Contact? contactFromDb = _unitOfWork.ContactRepository.Get(u => u.Id == id);

                if (contactFromDb == null)
                {
                    return NotFound();
                }

                return View(contactFromDb);
            }

        }

        [HttpPost]
        public IActionResult Upsert(Contact contact)
        {
            if (ModelState.IsValid)
            {

                if (contact.Id == 0)
                {
                    _unitOfWork.ContactRepository.Add(contact);
                }
                else
                {
                    _unitOfWork.ContactRepository.Update(contact);
                }

                _unitOfWork.Save();
                TempData["success"] = "Kontakt został utworzony.";
                return RedirectToAction("Index");

            }
            else
            {
                return View(contact);
            }
        }

        //[HttpDelete]
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return Json(new { success = false, message = "Nie przyjeto id" });
        //    }

        //    Skill? skill = _unitOfWork.SkillRepository.Get(u => u.Id == id);

        //    if (skill == null)
        //    {
        //        return Json(new { success = false, message = "Nie znaleziono podanego id" });
        //    }

        //    if(skill.ImageUrl != null)
        //    {
        //        string wwwRootPath = _webHostEnvironment.WebRootPath;

        //        var oldImagePath =
        //            Path.Combine(wwwRootPath, skill.ImageUrl.TrimStart('\\'));


        //        if (System.IO.File.Exists(oldImagePath))
        //        {
        //            System.IO.File.Delete(oldImagePath);
        //        }
        //    }

        //    _unitOfWork.SkillRepository.Remove(skill);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Usunieto umiejetnosć" });
        //}
    }
}
