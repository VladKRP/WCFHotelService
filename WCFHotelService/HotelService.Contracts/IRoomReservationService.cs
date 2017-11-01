using HotelService.Domain;
using System.ServiceModel;

namespace HotelService.Contracts
{
    [ServiceContract]
    public interface IRoomReservationService:ICRUDService<RoomReservation, int>
    {
        [OperationContract]
        void ChangeRoomState(Room room, bool isReserved);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void Reserve(RoomReservation reservation);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void Reject(RoomReservation reservation);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void Extend(RoomReservation reservation, int days);
    }
}
