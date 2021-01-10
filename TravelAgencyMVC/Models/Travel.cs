using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelAgency.Helpers;
using static System.Environment;

namespace TravelAgency.Models
{
    public class Travel
    {
        public long Id { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 5,
            ErrorMessage = "Hey - you've gotta give a name between 5 and 100 characters long!")]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Activities { get; set; }


        public IEnumerable<string> ActivitiesList
        {
            get { return (Activities ?? string.Empty).Split(NewLine); }
        }

        #region Image

        public string Image { get; set; }

        public string ImageContentType { get; set; }

        public string GetInlineImageSrc ()
        {
            if (Image == null || ImageContentType == null)
                return null;

            //var base64Image = System.Convert.ToBase64String(Image);
            return $"data:{ImageContentType};base64,{Image}";
        }

        public void SetImage(Microsoft.AspNetCore.Http.IFormFile file)
        {
            if (file == null)
                return;

            ImageContentType = file.ContentType;

            using (var stream = new System.IO.MemoryStream())
            {
                file.CopyTo(stream);
                var streamArr = stream.ToArray();
                Image = Utils.ConvertToBase64(stream);
            }
        }
        
        #endregion
    }
}
