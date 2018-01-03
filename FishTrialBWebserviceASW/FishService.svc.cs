using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FishTrialBWebserviceASW.Model;

namespace FishTrialBWebserviceASW
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FishService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FishService.svc or FishService.svc.cs at the Solution Explorer and start debugging.
    public class FishService : IFishService
    {

        private static readonly IList<Fangst> FangstListe = new List<Fangst>();
        private static int _nextid = 4;

        static FishService()
        {
            Fangst firstFangst = new Fangst()
            {
                Id = 1,
                Navn = "EbbeVand",
                Art = "Gedde",
                Veagt = 3.75,
                Sted = "Aresø",
                Uge = 2

            };

            FangstListe.Add(firstFangst);

            Fangst secondFangst = new Fangst()
            {
                Id = 2,
                Navn = "PerterStor",
                Art = "Ørred",
                Veagt = 1.55,
                Sted = "Emsø",
                Uge = 7

            };

            FangstListe.Add(secondFangst);

            Fangst thirdFangst = new Fangst()
            {
                Id = 3,
                Navn = "AndyBor",
                Art = "Skalle",
                Veagt = 0.35,
                Sted = "Vejlesø",
                Uge = 25

            };

            FangstListe.Add(thirdFangst);
        }


        public IList<Fangst> GetCatches()
        {
            return FangstListe;
        }

        public Fangst GetCatch(string id)
        {
            int idNumber = int.Parse(id);
            return FangstListe.FirstOrDefault((fangst => fangst.Id == idNumber));
        }


        public Fangst AddCatch(Fangst fangst)
        {
            fangst.Id = _nextid++;
            FangstListe.Add(fangst);
            return fangst;
        }

        public Fangst UpdateCatch(string id, Fangst fangst)
        {
            int idNumber = int.Parse(id);
            Fangst existingFangst = FangstListe.FirstOrDefault(b => b.Id == idNumber);
            if (existingFangst == null)
            {
                return null;
            }

            existingFangst.Navn = fangst.Navn;
            existingFangst.Art = fangst.Art;
            existingFangst.Veagt = fangst.Veagt;
            existingFangst.Sted = fangst.Sted;
            existingFangst.Uge = fangst.Uge;
            return existingFangst;

        }


        public Fangst DeleteCatch(string id)
        {
            Fangst fangst = GetCatch(id);
            if (fangst == null)
            {
                return null;
            }

            bool removed = FangstListe.Remove(fangst);
            if (removed)
            {
                return fangst;
            }

            return null;
        }




        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}


    }
}
