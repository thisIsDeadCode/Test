using Test.Api.Data.Models;

namespace Test.Api.Services
{
    public class PaginationService<T> where T : BaseObject
    {
        private IQueryable<T> _items;
        public PageInfo PageInfo { get; private set; }
        public PaginationService(IQueryable<T> items, int pageNumber, int pageSize)
        {
            _items = items;
            PageInfo = new PageInfo()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = items.Count(),
            };
        }

        public IQueryable<T> GetItems()
        {
            var firstIndex = (PageInfo.PageNumber - 1) * PageInfo.PageSize;
            var result = _items.Skip(firstIndex).Take(PageInfo.PageSize);
            return result;
        }
    }
}
