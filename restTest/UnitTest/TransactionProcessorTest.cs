using FluentAssertions;
using Xunit;

namespace restTest
{
    public class TransactionProcessorTest
    {

        string url = "https://resttest.bench.co/transactions/";

        // To test the result of daily balances in total
        [Fact]
        public async void GetTransactionResultSorted()
        {
            TransactionProcessor proc = new TransactionProcessor();
            SortedDictionary<string, decimal> result = await proc.GetTransactionFromServerResult(url);
            result.Count.Should().Be(10);
            result["2013-12-12"].Should().Be((decimal)-227.35);
            result["2013-12-13"].Should().Be((decimal)-1229.58);
            result["2013-12-15"].Should().Be((decimal)-5.39);
            result["2013-12-16"].Should().Be((decimal)-4575.53);
            result["2013-12-17"].Should().Be((decimal)10686.28);
            result["2013-12-18"].Should().Be((decimal)-1841.29);
            result["2013-12-19"].Should().Be((decimal)19753.31);
            result["2013-12-20"].Should().Be((decimal)-4054.60);
            result["2013-12-21"].Should().Be((decimal)-17.98);
            result["2013-12-22"].Should().Be((decimal)-110.71);
        }

    }
}
