using HotelService.Domain;
using System.ServiceModel;


namespace HotelService.Contracts
{
    [ServiceContract]
    public interface IGuestService:ICRUDService<Guest, int>
    {
        [OperationContract]
        void ChangeGuestStatusType(Guest guest, GuestType type);
    }
}
