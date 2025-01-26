using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class KartingCircuitController : ControllerBase
{
    private static List<dynamic> circuits = new()
    {
        new { Id = 1, Name = "Kartódromo Internacional Granja Viana", Location = "Cotia, SP", PricePerBattery = 150.0 },
        new { Id = 2, Name = "Kartódromo Aldeia da Serra", Location = "Barueri, SP", PricePerBattery = 130.0 }
    };

    [HttpGet]
    public IActionResult GetAllCircuits()
    {
        return Ok(circuits);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetCircuitById(int id)
    {
        var circuit = circuits.FirstOrDefault(c => c.Id == id);
        if (circuit == null)
            return NotFound($"Circuit with ID {id} not found.");
        
        return Ok(circuit);
    }

    [HttpPost]
    public IActionResult CreateCircuit([FromBody] dynamic newCircuit)
    {
        if (newCircuit == null || string.IsNullOrEmpty(newCircuit.Name))
            return BadRequest("Invalid circuit data.");

        int newId = circuits.Max(c => c.Id) + 1;
        var circuit = new
        {
            Id = newId,
            newCircuit.Name,
            newCircuit.Location,
            newCircuit.PricePerBattery
        };

        circuits.Add(circuit);
        return CreatedAtAction(nameof(GetCircuitById), new { id = newId }, circuit);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateCircuit(int id, [FromBody] dynamic updatedCircuit)
    {
        var existingCircuit = circuits.FirstOrDefault(c => c.Id == id);
        if (existingCircuit == null)
            return NotFound($"Circuit with ID {id} not found.");

        existingCircuit.Name = updatedCircuit.Name ?? existingCircuit.Name;
        existingCircuit.Location = updatedCircuit.Location ?? existingCircuit.Location;
        existingCircuit.PricePerBattery = updatedCircuit.PricePerBattery ?? existingCircuit.PricePerBattery;

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteCircuit(int id)
    {
        var circuit = circuits.FirstOrDefault(c => c.Id == id);
        if (circuit == null)
            return NotFound($"Circuit with ID {id} not found.");

        circuits.Remove(circuit);
        return NoContent();
    }
}