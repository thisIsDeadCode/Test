namespace Test.Api.Data.Models
{
    public class Author : BaseObject
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public double Rating { get; set; }


        public virtual IEnumerable<Advertisement>? Advertisements { get; set; }
    }
}
