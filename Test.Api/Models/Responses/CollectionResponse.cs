using Test.Api.Data.Models;

namespace Test.Api.Models.Responses
{
    public class CollectionResponse<T> where T : class
    {
        public IEnumerable<T> Result { get; set; }
        public PageInfo PageInfo { get; set; }

        public CollectionResponse(IEnumerable<T> result, PageInfo pageInfo)
        {
            Result = result;
            PageInfo = pageInfo;
        }
    }
}
