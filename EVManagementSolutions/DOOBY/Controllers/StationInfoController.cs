using DOOBY.Models;
using DOOBY.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOOBY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationInfoController : ControllerBase
    {
        IStationInfo _stationInfo;

        public StationInfoController(IStationInfo stationInfo)
        {
            _stationInfo = stationInfo;
        }

        [HttpGet]
        public async Task<ActionResult<List<StationInfo>>> GetAllStations()
        {
            var result = await _stationInfo.GetAllStations();

            return result;
        }

        [HttpPost]
        public async Task<StationInfo> AddNewStation(StationInfo stationInfo)
        {
            var result = await _stationInfo.AddNewStation(stationInfo);

            return result;
        }

        [HttpPut]
        public async Task<StationInfo> UpdateStationInfo(StationInfo stationInfo)
        {
            var result = await _stationInfo.AddNewStation(stationInfo);

            return result;
        }
    }
}
