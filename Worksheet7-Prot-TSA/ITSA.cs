using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TSA
{
    [ServiceContract]
    public interface ITSA
    {
        [OperationContract]
        string GetTimestamp(string base64Hash);
    }
}
