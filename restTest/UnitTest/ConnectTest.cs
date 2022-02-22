using Xunit;
using FluentAssertions;

namespace restTest
{
    public class ConnectTest
    {
        string url = "https://resttest.bench.co/transactions/";

        // To test successful conenction
        [Fact]
        public async Task TestConnectionOK()
        {
            Connect con = new Connect();
            var ret = await con.GetAsync(url + "1.json");
            ret.Page.Should().Be(1);
            ret.Transactions.Count.Should().BeGreaterThan(0);
        }

        // To test unsuccessful conenction
        [Theory]
        [InlineData("-1.json")]
        [InlineData("0.json")]
        [InlineData("10000.json")]
        public async Task TestConnectionNotOK(string jsonpage)
        {
            Connect con = new Connect();
            var ret = await con.GetAsync(url + jsonpage);
            ret.Page.Should().Be(0);
            ret.TotalCount.Should().Be(0);
            ret.Transactions.Should().BeNull();
        }
    }
}
