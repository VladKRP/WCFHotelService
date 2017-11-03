using HotelService.Domain;
using HotelService.Domain.DTO;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HotelService.Contracts
{
    [ServiceContract]
    public interface IHotelService: ICRUDService<HotelDTO>
    {
        [OperationContract]
        [WebGet(UriTemplate ="/hotel/{id}/rooms")]
        IEnumerable<RoomDTO> GetHotelRooms(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/hotel/{id}/rooms/vacant")]
        IQueryable<RoomDTO> GetVacantRooms(string id);

        [OperationContract]
        [WebGet(UriTemplate = "hotel/{id}/rooms/reserved")]
        IQueryable<RoomDTO> GetReservedRooms(string id);

        [OperationContract]
        [WebGet(UriTemplate = "hotel/{id}/rooms?type={type}")]
        IQueryable<RoomDTO> GetRoomsByType(string id, string type);

        [OperationContract]
        [WebGet(UriTemplate = "hotel/{id}/rooms/vacant?type={type}")]
        IQueryable<RoomDTO> GetVacantRoomsOfSpecialType(string id, string type);

    }
}
