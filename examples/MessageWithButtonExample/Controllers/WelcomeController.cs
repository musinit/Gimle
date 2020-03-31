using System.Collections.Generic;
using System.Threading.Tasks;
using Gimle.Core;
using Gimle.Core.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GimleApiExample.Controllers
{
    [Route("welcome")]
    public class WelcomeController : Controller
    {
        private readonly GimleClient _gimleClient;

        public WelcomeController(GimleClient gimleClient) => _gimleClient = gimleClient;
        
        [HttpGet]
        public async Task Send()
        {
            await _gimleClient.SendSlackMessageAsync("U631X4HNY", 
                "welcome", 
                new []
            {
                new ReplaceValue("[@name]", "Boris", true)
            });
        }
        
    }
}