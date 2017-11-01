using HotelService.Domain;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HotelService.Contracts
{
    [ServiceContract]
    public interface IGuestService:ICRUDService<Guest>
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/guest/changestatus?type={type}")]
        void ChangeGuestStatusType(Guest guest, GuestType type);
    }
}
