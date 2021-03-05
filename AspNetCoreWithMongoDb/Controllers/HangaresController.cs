using AspNetCoreWithMongoDb.Models;
using AspNetCoreWithMongoDb.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCoreWithMongoDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangaresController : Controller
    {
        private readonly HangarService _hangarService;

        public HangaresController(HangarService hangarService)
        {
            _hangarService = hangarService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_hangarService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var nota = _hangarService.Get(id);

            if (nota == null)
            {
                return NotFound();
            }

            return Ok(nota);
        }

        [HttpPost]
        public IActionResult Create(Hangar nota)
        {
            nota.Id = Guid.NewGuid().ToString();
            _hangarService.Create(nota);

            return Ok(nota);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Hangar notaIn)
        {
            var nota = _hangarService.Get(id);

            if (nota == null)
            {
                return NotFound();
            }

            _hangarService.Update(id, notaIn);

            return Ok(notaIn);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var nota = _hangarService.Get(id);

            if (nota == null)
            {
                return NotFound();
            }

            _hangarService.Remove(nota.Id);

            return NoContent();
        }
    }
}
