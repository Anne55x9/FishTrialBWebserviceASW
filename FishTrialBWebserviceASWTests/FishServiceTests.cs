using Microsoft.VisualStudio.TestTools.UnitTesting;
using FishTrialBWebserviceASW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishTrialBWebserviceASW.Model;

namespace FishTrialBWebserviceASW.Tests
{
    [TestClass()]
    public class FishServiceTests
    {
        [TestMethod()]
        public void GetCatchesTest()
        {
            //Arrange

            IFishService service = new FishService();

            //Act

            IList<Fangst> fangster = service.GetCatches();

            //Assert

            Assert.IsTrue(fangster.Count > 0);
        }

        [TestMethod()]
        public void AddCatchTest()
        {
            //Arrange

            IFishService service = new FishService();

            //Act

            IList<Fangst> fangstliste = service.GetCatches();

            int count = fangstliste.Count;

            service.AddCatch(new Fangst() { Navn = "Navntest", Art = "TestArt", Veagt = 44, Sted = "TestSted", Uge = 66});

            fangstliste = service.GetCatches();

            int newCount = fangstliste.Count;

            //Assert

            Assert.AreEqual(count + 1, newCount);
        }


    }
}