using System;
using System.Collections.Generic;

namespace DOOBY.Models;

public partial class StationInfo
{
    public int StationId { get; set; }

    public int? StationMaster { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public int? TotalNodes { get; set; }

    public int? AvailableNodes { get; set; }

    public virtual Admin? StationMasterNavigation { get; set; }

    public virtual StationSelectInfo? StationSelectInfo { get; set; }
}
