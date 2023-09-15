using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DOOBY.Models;

public partial class StationInfo
{
    public int StationId { get; set; }

    public string? StationName { get; set; }

    public string? StationAddress { get; set; }

    public int? StationMaster { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public int? TotalNodes { get; set; }

    public int? AvailableNodes { get; set; }

    [JsonIgnore]
    public virtual Admin? StationMasterNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<StationSelectInfo> StationSelectInfos { get; set; } = new List<StationSelectInfo>();

    static double toRadians(
               double angleIn10thofaDegree)
    {
        // Angle in 10th
        // of a degree
        return (angleIn10thofaDegree *
                       Math.PI) / 180;
    }
    public double distance(string latitude1,
                           string longitude1,
                           string latitude2,
                           string longitude2)
    {

        // The math module contains
        // a function named toRadians
        // which converts from degrees
        // to radians.
        double lat1 = toRadians(Convert.ToDouble(latitude1));
        double lon1 = toRadians(Convert.ToDouble(longitude1));
        double lat2 = toRadians(Convert.ToDouble(latitude2));
        double lon2 = toRadians(Convert.ToDouble(longitude2));

        // Haversine formula
        double dlon = lon2 - lon1;
        double dlat = lat2 - lat1;
        double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                   Math.Cos(lat1) * Math.Cos(lat2) *
                   Math.Pow(Math.Sin(dlon / 2), 2);

        double c = 2 * Math.Asin(Math.Sqrt(a));

        // Radius of earth in
        // kilometers. Use 3956
        // for miles
        double r = 6371;

        // calculate the result
        return (c * r);
    }
}
