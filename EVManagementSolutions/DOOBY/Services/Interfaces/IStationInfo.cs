using DOOBY.DTOs;
using DOOBY.Models;

namespace DOOBY.Services.Interfaces
{
    public interface IStationInfo
    {
        public Task<List<StationInfo>> GetAllStations();

        public Task<List<GeolocationInfoDTO>> GetAllGeoLocations();

        public Task<StationInfo> GetStationInfoById(int stationId);

        public Task<StationInfo> AddNewStation(StationInfo stationInfo);

        public Task<StationInfo> UpdateStationInfo(StationInfo stationInfo);

        public void RemoveStation(int stationId);

        //public Task<List<StationInfoDTO>> FindStationsNearMe(GeolocationInfoDTO userGeolocationI);
    }
}
