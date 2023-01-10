using CacheMemory.DumpingBuffer.Payload;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMemory.Historical
{
    public class DumpingBuffer : IDumpingBuffer
    {
        private ConcurrentQueue<SpentEnergyDto> buffer;

        public DumpingBuffer(ConcurrentQueue<SpentEnergyDto> buffer)
        {
            this.buffer = buffer;
        }

        public void Push(SpentEnergyDto data)
        {
            buffer.Enqueue(data);
        }

        public SpentEnergyDto? Pop()
        {
            buffer.TryDequeue(out SpentEnergyDto result);
            return result;
        }

        public List<SpentEnergyDto> Sync()
        {
            var numberOfElementsInQueue = buffer.ToList().Count;
            var numberOfElementsToTransfer = numberOfElementsInQueue % 7;

            var transferList = new List<SpentEnergyDto>();
            for (var i = 0; i < numberOfElementsToTransfer; i++)
            {
                transferList.Add(Pop());
            }

            return transferList;
        }
    }
}
