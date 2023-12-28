using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace TestODataProject
{
    public class ChemicalPriceAndEconomicsController : ODataController
    {
        private readonly ChemicalPriceAndEconomicsService _service;

        public ChemicalPriceAndEconomicsController(ChemicalPriceAndEconomicsService service)
        {
            _service = service;
        }

        [HttpGet, EnableQuery(PageSize = 1)]
        [ProducesResponseType(typeof(ChemicalPriceAndEconomics), 1)]
        public IActionResult Get()
        {
            var result = _service.Get();

            return Ok(result);
        }
    }
}
