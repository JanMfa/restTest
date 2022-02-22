using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restTest
{
    public interface ITransactionProcessor
    {
        public Task<SortedDictionary<string, decimal>> GetTransactionFromServerResult(string uri);
    }
}
