using FitnessTicketApp.Data;
using FitnessTicketApp.Models;
using FitnessTicketApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessTicketApp.Controllers
{
    public class BerletTipusController : Controller
    {
        private readonly FitnessAppDbContext fitnesAppDbContext;
        public BerletTipusController(FitnessAppDbContext fitnesAppDbContext)
        {
            this.fitnesAppDbContext = fitnesAppDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
          var berletTipusok = await fitnesAppDbContext.BerletTipusok.ToListAsync();
           return View(berletTipusok);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var gyms = fitnesAppDbContext.Gyms.ToList();
            var viewModel = new AddBerletTipusViewModel
            {
                Gyms = gyms
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add( AddBerletTipusViewModel addBerletTipusRequest)
        {
            var berletTipus = new BerletTipus()
            {
                Id = Guid.NewGuid(),
                Megnevezes = addBerletTipusRequest.Megnevezes,
                Ar = addBerletTipusRequest.Ar,
                HanyNapigErvenyes = addBerletTipusRequest.HanyNapigErvenyes,
                HanyBelepesreErvenyes = addBerletTipusRequest.HanyBelepesreErvenyes,
                Torolve = addBerletTipusRequest.Torolve,
                Terem_Id = addBerletTipusRequest.SelectedGymId,
                Hanyoratol = addBerletTipusRequest.Hanyoratol,
                Hanyoraig = addBerletTipusRequest.Hanyoraig,
                NapontaHanyszorHasznalhato = addBerletTipusRequest.NapontaHanyszorHasznalhato

            };
            await fitnesAppDbContext.BerletTipusok.AddAsync(berletTipus);
            await fitnesAppDbContext.SaveChangesAsync();
			TempData["Succes"] = "Succesfully added";
			return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
           var berletTipus = await fitnesAppDbContext.BerletTipusok.FirstOrDefaultAsync(x => x.Id == id);

            if (berletTipus != null)
            {
                var viewModel = new UpdateBerletTipusViewModel()
                {
                    Id = Guid.NewGuid(),
                    Megnevezes = berletTipus.Megnevezes,
                    Ar = berletTipus.Ar,
                    HanyNapigErvenyes = berletTipus.HanyNapigErvenyes,
                    HanyBelepesreErvenyes = berletTipus.HanyBelepesreErvenyes,
                    Torolve = berletTipus.Torolve,
                    Terem_Id = berletTipus.Terem_Id,
                    Hanyoratol = berletTipus.Hanyoratol,
                    Hanyoraig = berletTipus.Hanyoraig,
                    NapontaHanyszorHasznalhato = berletTipus.NapontaHanyszorHasznalhato

                };

                return await Task.Run(()=>View("View",viewModel));
            }

         
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateBerletTipusViewModel model)
        {
            var berletTipus = await fitnesAppDbContext.BerletTipusok.FindAsync(model.Id);

            if (berletTipus != null)
            {
                berletTipus.Megnevezes = model.Megnevezes;
                berletTipus.Ar = model.Ar;
                berletTipus.HanyNapigErvenyes = model.HanyNapigErvenyes;
                berletTipus.HanyBelepesreErvenyes = model.HanyBelepesreErvenyes;
                berletTipus.Torolve = model.Torolve;
                berletTipus.Terem_Id = model.Terem_Id;
                berletTipus.Hanyoratol = model.Hanyoratol;
                berletTipus.Hanyoraig = model.Hanyoraig;
                berletTipus.NapontaHanyszorHasznalhato = model.NapontaHanyszorHasznalhato;

                await fitnesAppDbContext.SaveChangesAsync();
				TempData["Succes"] = "Succesfully edited";
				return RedirectToAction("Index");

            }
			
			return RedirectToAction("Index");
        }
		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			var berletTipus = await fitnesAppDbContext.BerletTipusok.FirstOrDefaultAsync(x => x.Id == id);

            if(berletTipus.Torolve == true)
            {
				TempData["AlertMessage"] = "Already deleted";
			}
			if (berletTipus != null)
			{
				berletTipus.Torolve = true;
				fitnesAppDbContext.BerletTipusok.Update(berletTipus);
				await fitnesAppDbContext.SaveChangesAsync();
                TempData["Succes"] = "Succesfully deleted";
				return RedirectToAction("Index");
			}

			return RedirectToAction("Index");
		}



	}
}
