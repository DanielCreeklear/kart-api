public interface IKartingCircuitRepository
{
    List<KartingCircuit> GetAllCircuits();
    KartingCircuit GetCircuitById(int id);
    KartingCircuit AddCircuit(KartingCircuit newCircuit);
    KartingCircuit UpdateCircuit(int id, KartingCircuit updatedCircuit);
    bool DeleteCircuit(int id);
}