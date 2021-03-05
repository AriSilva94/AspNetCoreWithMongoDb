using AspNetCoreWithMongoDb.Business.Interfaces;
using AspNetCoreWithMongoDb.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCoreWithMongoDb.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HangaresController : Controller
    {
        private readonly IHangarBusiness _hangarBusiness;

        public HangaresController(IHangarBusiness hangarBusiness)
        {
            _hangarBusiness = hangarBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_hangarBusiness.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var hangar = _hangarBusiness.Get(id);

            if (hangar == null)
            {
                return NotFound();
            }

            return Ok(hangar);
        }

        [HttpPost]
        public IActionResult Create(Hangar nota)
        {
            _hangarBusiness.Create(nota);

            return Ok(nota);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Hangar hangar)
        {
            try
            {
                _hangarBusiness.Update(id, hangar);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(hangar);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _hangarBusiness.Remove(id);

            return NoContent();
        }
    }
}
