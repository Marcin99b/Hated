using System.Net.Http;
using Hated.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

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
    }
}
