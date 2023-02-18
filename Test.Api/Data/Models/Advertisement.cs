namespace Test.Api.Data.Models
{
    public class Advertisement : BaseObject
    {
        public string Title { get; set; } = string .Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishedDate { get; set; }


        public int AuthorId { get; set; }
        public virtual Author? Author { get; set; }
    }
}
