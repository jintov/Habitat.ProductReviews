using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Sitecore.Feature.VideoReviews.Helpers
{
    public static class ExpoTvExternalProviderClient
    {
        public static async Task<string> GetDataFromExpoTvProvider(string url, NameValueCollection headers)
        {

            string expoTvData = null;
            HttpResponseMessage expoTvResponse = null;

            using (HttpClient client = new HttpClient())
            {
                foreach (string headerkey in headers.AllKeys)
                {                    
                    if (headers != null && !string.IsNullOrWhiteSpace(headers[headerkey]))
                    {                        
                        client.DefaultRequestHeaders.Add(headerkey, headers[headerkey]);
                    }
                }

                expoTvResponse = await client.GetAsync(url).ConfigureAwait(false);

                expoTvResponse.EnsureSuccessStatusCode();

                expoTvData = await expoTvResponse.Content.ReadAsStringAsync();
            }

            return expoTvData;
        }
    }
}
