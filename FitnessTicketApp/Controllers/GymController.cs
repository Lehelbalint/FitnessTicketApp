using FitnessTicketApp.Data;
using FitnessTicketApp.Models.Domain;
using FitnessTicketApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTicketApp.Controllers
{
    public class GymController : Controller
    {
        private readonly FitnessAppDbContext fitnessAppDbContext;

        public GymController(FitnessAppDbContext fitnessAppDbContext)
        {
            this.fitnessAppDbContext = fitnessAppDbContext;
        }

        [HttpGet]
        public IActionResult AddGym()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGym(GymViewModel addGymViewModel)
        {
            var gym = new Gym()
            {
                GymId = Guid.NewGuid(),
                GymName = addGymViewModel.GymName,
                IsDeleted = false
            };
            await fitnessAppDbContext.Gyms.AddAsync(gym);
            await fitnessAppDbContext.SaveChangesAsync();
            return RedirectToAction("Index","Home");

        }

    }

}
