using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyMVC.Helpers;
using TravelAgencyMVC.Models;
using TravelAgencyMVC.Models.Interfaces;

namespace TravelAgencyMVC.Controllers
{
    public class TravelController : Controller
    {
        private readonly ITravelsService _travelsService;

        [FromRoute]
        public long? Id { get; set; }

        public bool IsNewTravel
        {
            get { return Id == null; }
        }
        [BindProperty]
        public Travel TravelProperty { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public TravelController(ITravelsService travelsService, TravelsDbContext context)
        {
            _travelsService = travelsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Travel(long id)
        {
            TravelProperty = await _travelsService.FindAsync(id);
            return View(TravelProperty);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> AddTravel(long? id = null)
        {
            if (id == null)
            {
                return View(new Travel());
            }

            var travel = await _travelsService.FindAsync((long)id);
            if (travel == null)
            {
                return NotFound();
            }
            return View(travel);
        }

        // POST: ManageTravelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Name,Description,Activities,Image")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    using (var stream = new System.IO.MemoryStream())
                    {
                        await Image.CopyToAsync(stream);
                        travel.Image = Utils.ConvertToBase64(stream);
                        travel.ImageContentType = Image.ContentType;
                    }
                }
                await _travelsService.SaveAsync(travel);
                return RedirectToAction("Travel", "Travel", new { id = travel.Id });
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
