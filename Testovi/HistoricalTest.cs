using CacheMemory.Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Moq;
using CacheMemory.Structures.Interfaces;
using CacheMemory.Structures.Payload;
using System.Linq;

namespace Testiranje
{
    public class HistoricalTest
    {
        [Test]
        [TestCase(01)]
        [TestCase(02)]
        [TestCase(03)]
        [TestCase(04)]
        [TestCase(05)]
        [TestCase(06)]
        [TestCase(07)]
        [TestCase(08)]
        [TestCase(09)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        public void GetRecordsByMonthTest(int month)
        {
            var hist = new Mock<IHistorical>();
            List<SpentEnergyRecord> lista = new List<SpentEnergyRecord>();
            lista = hist.Object.GetRecordsByMonth(month);

            NUnit.Framework.Assert.That(lista, Is.EqualTo(hist.Object.GetRecordsByMonth(month)));
        }
    }
}
