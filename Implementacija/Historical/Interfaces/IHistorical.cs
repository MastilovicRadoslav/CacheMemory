using CacheMemory.Structures.Payload;

namespace CacheMemory.Structures.Interfaces
{
    public interface IHistorical
    {
        List<SpentEnergyRecord> GetRecordsByMonth(int month);
        void SaveNewRecords(List<SpentEnergyDto> spentEnergyMeters);
        List<SpentEnergyRecord> GetRecordsByUser(int userId);
        List<SpentEnergyMeter> GetMetersByCityName(string city);
    }
}