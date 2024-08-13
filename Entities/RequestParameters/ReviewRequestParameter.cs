namespace Entities.RequestParameters
{
    public class ReviewRequestParameter : RequestParameters
    {
        public int ProductId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public String? UserName { get; set; }
        public ReviewRequestParameter() : this (1,2)
        {
        }
        public ReviewRequestParameter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}