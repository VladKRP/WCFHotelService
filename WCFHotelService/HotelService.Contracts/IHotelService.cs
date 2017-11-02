using HotelService.Domain;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HotelService.Contracts
{
    [ServiceContract]
    public interface IHotelService: ICRUDService<Hotel>
    {
        [OperationContract]
        [WebGet(UriTemplate ="/hotel/{id}/rooms")]
        IEnumerable<Room> GetHotelRooms(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/hotel/{id}/rooms/vacant")]
        IQueryable<Room> GetVacantRooms(string id);

        [OperationContract]
        [WebGet(UriTemplate = "hotel/{id}/rooms/reserved")]
        IQueryable<Room> GetReservedRooms(string id);

        [OperationContract]
        [WebGet(UriTemplate = "hotel/{id}/rooms?type={type}")]
        IQueryable<Room> GetRoomsByType(string id, string type);

        [OperationContract]
        [WebGet(UriTemplate = "hotel/{id}/rooms/vacant?type={type}")]
        IQueryable<Room> GetVacantRoomsOfSpecialType(string id, string type);

    }
}
