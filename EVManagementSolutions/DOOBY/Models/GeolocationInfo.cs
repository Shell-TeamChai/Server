using System.ComponentModel.DataAnnotations;

namespace DOOBY.Models
{
    public class GeolocationInfo
    {
        [Required]
        public string? Latitude { get; set; }

        [Required]
        public string? Longitude { get; set; }


        public GeolocationInfo(StationInfo statioInfo) {
            Latitude = statioInfo.Latitude;
            Longitude = statioInfo.Longitude;
        }
    }
}
