using System.Net.Http;
using System.Text;
using Hated.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;

namespace Hates.Tests.EndToEnd
{
    public class ServerConfigAndRun
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        protected ServerConfigAndRun()
        {
            Server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            Client = Server.CreateClient();
        }

        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
