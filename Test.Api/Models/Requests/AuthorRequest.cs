namespace Test.Api.Models.Requests
{
    public class AuthorRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public double Rating { get; set; }
    }
}
