using DOOBY.Models;
using Microsoft.AspNetCore.Mvc;

namespace DOOBY.Services.Interfaces
{
    public interface IStationInfo
    {
        public Task<List<StationInfo>> GetAllStations();

        public Task<List<GeolocationInfo>> GetAllGeoLocations();

        public Task<StationInfo> AddNewStation(StationInfo stationInfo);

        public Task<StationInfo> UpdateStationInfo(StationInfo stationInfo);

        public void RemoveStation(int stationId);
    }
}
