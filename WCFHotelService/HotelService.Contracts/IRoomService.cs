using HotelService.Domain;
using System.ServiceModel;

namespace HotelService.Contracts
{
    [ServiceContract]
    public interface IRoomService:ICRUDService<Room>
    {

    }
}
