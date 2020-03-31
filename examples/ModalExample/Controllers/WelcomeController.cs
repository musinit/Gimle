using System.Collections.Generic;
using System.Threading.Tasks;
using Gimle.Core;
using Gimle.Core.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ChangeMessageInResponseExample.Controllers
{
    [Route("welcome")]
    public class WelcomeController : Controller
    {
        private readonly GimleClient _gimleClient;

        public WelcomeController(GimleClient gimleClient) => _gimleClient = gimleClient;
        
        [HttpGet]
        public async Task Send()
        {
            await _gimleClient.UpdateHomeAsync("U631X4HNY", "profile", new []
            {
                new ReplaceValue("[@meaning_of_life]", string.Empty, true) 
            });
        }
        
    }
}