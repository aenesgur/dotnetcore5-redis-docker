using Docker_Redis_Sample.Core;
using Docker_Redis_Sample.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Docker_Redis_Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IValuesService _valuesService;

        public ValuesController(IValuesService valuesService)
        {
            _valuesService = valuesService;
        }

        [HttpGet("{id}")]
        public ValuesModel GetValuesById(int id)
        {
            ValuesModel values = _valuesService.getValuesById(id);
            return values;
        }
    }
}
