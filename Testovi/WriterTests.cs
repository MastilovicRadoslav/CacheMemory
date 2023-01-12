using CacheMemory.Structures.Interfaces;
using CacheMemory.Structures.Payload;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CacheMemory.Tests
{
    public class WriterTests
    {
        [Fact]
        public void Writer_Write_DumpingBufferCalled()
        {
            var buffer = new Mock<IDumpingBuffer>();
            var historical = new Mock<IHistorical>();
            Writer.Writer writer = new(buffer.Object, historical.Object);

            writer.Write(It.IsAny<int>(), It.IsAny<double>());

            buffer.Verify(b => b.Add(It.IsAny<SpentEnergyDto>()), Times.Once());
        }

        [Fact]
        public void Writer_Insert_Success()
        {
            var buffer = new Mock<IDumpingBuffer>();
            var historical = new Mock<IHistorical>();
            Writer.Writer writer = new(buffer.Object, historical.Object);

            writer.Write(It.IsAny<int>(), It.IsAny<double>());

            buffer.Verify(b => b.Add(It.IsAny<SpentEnergyDto>()), Times.Once());
        }

        [Fact]
        public async Task Writer_SyncAfterLessThan7ItemsInserted_HistoricalNotCalled()
        {
            var buffer = new Mock<IDumpingBuffer>();
            var historical = new Mock<IHistorical>();
            Writer.Writer writer = new(buffer.Object, historical.Object);

            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());

            await Task.Delay(2_000);

            historical.Verify(b => b.SaveNewRecords(It.IsAny<List<SpentEnergyDto>>()), Times.Never());
        }

        [Fact]
        public async Task Writer_SyncAfterExatly7ItemsInserted_HistoricalNotCalled()
        {
            var buffer = new Mock<IDumpingBuffer>();
            var historical = new Mock<IHistorical>();
            Writer.Writer writer = new(buffer.Object, historical.Object);

            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());

            await Task.Delay(2_000);

            historical.Verify(b => b.SaveNewRecords(It.IsAny<List<SpentEnergyDto>>()), Times.Never());
        }

        [Fact]
        public async Task Writer_SyncAfterLessThan5ItemsInserted_HistoricalNotCalled()
        {
            var buffer = new Mock<IDumpingBuffer>();
            var historical = new Mock<IHistorical>();
            Writer.Writer writer = new(buffer.Object, historical.Object);

            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());

            await Task.Delay(2_000);

            historical.Verify(b => b.SaveNewRecords(It.IsAny<List<SpentEnergyDto>>()), Times.Never());
        }

        [Fact]
        public async Task Writer_SyncAfterMoreThan7ItemsInserted_HistoricalNotCalled()
        {
            var buffer = new Mock<IDumpingBuffer>();
            var historical = new Mock<IHistorical>();
            Writer.Writer writer = new(buffer.Object, historical.Object);

            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());

            await Task.Delay(2_000);

            historical.Verify(b => b.SaveNewRecords(It.IsAny<List<SpentEnergyDto>>()), Times.Never());
        }

        [Fact]
        public async Task Writer_SyncAfterMoreThan14ItemsInserted_HistoricalNotCalled()
        {
            var buffer = new Mock<IDumpingBuffer>();
            var historical = new Mock<IHistorical>();
            Writer.Writer writer = new(buffer.Object, historical.Object);

            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());

            await Task.Delay(2_000);

            historical.Verify(b => b.SaveNewRecords(It.IsAny<List<SpentEnergyDto>>()), Times.Never());
        }

        [Fact]
        public async Task Writer_SyncAfterLessThan14ItemsInserted_HistoricalNotCalled()
        {
            var buffer = new Mock<IDumpingBuffer>();
            var historical = new Mock<IHistorical>();
            Writer.Writer writer = new(buffer.Object, historical.Object);

            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());
            writer.Write(It.IsAny<int>(), It.IsAny<double>());

            await Task.Delay(2_000);

            historical.Verify(b => b.SaveNewRecords(It.IsAny<List<SpentEnergyDto>>()), Times.Never());
        }

        [Fact]
        public Task Writer_Initialized_SyncStarted()
        {
            var buffer = new Mock<IDumpingBuffer>();
            var historical = new Mock<IHistorical>();
            Writer.Writer writer = new(buffer.Object, historical.Object);

            buffer.Verify(b => b.Sync(), Times.Once());
            return Task.CompletedTask;
        }

        [Fact]
        public Task Start_SyncProcess_Test()
        {
            return Task.CompletedTask;
        }
    }
}
