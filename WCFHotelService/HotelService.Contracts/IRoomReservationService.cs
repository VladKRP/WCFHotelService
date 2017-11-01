using HotelService.Domain;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HotelService.Contracts
{
    [ServiceContract]
    public interface IRoomReservationService:ICRUDService<RoomReservation>
    {
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/room/reservation?isReserved={isReserved}")]
        void ChangeRoomState(Room room, bool isReserved);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/room/reservation/reserve")]
        [FaultContract(typeof(FaultException))]
        void Reserve(RoomReservation reservation);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/room/reservation/reject")]
        [FaultContract(typeof(FaultException))]
        void Reject(RoomReservation reservation);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/room/reservation/extend?days={days}")]
        [FaultContract(typeof(FaultException))]
        void Extend(RoomReservation reservation, int days);
    }
}
