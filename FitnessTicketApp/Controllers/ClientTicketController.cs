using FitnessTicketApp.Data;
using FitnessTicketApp.Models;
using FitnessTicketApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FitnessTicketApp.Controllers
{
    public class ClientTicketController : Controller
    {

        private readonly FitnessAppDbContext fitnessAppDbContext;

        public ClientTicketController(FitnessAppDbContext fitnessAppDbContext)
        {
            this.fitnessAppDbContext = fitnessAppDbContext;
        }
        public IActionResult AddMemberShip()
        {
            var felhasznalok = fitnessAppDbContext.Clients.ToList();
            var berletek = fitnessAppDbContext.BerletTipusok.ToList();

            var viewModel = new ClientMembershipViewModel
            {
                Clients = felhasznalok,
                MemberShip = berletek
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMapping(ClientMembershipViewModel viewModel)
        {
            var client =  await fitnessAppDbContext.Clients.Where(s => s.Id == viewModel.SelectedFelhasznaloId).ToListAsync();
            var memberShip = await fitnessAppDbContext.BerletTipusok.Where ( s=> s.Id == viewModel.SelectedBerletId ).ToListAsync();


            var ClientMemberShip = new ClientTicket()
            {
                Id = Guid.NewGuid(),
                ClientId = client[0].Id,
                TicketId = memberShip[0].Id,
                CardId = client[0].Code,
                PurchaseId = DateTime.Now,
                CheckIns = 0,
                Price = memberShip[0].Ar,
                Valability = true,
                FirstCheckInDate = viewModel.StartDate,
                GymId = memberShip[0].Terem_Id
            };
            await fitnessAppDbContext.ClientsTickets.AddAsync(ClientMemberShip);
            await fitnessAppDbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
