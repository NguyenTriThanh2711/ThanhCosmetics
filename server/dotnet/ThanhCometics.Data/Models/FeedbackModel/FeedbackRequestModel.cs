namespace ThanhCometics.Repository.Models.FeedbackModel
{
    public class FeedbackCreateRequestModel
    {
        public float Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool? Status { get; set; }

        public int ProductId { get; set; }
    }
    public class FeedbackUpdateRequestModel
    {
        public int FeedbackId { get; set; }

        public float Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool? Status { get; set; }
    }
}
