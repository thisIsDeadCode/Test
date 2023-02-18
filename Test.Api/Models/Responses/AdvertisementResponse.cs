namespace Test.Api.Models.Responses
{
    public class AdvertisementResponse
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishedDate { get; set; }
    }
}
