using CacheMemory.DumpingBuffer.Payload;

namespace CacheMemory.Historical
{
    public interface IDumpingBuffer
    {
        SpentEnergyDto? Pop();
        void Push(SpentEnergyDto data);
        List<SpentEnergyDto> Sync();
    }
}