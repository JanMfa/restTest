using FluentAssertions;
using Xunit;

namespace restTest
{
    public class ProcessorTest
    {
        // To test the transaction result with sorted transaction date
        [Fact]
        public void GetTransactionResultSorted()
        {
            var data = new DataDto()
            {
                Page = 1,
                TotalCount = 1,
                Transactions = new List<TransactionDto>
                {
                    new TransactionDto
                    {
                        Date = "2013-12-12",
                        Ledger = "Office Expense",
                        Amount = "-25.05",
                        Company = "AA OFFICE SUPPLIES"
                    },
                    new TransactionDto
                    {
                        Date = "2013-12-12",
                        Ledger = "Insurance Expense",
                        Amount = "-20",
                        Company = "AA OFFICE SUPPLIES"
                    },
                    new TransactionDto
                    {
                        Date = "2013-12-13",
                        Ledger = "Business Meals & Entertainment Expense",
                        Amount = "-10.55",
                        Company = "MCDONALDS RESTAURANT"
                    },
                    new TransactionDto
                    {
                        Date = "2013-12-14",
                        Ledger = "Credit Card - 1234",
                        Amount = "25",
                        Company = "PAYMENT - THANK YOU"
                    },
                    new TransactionDto
                    {
                        Date = "2013-12-14",
                        Ledger = "Credit Card - 1234",
                        Amount = "-55.55",
                        Company = "PAYMENT - THANK YOU"
                    }
                }
            };

            Processor proc = new Processor();
            SortedDictionary<string, decimal> result = proc.GetTransactionResult(data);
            result.Count.Should().Be(3);
            result["2013-12-12"].Should().Be((decimal)-45.05);
            result["2013-12-13"].Should().Be((decimal)-10.55);
            result["2013-12-14"].Should().Be((decimal)-30.55);
        }

        // To test the transaction result with unsorted transaction date
        [Fact]
        public void GetTransactionResultUnSorted()
        {
            var data = new DataDto()
            {
                Page = 1,
                TotalCount = 1,
                Transactions = new List<TransactionDto>
                    {
                        new TransactionDto
                        {
                            Date = "2013-12-14",
                            Ledger = "Credit Card - 1234",
                            Amount = "-55.55",
                            Company = "PAYMENT - THANK YOU"
                        },
                        new TransactionDto
                        {
                            Date = "2013-12-12",
                            Ledger = "Office Expense",
                            Amount = "-25.05",
                            Company = "AA OFFICE SUPPLIES"
                        },
                        new TransactionDto
                        {
                            Date = "2013-12-13",
                            Ledger = "Business Meals & Entertainment Expense",
                            Amount = "-10.55",
                            Company = "MCDONALDS RESTAURANT"
                        },
                        new TransactionDto
                        {
                            Date = "2013-12-12",
                            Ledger = "Insurance Expense",
                            Amount = "-20",
                            Company = "AA OFFICE SUPPLIES"
                        },
                        new TransactionDto
                        {
                            Date = "2013-12-15",
                            Ledger = "Business Meals & Entertainment Expense",
                            Amount = "10.55",
                            Company = "MCDONALDS RESTAURANT"
                        },
                        new TransactionDto
                        {
                            Date = "2013-12-14",
                            Ledger = "Credit Card - 1234",
                            Amount = "25",
                            Company = "PAYMENT - THANK YOU"
                        }
                    }
            };

            Processor proc = new Processor();
            SortedDictionary<string, decimal> result = proc.GetTransactionResult(data);
            result.Count.Should().Be(4);
            result["2013-12-12"].Should().Be((decimal)-45.05);
            result["2013-12-13"].Should().Be((decimal)-10.55);
            result["2013-12-14"].Should().Be((decimal)-30.55);
            result["2013-12-15"].Should().Be((decimal)10.55);
        }

        // To test the transaction result with null transaction
        // In case of failure to fetch data
        [Fact]
        public void GetTransactionResultNull()
        {
            var data = new DataDto()
            {
                Page = 1,
                TotalCount = 1,
                Transactions = null
            };

            Processor proc = new Processor();
            SortedDictionary<string, decimal> result = proc.GetTransactionResult(data);
            result.Count.Should().Be(0);
        }
    }
}
