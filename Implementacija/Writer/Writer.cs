using CacheMemory.Structures.Implementations;
using CacheMemory.Structures.Interfaces;
using CacheMemory.Structures.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMemory.Writer
{
    public class Writer
    {
        public readonly IDumpingBuffer DumpingBuffer;
        public readonly IHistorical historical;

        public Writer(IDumpingBuffer dumpingBuffer, IHistorical historical)
        {
            DumpingBuffer = dumpingBuffer;
            this.historical = historical;

            this.StartSyncProcess();
        }

        public void Write(int userId, double spentEnergy)
        {
            DumpingBuffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = spentEnergy,
                UserId = userId,
                Timestamp = DateTime.Now
            });
        }

        public void StartSyncProcess()
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    List<SpentEnergyDto> list = DumpingBuffer.Sync();
                    if (!(list.Count == 0))
                    {
                        historical.SaveNewRecords(list);
                    }
                    await Task.Delay(2_000);
                }
            });
        }
    }
}
