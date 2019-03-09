using FeatureTogglingSampleSF.Web.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FeatureTogglingSampleSF.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly FeatureToggleSampleSettings _settings;

        public ValuesController(IOptionsSnapshot<FeatureToggleSampleSettings> settings)
        {
            _settings = settings.Value;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return _settings.Foo;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
