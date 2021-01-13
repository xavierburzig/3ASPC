using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Services.Models;
using TravelAgencyMVC.Models;
using TravelAgencyMVC.Models.Interfaces;

namespace TravelAgencyMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TravelsDbContext _context;
        private readonly ITravelsService _travelsService;

        public HomeController(ILogger<HomeController> logger, TravelsDbContext context, ITravelsService travelsService)
        {
            _logger = logger;
            _context = context;
            _travelsService = travelsService;
        }

        public async Task<IActionResult> Index()
        {
            Travel[] travels = (Travel[])await GetTravelList();
            return View(travels);
        }

        private async Task<IEnumerable<Travel>> GetTravelList()
        {
            Travel[] travels = await _travelsService.GetAllAsync();
            return travels;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return View();
            }
            var travel = await _context.Travels.FindAsync(id);
            if (travel == null)
            {
                return View();

            }
            return RedirectToAction("AddTravel","Travel", new { id = id});
        }

        public IActionResult Travel(long id)
        {
            return RedirectToAction("Travel","Travel", new { id = id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
