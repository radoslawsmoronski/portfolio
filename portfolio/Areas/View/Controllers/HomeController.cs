using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using portfolio.DataAccess.Data;
using portfolio.DataAccess.Json;
using portfolio.DataAccess.Repository.IRepository;
using portfolio.Models;
using portfolio.Models.ViewModels;
using portfolio.Utility.Email;
using System.Diagnostics;

namespace portfolioASP.Areas.View.Controllers
{
    [Area("View")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly JsonFileManager _jsonFileManager;
        private readonly IEmailService _emailService;
        private readonly HomePageViewModel _model;

        public HomeController(
            ILogger<HomeController> logger, IUnitOfWork unitOfWork,
            JsonFileManager jsonFileManager, IEmailService emailService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _jsonFileManager = jsonFileManager;
            _emailService = emailService;

            _model = new HomePageViewModel
            {
                Skills = _unitOfWork.SkillRepository.GetAll().ToList(),
                Projects = _unitOfWork.ProjectRepository.GetAll().ToList(),
                Contacts = _unitOfWork.ContactRepository.GetAll().ToList(),
                AboutMe = _jsonFileManager.AboutMe
            };
        }

        public IActionResult Index()
        {
            return View(_model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactForm contactForm)
        {
            if(contactForm == null)
            {
                return NotFound();
            }

            await _emailService.SendEmailAsync(contactForm.Email, contactForm.Subject, contactForm.Name);

            return RedirectToAction("Index", _model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
