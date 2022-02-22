using restTest;

var proc = new TransactionProcessor();
var result = await proc.GetTransactionFromServerResult("https://resttest.bench.co/transactions/");

foreach(var x in result)
{
    Console.WriteLine("For date: " + x.Key + ", the amount is " + x.Value.ToString());
}

Console.ReadLine();
