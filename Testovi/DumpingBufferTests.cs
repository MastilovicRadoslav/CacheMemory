using CacheMemory.Structures.Implementations;
using CacheMemory.Structures.Interfaces;
using CacheMemory.Structures.Payload;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CacheMemory.Tests
{
    public class DumpingBufferTests
    {
        [Fact]
        public void DumpingBuffer_Add_OneStored()
        {
            ConcurrentQueue<SpentEnergyDto> queue = new();
            IDumpingBuffer buffer = new DumpingBuffer(queue);

            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 2,
                Timestamp = DateTime.Now,
                UserId = 2
            });

            Assert.Single(queue);
        }

        [Fact]
        public void DumpingBuffer_Remove_LastElementReturned()
        {
            ConcurrentQueue<SpentEnergyDto> queue = new();
            IDumpingBuffer buffer = new DumpingBuffer(queue);


            var firstAddedElement = new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
                UserId = 6
            };
            buffer.Add(firstAddedElement);

            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 2,
                Timestamp = DateTime.Now,
                UserId = 2
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 4,
                Timestamp = DateTime.Now,
                UserId = 3
            });


            var firstStoredElement = buffer.Remove();

            Assert.Equal(firstAddedElement, firstStoredElement);
        }

        [Fact]
        public void DumpingBuffer_Sync_LessThanSevenELementsStored_ReturnsEmptyList()
        {
            ConcurrentQueue<SpentEnergyDto> queue = new();
            IDumpingBuffer buffer = new DumpingBuffer(queue);


            var firstAddedElement = new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
                UserId = 6
            };
            buffer.Add(firstAddedElement);

            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 2,
                Timestamp = DateTime.Now,
                UserId = 2
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 4,
                Timestamp = DateTime.Now,
                UserId = 3
            });


            var elementsToBeStoredToTheDb = buffer.Sync();

            Assert.Empty(elementsToBeStoredToTheDb);
        }

        [Fact]
        public void DumpingBuffer_Sync_MoreThanSevenELementsStored_ReturnsSevenElementsList()
        {
            ConcurrentQueue<SpentEnergyDto> queue = new();
            IDumpingBuffer buffer = new DumpingBuffer(queue);

            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
                UserId = 6
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 2,
                Timestamp = DateTime.Now,
                UserId = 2
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 4,
                Timestamp = DateTime.Now,
                UserId = 3
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 5,
                Timestamp = DateTime.Now,
                UserId = 5
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 7,
                Timestamp = DateTime.Now,
                UserId = 7
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
                UserId = 1
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 8,
                Timestamp = DateTime.Now,
                UserId = 8
            });


            var elementsToBeStoredToTheDb = buffer.Sync();

            Assert.Equal(7, elementsToBeStoredToTheDb.Count);
        }

        [Fact]
        public void DumpingBuffer_Sync_MoreThanSevenELementsStored_ReturnsFirstSevenElements()
        {
            ConcurrentQueue<SpentEnergyDto> queue = new();
            IDumpingBuffer buffer = new DumpingBuffer(queue);

            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
                UserId = 6
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 2,
                Timestamp = DateTime.Now,
                UserId = 2
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 4,
                Timestamp = DateTime.Now,
                UserId = 3
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 5,
                Timestamp = DateTime.Now,
                UserId = 5
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 7,
                Timestamp = DateTime.Now,
                UserId = 7
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
                UserId = 1
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
                UserId = 1
            });

            var eighth = new SpentEnergyDto()
            {
                SpentEnergy = 8,
                Timestamp = DateTime.Now,
                UserId = 8
            };
            buffer.Add(eighth);

            buffer.Sync();

            Assert.Equal(eighth, buffer.Remove());
        }

        [Fact]
        public void DumpingBuffer_Sync_MoreThan17ELementsStored_RemovedNumberOfElementsDivisibleBy7()
        {
            ConcurrentQueue<SpentEnergyDto> queue = new();
            IDumpingBuffer buffer = new DumpingBuffer(queue);

            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
                UserId = 6
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 2,
                Timestamp = DateTime.Now,
                UserId = 2
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 4,
                Timestamp = DateTime.Now,
                UserId = 3
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 5,
                Timestamp = DateTime.Now,
                UserId = 5
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 7,
                Timestamp = DateTime.Now,
                UserId = 7
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
                UserId = 1
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
                UserId = 1
            });

            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
                UserId = 6
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 2,
                Timestamp = DateTime.Now,
                UserId = 2
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 4,
                Timestamp = DateTime.Now,
                UserId = 3
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 5,
                Timestamp = DateTime.Now,
                UserId = 5
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 7,
                Timestamp = DateTime.Now,
                UserId = 7
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
                UserId = 1
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
               
                
                UserId = 1
            });

            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 7,
                Timestamp = DateTime.Now,
                UserId = 7
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
                UserId = 1
            });
            buffer.Add(new SpentEnergyDto()
            {
                SpentEnergy = 1,
                Timestamp = DateTime.Now,
                UserId = 1
            });


            var elementsRemovedFromBuffer = buffer.Sync();

            Assert.Equal(0, elementsRemovedFromBuffer.Count % 7);
        }
    }
}
