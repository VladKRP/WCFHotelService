using HotelService.Domain;
using HotelService.Domain.DTO;
using System.ServiceModel;

namespace HotelService.Contracts
{
    [ServiceContract]
    public interface IRoomService:ICRUDService<RoomDTO>
    {
        
    }
}
