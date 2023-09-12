using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DOOBY.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int UserId { get; set; }

    public int? Rating { get; set; }

    public string? Description { get; set; }

    public int? StationId { get; set; }

    [JsonIgnore]
    public virtual Customer User { get; set; } = null!;
}
