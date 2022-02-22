namespace restTest
{
    //============================== class Processor =============================================
    //Purpose:	Class to calculates running daily balances
    //==========================================================================================
    public class Processor
    {
        //============ public SortedDictionary<string, decimal> GetTransactionResult(DataDto data) ================
        //Purpose:	Calculates daily balances in one DataDto, which consist of many transactions
        //PRE:
        //PARAM: DataDto data: DataDto object per page 
        //POST: Return the result of daily balances in DataDto object
        //=========================================================================================================
        public SortedDictionary<string, decimal> GetTransactionResult(DataDto data)
        {
            SortedDictionary<string, decimal> result = new SortedDictionary<string, decimal>();
            List<TransactionDto> transactionList = (List<TransactionDto>)data.Transactions;
            if(transactionList == null)
            {
                return result;
            }
            foreach (var x in transactionList) 
            {
                if(result.ContainsKey(x.Date)){
                    result[x.Date] += Math.Round(Convert.ToDecimal(x.Amount), 2); 
                }
                else
                {
                    result[x.Date] = Math.Round(Convert.ToDecimal(x.Amount), 2);
                }
            }

            return result;
        }
    }
}
