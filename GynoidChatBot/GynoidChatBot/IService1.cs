using System.ServiceModel;
using System.Threading.Tasks;

namespace GynoidChatBot
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Task<string> GetAnswer(string question);
    }
}
