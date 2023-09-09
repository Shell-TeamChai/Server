﻿using System;
using System.Collections.Generic;

namespace DOOBY.Models;

public partial class Grievance
{
    public int GrievanceId { get; set; }

    public int UserId { get; set; }

    public string Type { get; set; } = null!;

    public string? Description { get; set; }

    public int StationId { get; set; }

    public virtual Customer User { get; set; } = null!;
}