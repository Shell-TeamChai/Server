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

    public Feedback() { }

    public Feedback(CustomerFeedbackDTO customerFeedbackDTO, Customer customer) {
        FeedbackId = customerFeedbackDTO.FeedbackId;
        UserId = customerFeedbackDTO.UserId;
        Rating = customerFeedbackDTO.Rating;  
        Description = customerFeedbackDTO.Description;
        StationId = customerFeedbackDTO.StationId;
        User = customer;
    }
}
