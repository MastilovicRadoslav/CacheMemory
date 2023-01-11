using CacheMemory.Structures.Interfaces;
using CacheMemory.Structures.Payload;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMemory.Structures.Implementations
{
    public class DumpingBuffer : IDumpingBuffer
    {
        private ConcurrentQueue<SpentEnergyDto> buffer;

        public DumpingBuffer(ConcurrentQueue<SpentEnergyDto> buffer)
        {
            this.buffer = buffer;
        }

        public void Add(SpentEnergyDto data)
        {
            buffer.Enqueue(data);
        }

        public SpentEnergyDto? Remove()
        {
            _ = buffer.TryDequeue(out SpentEnergyDto result);
            return result;
        }

        public List<SpentEnergyDto> Sync()
        {
            var numberOfElementsInQueue = buffer.ToList().Count;
            var numberOfElementsToTransfer = numberOfElementsInQueue - numberOfElementsInQueue % 7;

            var transferList = new List<SpentEnergyDto>();
            for (var i = 0; i < numberOfElementsToTransfer; i++)
            {
                transferList.Add(Remove());
            }

            return transferList;
        }
    }
}
