using Newtonsoft.Json;
using System.Net;

namespace restTest
{
    //============================== class Connect =============================================
    //Purpose:	Class to Connects to a REST API and fetches all pages of financial transactions.
    //==========================================================================================
    class Connect
    {

        //============ public async Task<DataDto> GetAsync(string uri) ================
        //Purpose:	Connects to a REST API and fetches all trasnsactions
        //PRE:
        //PARAM: string url : url of the rest API
        //POST: Return the DataDto object, which consist of TotalCount, Page and Transactions objects
        //==========================================================================================
        public async Task<DataDto> GetAsync(string url)
        {
            DataDto data = new DataDto();
            Dictionary<string, string> getResponse = new Dictionary<string, string>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    if (response.StatusCode.ToString() == "OK")
                    {
                        var line = await reader.ReadToEndAsync();
                        data = JsonConvert.DeserializeObject<DataDto>(line);
                    }

                    return data;
                }
            }catch(Exception)
            {
                return data;
            }
        }
    }
}
