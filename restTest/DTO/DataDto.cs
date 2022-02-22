namespace restTest
{
    public class DataDto
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public IList<TransactionDto> Transactions { get; set; }
    }
}
