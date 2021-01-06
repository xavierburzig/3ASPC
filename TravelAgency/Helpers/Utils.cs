using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Helpers
{
    public static class Utils
    {
        public static string ConvertToBase64(MemoryStream stream)
        {
            byte[] imageBytes = stream.ToArray();
            var base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}
