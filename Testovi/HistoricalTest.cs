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
		[Test]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		[TestCase(4)]
		[TestCase(5)]
		[TestCase(6)]
		[TestCase(7)]
		[TestCase(8)]
		[TestCase(9)]
		[TestCase(10)]
		[TestCase(11)]
		[TestCase(12)]
		[TestCase(13)]
		[TestCase(14)]
		[TestCase(15)]
		[TestCase(16)]
		[TestCase(17)]
		[TestCase(18)]
		[TestCase(19)]
		[TestCase(20)]	
		public void GetRecordsByUserTest(int userId)
		{
			var hist = new Mock<IHistorical>();
			List<SpentEnergyRecord> lista = new List<SpentEnergyRecord>();
			lista = hist.Object.GetRecordsByUser(userId);

			NUnit.Framework.Assert.That(lista, Is.EqualTo(hist.Object.GetRecordsByUser(userId)));
		}

		[Test]
		[TestCase("Novi Sad")]
		[TestCase("Beograd")]
		[TestCase("Sabac")]
		[TestCase("Vrbas")]
		[TestCase("Kragujevac")]
		[TestCase("Sombor")]
		[TestCase("Zrenjanin")]
		[TestCase("Subotica")]
		public void GetMetersByCityNameTest(string city)
		{
			var hist = new Mock<IHistorical>();
			List<SpentEnergyMeter> lista = new List<SpentEnergyMeter>();
			lista = hist.Object.GetMetersByCityName(city);

			NUnit.Framework.Assert.That(lista, Is.EqualTo(hist.Object.GetMetersByCityName(city)));
		}
    }
}
