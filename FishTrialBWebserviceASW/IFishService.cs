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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFishService" in both code and config file together.
    [ServiceContract]
    public interface IFishService
    {
       /// <summary>
       /// Henter alle fangster i listen. Url er plural - catches.
       /// </summary>
       /// <returns></returns>

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "catches")]
        IList<Fangst> GetCatches();

        /// <summary>
        /// Henter en fangst vha Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "catch/{id}")]
        Fangst GetCatch(string id);

        /// <summary>
        /// Poster/tilføjer en fangst af typen fangst til listen.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "catches")]
        Fangst AddCatch(Fangst fangst);

        //Add kunne være void. 

        /// <summary>
        /// Updatere en fangst vha id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fangst"></param>
        /// <returns></returns>

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "catches/{id}")]
        Fangst UpdateCatch(string id, Fangst fangst);

        /// <summary>
        /// Sletter en fangst vha ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "catches/{id}")]
        Fangst DeleteCatch(string id);



        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        //// TODO: Add your service operations here
    }


    //// Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
