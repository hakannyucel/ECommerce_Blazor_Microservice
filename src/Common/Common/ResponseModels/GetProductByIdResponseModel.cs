namespace Common.ResponseModels
{
    public class GetProductByIdResponseModel
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int ReviewCount { get; set; }
        public List<string> Images { get; set; }
    }
}
