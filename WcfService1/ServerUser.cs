using System.ServiceModel;

namespace WcfService1
{
    public class ServerUser : T_Reader
    {
        public OperationContext operationContext { get; set; }
    }
}