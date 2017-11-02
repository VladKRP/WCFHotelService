using HotelService.Domain;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HotelService.Contracts
{
    [ServiceContract]
    public interface IGuestService:ICRUDService<Guest>
    {
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/guest/{id}/changestatus?type={type}")]
        void ChangeGuestStatusType(string id, GuestType type);
    }
}
