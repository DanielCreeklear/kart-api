using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class KartingCircuitController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllCircuits()
    {
        var circuits = new[]
        {
            new { Id = 1, Name = "Kartódromo Internacional Granja Viana", Location = "Cotia, SP", PricePerBattery = 150.0 },
            new { Id = 2, Name = "Kartódromo Aldeia da Serra", Location = "Barueri, SP", PricePerBattery = 130.0 }
        };

        return Ok(circuits);
    }
}