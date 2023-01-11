using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMemory.Structures.Payload
{
    public record SpentEnergyDto
    {
        #region Polja
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }
        public double SpentEnergy { get; set; }
        #endregion
    }
}
