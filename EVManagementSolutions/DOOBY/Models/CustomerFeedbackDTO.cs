namespace DOOBY.Models
{
    public class CustomerFeedbackDTO
    {
        public int FeedbackId { get; set; }

        public int UserId { get; set; }

        public int? Rating { get; set; }

        public string? Description { get; set; }

        public int? StationId { get; set; }

    }
}
