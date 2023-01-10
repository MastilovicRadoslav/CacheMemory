using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMemory.DumpingBuffer.Payload
{
    public record SpentEnergyDto
    {
        public DateTime Timestamp { get; set; }
        public Guid UserId { get; set; }
        public double SpentEnergy { get; set; }
    }
}
