using Microsoft.AspNetCore.Mvc;
using AdministracionDePaqueteria.Models;
using AdministracionDePaqueteria.Services;
namespace AdministracionDePaqueteria.Controllers;

[Route("paqueteria/[controller]")]
public class estadosPaqueteController : ControllerBase
{
    IestadosPaqueteService estadosPaqueteService;
    
    public estadosPaqueteController(IestadosPaqueteService service)
    {
        estadosPaqueteService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(estadosPaqueteService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] estadosPaquete estadosPaquete)
    {
        estadosPaqueteService.Save(estadosPaquete);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(long codRastreo, [FromBody] estadosPaquete estadosPaquete)
    {
        estadosPaqueteService.Update(codRastreo, estadosPaquete);
        return Ok();
    }

    [HttpDelete("{codRastreo}")]
    public IActionResult Delete(long codRastreo)
    {
        estadosPaqueteService.Delete(codRastreo);
        return Ok();
    }
}