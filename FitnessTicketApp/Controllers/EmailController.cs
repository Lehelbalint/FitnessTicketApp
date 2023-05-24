using FitnessTicketApp.Data;
using FitnessTicketApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessTicketApp.Controllers
{


    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly FitnessAppDbContext fitnessAppDbContext;

        public EmailController(FitnessAppDbContext fitnessAppDbContext, IEmailService emailService)
        {
            this.fitnessAppDbContext = fitnessAppDbContext;
            _emailService = emailService;
        }
        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendEmail(EmailSenderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var users = fitnessAppDbContext.Clients.ToList();

                foreach (var user in users)
                {
                    _emailService.SendEmail(user.Email, model.Subject, model.Message);
                }

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
