using DOOBY.Models;

namespace DOOBY.DTOs
{
    public class StationInfoDTO
    {
        public string? Latitude { get; set; }

        public string? Longitude { get; set; }

        public int? TotalNodes { get; set; }

        public int? AvailableNodes { get; set; }

        public double? Distance { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }


        public StationInfoDTO(StationInfo station, GeolocationInfoDTO userGeolocation)
        {
            Latitude = station.Latitude;
            Longitude = station.Longitude;
            TotalNodes = station.TotalNodes;
            AvailableNodes = station.AvailableNodes;
            //Name = station.Name;
            //Address = station.Address;
            Distance = station.distance(station.Latitude, station.Longitude,
                userGeolocation.Latitude, userGeolocation.Longitude);
        }
    }
}
