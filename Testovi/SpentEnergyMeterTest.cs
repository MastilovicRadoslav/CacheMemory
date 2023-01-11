using CacheMemory.Structures.Payload;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
namespace Testiranje
{
    public class SpentEnergyMeterTest
    {
        #region TestoviSaDobrimParametrima
        [Test]
        [TestCase(1, 123.55, "MilosKoric", "Brece Tomica", "23", "Loznica", "Srbija")]
        [TestCase(25, 543.6, "SaraSaric", "Napredna", "49", "Mali Idos", "Srbija")]
        [TestCase(9, 119.2, "StefanSaric", "Bulevar Slobode", "71", "Novi Sad", "Srbija")]
        [TestCase(49, 145.8, "AnaAnisic", "Bulevar Evrope", "39", "Pancevo", "Srbija")]

        public void SpentEnergyMeterDobriParametri(int id, double spentEnergyTotal, string userName, string streetName, string streetNumber, string city, string state)
        {
            SpentEnergyMeter spm = new SpentEnergyMeter(id, spentEnergyTotal, userName, streetName, streetNumber, city, state);

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
        [TestCase(1, 123.55, "", "Beogradska", "12", "Kikinda", "Srbija")]
        [TestCase(12, 245, "MilosMikic", "", "43", "Novi Sad", "Srbija")]
        [TestCase(34, 223.5, "NikolaNikolic", "Milosa Obilica", "", "Vrbas", "Srbija")]
        [TestCase(46, 400.23, "NemanjaBorisic", "Jovan Jovanovic Zmaj", "71", "", "Srbija")]
        [TestCase(55, 132.666, "AleksandarArsic", "Petofi Sandora", "12", "Apatin", "")]
        [TestCase(77, 341.34, "", "", "135", "Sombor", "Srbija")]
        [TestCase(23, 117.4, "", "", "", "", "")]
        [TestCase(55, 139.641, "NiksaMaric", "", "12", "Apatin", "")]
        [TestCase(55, 183.773, "NikolinaBrkic", "Bulevar Cara Dusana", "", "", "")]
        public void SpentEnergyMeterLosiParametri(int id, double spentEnergyTotal, string userName, string streetName, string streetNumber, string city, string state)
        {

            NUnit.Framework.Assert.Throws<ArgumentException>(
                () =>
                {
                    SpentEnergyMeter spm = new SpentEnergyMeter(id, spentEnergyTotal, userName, streetName, streetNumber, city, state);
                });
        }
        #endregion

        #region TestoviSaNullParametrima
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [TestCase(11, 125.15, null, "Bulevar Evrope", "82", "Novi Sad", "Srbija")]
        [TestCase(24, 241.1, "AnaMijic", null, "29", "Becej", "Srbija")]
        [TestCase(68, 221.35, "MarkoMirotic", "Miroslava Tomica", null, "Beograd", "Srbija")]
        [TestCase(99, 444, "JelenaJelic", "Veres Marti Mihalja", "66", null, "Srbija")]
        [TestCase(23, 321.15, "MarijaMirosavljevic", "Veres Marti Mihalja", "39", "Nis", null)]
        [TestCase(13, 32.56, null, "Nikole Jovanovica", "75", "Obrenovac", null)]
        [TestCase(52, 387.56, null, "Jovana Cvijica", "79", null, "Srbija")]
        [TestCase(95, 99.56, null, null, "88", "Lovcenac", "Srbija")]
        [TestCase(75, 531, null, "Nikole Tesle", null, "Jagodina", "Srbija")]
        public void SpentEnergyMeterLosiParametriNull(int id, double spentEnergyTotal, string userName, string streetName, string streetNumber, string city, string state)
        {

            NUnit.Framework.Assert.Throws<ArgumentNullException>(
                () =>
                {
                    SpentEnergyMeter spm = new SpentEnergyMeter(id, spentEnergyTotal, userName, streetName, streetNumber, city, state);
                });
        }
        #endregion
    }
}