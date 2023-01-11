using CacheMemory.Structures.Payload;

namespace CacheMemory.Structures.Interfaces
{
    public interface IDumpingBuffer
    {
        void Add(SpentEnergyDto data);
        SpentEnergyDto? Remove();
        List<SpentEnergyDto> Sync();
    }
}