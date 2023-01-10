using CacheMemory.Structures.Interfaces;
using CacheMemory.Structures.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMemory.Reader
{
    public class Reader
    {
        private readonly IHistorical hist;

        public Reader(IHistorical historical)
        {
            hist = historical;
        }

        public List<SpentEnergyRecord> SearchByMonth(int month)
        {
            return hist.GetRecordsByMonth(month);
        }

        public List<SpentEnergyRecord> SearchByUser(int userId)
        {
            return hist.GetRecordsByUser(userId);
        }

        public List<SpentEnergyMeter> SearchCityName(string city)
        {
            return hist.GetMetersByCityName(city);
        }

        public void SaveRecords(List<SpentEnergyDto> newRecords)
        {
            hist.SaveNewRecords(newRecords);
        }
    }
}