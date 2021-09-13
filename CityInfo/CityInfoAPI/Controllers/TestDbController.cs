using CityInfoAPI.Context;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoAPI.Controllers
{
    [ApiController]
    [Route("api/testdatabase")]
    public class TestDbController : ControllerBase
    {
        private readonly CityInfoContext ctx;

        public TestDbController(CityInfoContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
