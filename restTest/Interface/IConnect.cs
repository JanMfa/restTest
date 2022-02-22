using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restTest
{
    public interface IConnect
    {
        public Task<DataDto> GetAsync(string uri);
    }
}
