using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMemory.Structures.Payload
{
    public class SpentEnergyMeter
    {
        #region Polja
        public int Id { get; set; }
        public double SpentEnergyTotal { get; set; }
        public string? UserName { get; set; }
        public string? StreetName { get; set; }
        public string? StreetNumber { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        #endregion

        #region Konstruktori
        public SpentEnergyMeter(int id, double spentEnergyTotal, string? userName, string? streetName, string? streetNumber, string? city, string? state)
        {
            if (userName == null || streetName == null ||streetNumber == null || city == null || state == null)
            {
                throw new ArgumentNullException("Argumenti ne smeju biti null");
            }
            if (userName.Trim() == "")
            {
                throw new ArgumentException("Korisničko ime mora da sadrzi karaktere");
            }
            if (streetNumber.Trim() == "")
            {
                throw new ArgumentException("Broj ulice mora da sadrzi karaktere");
            }
            if (streetName.Trim() == "")
            {
                throw new ArgumentException("Naziv ulice mora da sadrzi karaktere");
            }
            if (city.Trim() == "")
            {
                throw new ArgumentException("Naziv grada mora da sadrzi karaktere");
            }
            if (state.Trim() == "")
            {
                throw new ArgumentException("Država mora da sadrzi karaktere");
            }

            Id = id;
            SpentEnergyTotal = spentEnergyTotal;
            UserName = userName;
            StreetName = streetName;
            StreetNumber = streetNumber;
            City = city;
            State = state;
        }

        public SpentEnergyMeter()
        {
        }
        #endregion

        #region Overrides Metode
        public override string? ToString()
        {
            string ispis = "ID korisnika : " + Id + ", korisničko ime : " + UserName + ", potrošnja toplotne energije iznosi : " + SpentEnergyTotal + ", naziv ulice : " + StreetName + ", broj kuće/zgrade : " + StreetNumber + ", naziv grada : " + City + ", naziv države : " + State;
            return ispis;
        }
        #endregion
    }
}