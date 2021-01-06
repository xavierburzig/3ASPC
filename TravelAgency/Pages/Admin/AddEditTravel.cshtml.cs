using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelAgency.Helpers;
using TravelAgency.Models;

namespace TravelAgency.Pages.Admin
{
    public class AddEditTravelModel : PageModel
    {
        private readonly ITravelsService TravelsService;

        [FromRoute]
        public long? Id { get; set; }

        public bool IsNewTravel
        {
            get { return Id == null; }
        }

        [BindProperty]
        public Travel Travel { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public AddEditTravelModel(ITravelsService TravelsService)
        {
            this.TravelsService = TravelsService;
        }

        public async Task OnGetAsync()
        {
            Travel = await TravelsService.FindAsync(Id.GetValueOrDefault()) 
                ?? new Travel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid) {
                return Page();
            }

            var travel = await TravelsService.FindAsync(Id.GetValueOrDefault()) 
                ?? new Travel();

            travel.Name = Travel.Name;
            travel.Description = Travel.Description;
            travel.Activities = Travel.Activities;

            if(Image != null) {
                using(var stream = new System.IO.MemoryStream())
                {
                    await Image.CopyToAsync(stream);
                    travel.Image = Utils.ConvertToBase64(stream);
                    travel.ImageContentType = Image.ContentType;
                }
            }

            await TravelsService.SaveAsync(travel);
            return RedirectToPage("/Travel", new { id = travel.Id });
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await TravelsService.DeleteAsync(Id.Value);
            return RedirectToPage("/Index");
        }
    }
}