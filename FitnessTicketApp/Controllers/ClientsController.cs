using FitnessTicketApp.Data;
using FitnessTicketApp.Models;
using FitnessTicketApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;

namespace FitnessTicketApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly FitnessAppDbContext fitnessAppDbContext;

        public ClientsController(FitnessAppDbContext fitnessAppDbContext)
        {
            this.fitnessAppDbContext = fitnessAppDbContext;
        }

        [HttpGet]

        public async Task<IActionResult> ClientList(string clientName)
        {
            if (string.IsNullOrEmpty(clientName))
                {
                var clients = await fitnessAppDbContext.Clients.ToListAsync();
                return View(clients);
                }
            else
            {
                var clients = await fitnessAppDbContext.Clients.Where(s => s.Name == clientName).ToListAsync();
                return View(clients);
            }
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddClientViewModel addClientViewModel)
        {
            var client = new Client()
            {
                Id = Guid.NewGuid(),
                Name = addClientViewModel.Name,
                Email = addClientViewModel.Email,
                Phone = addClientViewModel.Phone,
                Adress = addClientViewModel.Adress,
                Code = addClientViewModel.Code,
                Comment = addClientViewModel.Comment,
                CNP = addClientViewModel.CNP,
                Is_deleted = false,
                inserted_date = DateTime.Now,
            };
            if (addClientViewModel.Photo != null)
            {
                using var stream = new MemoryStream(addClientViewModel.Photo);
                client.Photo = stream.ToArray();
            }
            await fitnessAppDbContext.Clients.AddAsync(client);
            await fitnessAppDbContext.SaveChangesAsync();
            return RedirectToAction("ClientList");

        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id) 
        {
            var client = await fitnessAppDbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);

            if (client != null)
            {
                var viewModel = new UpdateClientViewModel()
                {
                    Id = client.Id,
                    Name = client.Name,
                    Email = client.Email,
                    Phone = client.Phone,
                    Adress = client.Adress,
                    Code = client.Code,
                    Comment = client.Comment,
                    CNP = client.CNP,
                    Is_deleted = client.Is_deleted,
                    inserted_date = client.inserted_date
                };
                return await Task.Run(() => View("View",viewModel));
            }

            return RedirectToAction("ClientList");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateClientViewModel model)
        {
            var client = await fitnessAppDbContext.Clients.FindAsync(model.Id);

            if (client != null)
            {
                client.Name = model.Name;
                client.Email = model.Email;
                client.Phone = model.Phone;
                client.Adress = model.Adress;
                client.Code = model.Code;
                client.Comment = model.Comment;
                client.CNP = model.CNP;


                fitnessAppDbContext.Clients.Update(client);
                await fitnessAppDbContext.SaveChangesAsync();
                return RedirectToAction("ClientList");
            }
            return RedirectToAction("ClientList");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = await fitnessAppDbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);

            if (client != null)
            {
                client.Is_deleted = true;
                fitnessAppDbContext.Clients.Update(client);
                await fitnessAppDbContext.SaveChangesAsync();
                return RedirectToAction("ClientList");
            }

            return RedirectToAction("ClientList");
        }

    }
 
}
