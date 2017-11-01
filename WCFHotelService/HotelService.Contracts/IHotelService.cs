using HotelService.Domain;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace HotelService.Contracts
{
    [ServiceContract]
    public interface IHotelService: ICRUDService<Hotel, int>
    {
        [OperationContract]
        IEnumerable<Room> GetHotelRooms(int id);

        [OperationContract]
        IQueryable<Room> GetVacantRooms();

        [OperationContract]
        IQueryable<Room> GetReservedRooms();

        [OperationContract]
        IQueryable<Room> GetRoomsByType(RoomType type);

        [OperationContract]
        IQueryable<Room> GetVacantRoomsOfSpecialType(RoomType type);

    }
}
