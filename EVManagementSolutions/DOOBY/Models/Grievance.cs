using System;
using System.Collections.Generic;

namespace DOOBY.Models;

public partial class Grievance
{
    public int GrievanceId { get; set; }

    public int UserId { get; set; }

    public string Status { get; set; } = null!;

    public string? Description { get; set; }

    public int? StationId { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public DateOnly? LastEdit { get; set; }

    public virtual Customer User { get; set; } = null!;
}
