public class KartingCircuitService
{
    private static List<KartingCircuit> circuits = new()
    {
        new KartingCircuit { Id = 1, Name = "Kartódromo Internacional Granja Viana", Location = "Cotia, SP", PricePerBattery = 150.0 },
        new KartingCircuit { Id = 2, Name = "Kartódromo Aldeia da Serra", Location = "Barueri, SP", PricePerBattery = 130.0 }
    };

    public List<KartingCircuit> GetAllCircuits()
    {
        return circuits;
    }

    public KartingCircuit GetCircuitById(int id)
    {
        return circuits.FirstOrDefault(c => c.Id == id);
    }

    public KartingCircuit CreateCircuit(KartingCircuit newCircuit)
    {
        int newId = circuits.Max(c => c.Id) + 1;
        newCircuit.Id = newId;
        circuits.Add(newCircuit);
        return newCircuit;
    }

    public KartingCircuit UpdateCircuit(int id, KartingCircuit updatedCircuit)
    {
        var existingCircuit = circuits.FirstOrDefault(c => c.Id == id);
        if (existingCircuit != null)
        {
            existingCircuit.Name = updatedCircuit.Name ?? existingCircuit.Name;
            existingCircuit.Location = updatedCircuit.Location ?? existingCircuit.Location;
            existingCircuit.PricePerBattery = updatedCircuit.PricePerBattery != 0 ? updatedCircuit.PricePerBattery : existingCircuit.PricePerBattery;
        }
        return existingCircuit;
    }

    public bool DeleteCircuit(int id)
    {
        var circuit = circuits.FirstOrDefault(c => c.Id == id);
        if (circuit != null)
        {
            circuits.Remove(circuit);
            return true;
        }
        return false;
    }
}