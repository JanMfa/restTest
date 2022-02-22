namespace restTest
{
    //============================== class Connect =============================================
    //Purpose:	Class to connect to the web url, fetch the data and calculates running daily balances
    //==========================================================================================
    public class TransactionProcessor
    {
        //====public async Task<SortedDictionary<string, decimal>> GetTransactionFromServerResult(string uri) ====
        //Purpose:	Calculates daily balances in url given
        //PRE:
        //PARAM: string url : url of the REST API
        //POST: Return the result of daily balances in url
        //=========================================================================================================
        public async Task<SortedDictionary<string, decimal>> GetTransactionFromServerResult(string url)
        {
            Connect con = new Connect();
            var data = await con.GetAsync(url+"1.json");
            Processor proc = new Processor();
            SortedDictionary<string, decimal> result = proc.GetTransactionResult(data);
            var pageNumber = data.Page;
            var totalPageNumber = data.TotalCount;
            var currentCount = data.Transactions.Count;
            var counter = 1;
            while(currentCount < totalPageNumber)
            {
                counter++;
                data = await con.GetAsync(url + counter.ToString() + ".json");
                currentCount += data.Transactions.Count;
                var res = proc.GetTransactionResult(data);
                result = AddingTwoTransaction(result, res);
            }
            return result;
        }

        // Helper function to add two transactions
        private SortedDictionary<string, decimal> AddingTwoTransaction(SortedDictionary<string, decimal> trans1, SortedDictionary<string, decimal> trans2)
        {
            SortedDictionary<string, decimal> res = trans1;
            foreach (var x in trans2)
            {
                if (res.ContainsKey(x.Key))
                {
                    res[x.Key] += x.Value;
                }
                else
                {
                    res[x.Key] = x.Value;
                }
            }
            return res;
        }
    }
}
