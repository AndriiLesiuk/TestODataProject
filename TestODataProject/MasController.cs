using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace TestODataProject
{
    public class MasController : ODataController
    {
        private readonly MasService _service;

        public MasController(MasService service)
        {
            _service = service;
        }

        [HttpGet, EnableQuery(PageSize = 100)]
        [ProducesResponseType(typeof(Mas), 200)]
        public IActionResult Get()
        {
            var result = _service.Get();
            return Ok(result);
        }
    }
}
