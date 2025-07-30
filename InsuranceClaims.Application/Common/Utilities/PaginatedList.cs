namespace InsuranceClaims.Application.Common.Utilities
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; }
        public int TotalCount { get; }
        public int Page { get; }
        public int PerPage { get; }

        public PaginatedList(List<T> items, int totalCount, int page, int perPage)
        {
            Items = items;
            TotalCount = totalCount;
            Page = page;
            PerPage = perPage;
        }
    }
}
