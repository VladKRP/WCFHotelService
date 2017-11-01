using HotelService.Domain;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HotelService.Contracts
{
    [ServiceContract]
    public interface IRoomReservationService:ICRUDService<RoomReservation, int>
    {
        [OperationContract]
        [WebInvoke(Method = "PUT")]
        void ChangeRoomState(Room room, bool isReserved);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        [FaultContract(typeof(FaultException))]
        void Reserve(RoomReservation reservation);

        [OperationContract]
        [WebInvoke(Method = "PUT")]
        [FaultContract(typeof(FaultException))]
        void Reject(RoomReservation reservation);

        [OperationContract]
        [WebInvoke(Method = "PUT")]
        [FaultContract(typeof(FaultException))]
        void Extend(RoomReservation reservation, int days);
    }
}
