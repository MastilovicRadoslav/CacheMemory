using CacheMemory.Structures.Payload;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testiranje
{
    public class SpentEnergyRecordTest
    {
        #region TestoviSaDobrimParametrima
        [Test]
        [TestCase(159.55, 13, "MilosKoric", "Brece Tomica", "23", "Loznica", "Srbija")]
        [TestCase(328, 41, "SaraSaric", "Napredna", "49", "Mali Idos", "Srbija")]
        [TestCase(196.2, 22, "StefanSaric", "Bulevar Slobode", "71", "Novi Sad", "Srbija")]
        [TestCase(133.1, 51, "AnaAnisic", "Bulevar Evrope", "39", "Pancevo", "Srbija")]

        public void SpentEnergyRecordDobriParametri(double spentEnergyTotal, int id, string userName, string streetName, string streetNumber, string city, string state)
        {
            SpentEnergyRecord spm = new SpentEnergyRecord(spentEnergyTotal, id, userName, streetName, streetNumber, city, state);

            NUnit.Framework.Assert.That(userName, Is.EqualTo(spm.UserName));
            NUnit.Framework.Assert.That(streetName, Is.EqualTo(spm.StreetName));
            NUnit.Framework.Assert.That(streetNumber, Is.EqualTo(spm.StreetNumber));
            NUnit.Framework.Assert.That(city, Is.EqualTo(spm.City));
            NUnit.Framework.Assert.That(state, Is.EqualTo(spm.State));
        }
        #endregion

        #region TestoviSaLosimParametrima
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        [TestCase(123.55, 59, "", "Beogradska", "12", "Kikinda", "Srbija")]
        [TestCase(245.7, 33, "MilosMikic", "", "43", "Novi Sad", "Srbija")]
        [TestCase(223.5, 41, "NikolaNikolic", "Milosa Obilica", "", "Vrbas", "Srbija")]
        [TestCase(400.23, 11, "NemanjaBorisic", "Jovan Jovanovic Zmaj", "71", "", "Srbija")]
        [TestCase(131, 59, "AleksandarArsic", "Petofi Sandora", "12", "Apatin", "")]
        [TestCase(346.34, 88, "", "", "135", "Sombor", "Srbija")]
        [TestCase(117.47, 53, "", "", "", "", "")]
        [TestCase(131.79, 77, "NiksaMaric", "", "12", "Apatin", "")]
        [TestCase(149.135, 57, "NikolinaBrkic", "Bulevar Cara Dusana", "", "", "")]
        public void SpentEnergyRecordLosiParametri(double spentEnergyTotal, int id, string userName, string streetName, string streetNumber, string city, string state)
        {

            NUnit.Framework.Assert.Throws<ArgumentException>(
            () =>
            {
                SpentEnergyRecord spm = new SpentEnergyRecord(spentEnergyTotal, id, userName, streetName, streetNumber, city, state);
            });
        }
        #endregion

        #region TestoviSaNullParametrima
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [TestCase(125.15, 13, null, "Bulevar Evrope", "82", "Novi Sad", "Srbija")]
        [TestCase(263.1, 13, "AnaMijic", null, "29", "Becej", "Srbija")]
        [TestCase(221.35, 52, "MarkoMirotic", "Miroslava Tomica", null, "Beograd", "Srbija")]
        [TestCase(444.91, 61, "JelenaJelic", "Veres Marti Mihalja", "66", null, "Srbija")]
        [TestCase(321.15, 32, "MarijaMirosavljevic", "Veres Marti Mihalja", "39", "Nis", null)]
        [TestCase(32.56, 79, null, "Nikole Jovanovica", "75", "Obrenovac", null)]
        [TestCase(387.56, 41, null, "Jovana Cvijica", "79", null, "Srbija")]
        [TestCase(99.56, 51, null, null, "88", "Lovcenac", "Srbija")]
        [TestCase(759.421, 91, null, "Nikole Tesle", null, "Jagodina", "Srbija")]
        public void SpentEnergyRecordLosiParametriNull(double spentEnergyTotal, int id, string userName, string streetName, string streetNumber, string city, string state)
        {

            NUnit.Framework.Assert.Throws<ArgumentNullException>(
                () =>
                {
                    SpentEnergyRecord spm = new SpentEnergyRecord(spentEnergyTotal, id, userName, streetName, streetNumber, city, state);
                });
        }
        #endregion
    }
}
