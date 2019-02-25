using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net;

namespace catEngine
{
    public static class catEngine
    {
        public static string defaultName = "User";
        public static string noMonthSpecified =
            @"<h3>Please pass a month on the query string like:</h3>
            <p>JAN | FEB | MAR | APR | MAY | JUN | JUL | AUG | SEP | OCT | NOV | DEC</p>";

        [FunctionName("catEngine")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string name = req.Query["name"];
            string month = req.Query["month"];

            List<Cat> cats = new List<Cat>
            {
                new Persian(),
                new European(),
                new IrishFold()
            };

            var catInfo = cats.Find(cat => cat.CanHandle(month))?.Handle();

            var source = catInfo ?? noMonthSpecified;

            string html =
                $@"<html>
                <body style='text-align: center'>
                <h1>Hello {name ?? defaultName}!</h1>
                {source}
                </body>
                </html>";

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(html);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}
