using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yksikkötestaus.Testit
{
    [TestClass] //C# attribuutti
    public class PääsiäinenTesti
    {
        [TestMethod] //C# attribuutti - metodi
        public void VarmistaPääsiäissunnuntainLaskenta()
        {
            Pääsiäinen pääsiäinen = new Pääsiäinen();

            List<DateTime> oikeatPäivämäärät  = new List<DateTime>()

            {
                new DateTime(2000, 4, 23),
                new DateTime(2001, 4, 15),
                new DateTime(2002, 3, 31)

            };

            for (int vuosi = 2000; vuosi < 2003; vuosi++)
            {
                DateTime sunnuntai = pääsiäinen.GetEasterSunday(vuosi);
                int indeksi = vuosi - 2000;
                DateTime oikeaPvm = oikeatPäivämäärät[indeksi];
                Assert.AreEqual(oikeaPvm, sunnuntai.Date);

                Debug.WriteLine($"Tarkistettu vuosi {vuosi}, oikea pääsiäissunnuntai on {sunnuntai.Date}.");
            }



            //DateTime sunnuntai = pääsiäinen.GetEasterSunday(2018);

            //if (!(sunnuntai.Date == new DateTime(2018, 4, 1)))
            //{
            //    throw new Exception("Pääsiäinen laskettu väärin!");
            //}
            //Assert.AreEqual(new DateTime(2018, 4, 1), sunnuntai.Date);
        }

        [TestMethod] //C# attribuutti - metodi
        public void VarmsitaVuosiluvunTarkistus()
        {
            try
            {
                Pääsiäinen pääsiäinen = new Pääsiäinen();
                DateTime sunnuntai = pääsiäinen.GetEasterSunday(1850);

                Assert.Fail("Rutiini ei nostanut poikkeusta vaikka vuosi on virheellinen");
            }
            catch (ArgumentOutOfRangeException)
            {
                //
            }
        }
    }
}
