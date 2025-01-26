using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class KartingCircuitController(KartingCircuitService circuitService) : ControllerBase
{
    private readonly KartingCircuitService _circuitService = circuitService;

    [HttpGet]
    public IActionResult GetAllCircuits()
    {
        var circuits = _circuitService.GetAllCircuits();
        return Ok(circuits);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetCircuitById(int id)
    {
        var circuit = _circuitService.GetCircuitById(id);
        if (circuit == null)
            return NotFound($"Circuit with ID {id} not found.");
        
        return Ok(circuit);
    }

    [HttpPost]
    public IActionResult CreateCircuit([FromBody] dynamic newCircuit)
    {
        if (newCircuit == null || string.IsNullOrEmpty(newCircuit.Name))
            return BadRequest("Invalid circuit data.");

        var createdCircuit = _circuitService.CreateCircuit(newCircuit);
        return CreatedAtAction(nameof(GetCircuitById), new { id = createdCircuit.Id }, createdCircuit);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateCircuit(int id, [FromBody] dynamic updatedCircuit)
    {
        var existingCircuit = _circuitService.UpdateCircuit(id, updatedCircuit);
        if (existingCircuit == null)
            return NotFound($"Circuit with ID {id} not found.");

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteCircuit(int id)
    {
        var success = _circuitService.DeleteCircuit(id);
        if (!success)
            return NotFound($"Circuit with ID {id} not found.");

        return NoContent();
    }
}