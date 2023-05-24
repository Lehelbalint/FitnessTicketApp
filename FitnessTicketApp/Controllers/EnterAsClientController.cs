using FitnessTicketApp.Data;
using FitnessTicketApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace FitnessTicketApp.Controllers
{
	public class EnterAsClientController : Controller
	{
        
        private readonly FitnessAppDbContext fitnesAppDbContext;
		
        
        public EnterAsClientController(FitnessAppDbContext fitnesAppDbContext)
        {
            this.fitnesAppDbContext = fitnesAppDbContext;
        }
        
        public IActionResult EnterAsClient()
		{
			return View();
		}

        
        [HttpGet]
        public async Task<IActionResult> ClientMemberships(string barcode)
        {
            if(string.IsNullOrEmpty(barcode))
            {
				var clientMemberships = await fitnesAppDbContext.ClientsTickets.ToListAsync();
				return View(clientMemberships);
            }
            else
            {
				var clientMemberships = await fitnesAppDbContext.ClientsTickets.Where(s => s.CardId == barcode).ToListAsync();
				if(clientMemberships.Count() == 0)
				{
					TempData["AlertMessage"] = "Wrong barcode or try to buy a ticket";
					return RedirectToAction("EnterAsClient");
				}
				var ticketTypes = await fitnesAppDbContext.BerletTipusok.ToListAsync();
				var resultList = new List<UserMemberships>();
				foreach (var clientMembership in clientMemberships)
				{
					var temp = new UserMemberships();
					temp.Id = clientMembership.Id;
					temp.MembershipName = ticketTypes.Find(s => s.Id == clientMembership.TicketId).Megnevezes;
					temp.Price = clientMembership.Price;
					temp.PurchaseId = clientMembership.PurchaseId;
					temp.CheckIns = clientMembership.CheckIns;
					temp.Valability = clientMembership.Valability;
					temp.FirstCheckInDate = clientMembership.FirstCheckInDate;
					temp.Barcode = clientMembership.CardId;

					resultList.Add(temp);
				}
				return View(resultList);
			}
        }
		[HttpGet]
		public async Task<IActionResult> MyCheckIns(string barcode)
		{
			var checkInsList = await fitnesAppDbContext.CheckIns.ToListAsync();
			var resultList = checkInsList.FindAll(s => s.Barcode == barcode);

			return View(resultList);

		}

		[HttpPost]
		public async Task<IActionResult> CheckIn(string ticketId)
		{

			var ticketList = await fitnesAppDbContext.ClientsTickets.ToListAsync();
			var ticket = ticketList.Find(s => s.Id.ToString() == ticketId);
			var ticketTypes = await fitnesAppDbContext.BerletTipusok.ToListAsync();
			var ticketType = ticketTypes.Find(s => s.Id == ticket.TicketId);

			var checkIns = await fitnesAppDbContext.CheckIns.ToListAsync();

			if (ticketType.Torolve == true)
			{
				TempData["AlertMessage"] = "This ticket type is deleted";
                return RedirectToAction("ClientMemberships", new RouteValueDictionary { { "Barcode", ticket.CardId } });
            }
			if (ticketType.Hanyoratol > DateTimeOffset.Now.Hour || ticketType.Hanyoraig < DateTimeOffset.Now.Hour)
			{
				TempData["AlertMessage"] = "You cant come in this hour of the day";
                return RedirectToAction("ClientMemberships", new RouteValueDictionary { { "Barcode", ticket.CardId } });
            }
			if(ticket.CheckIns >= ticketType.HanyBelepesreErvenyes)
			{
				TempData["AlertMessage"] = "Your days expired";
                return RedirectToAction("ClientMemberships", new RouteValueDictionary { { "Barcode", ticket.CardId } });
            }
			if (ticket.FirstCheckInDate.AddDays(ticketType.HanyNapigErvenyes).CompareTo(DateTime.Now)<0)
			{
				TempData["AlertMessage"] = "Your days expired";
                return RedirectToAction("ClientMemberships", new RouteValueDictionary { { "Barcode", ticket.CardId } });
            }
			var todayCheckIns = checkIns.FindAll(it => it.CheckInDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"));
			if (todayCheckIns != null)
			{

				if(todayCheckIns.Count > ticketType.NapontaHanyszorHasznalhato)
				{
					TempData["AlertMessage"] = "Your logged in to many times today";
                    return RedirectToAction("ClientMemberships", new RouteValueDictionary { { "Barcode", ticket.CardId } });

                }
				
			}
			var checkIn = new CheckIns()
			{
				Id = Guid.NewGuid(),
				Barcode = ticket.CardId,
				TicketId = ticket.TicketId,
				GymId = ticket.GymId,
				CheckInDate = DateTime.Now,
				ClientId = ticket.ClientId,
			};
			

			fitnesAppDbContext.CheckIns.AddAsync(checkIn);
			ticket.CheckIns++;
			await fitnesAppDbContext.SaveChangesAsync();
			TempData["Succes"] = "Succesfull";
			return RedirectToAction("ClientMemberships", new RouteValueDictionary { { "Barcode", ticket.CardId } });

		}
		
    }
}
