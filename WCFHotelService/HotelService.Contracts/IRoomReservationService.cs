using HotelService.Domain;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HotelService.Contracts
{
    [ServiceContract]
    public interface IRoomReservationService:ICRUDService<RoomReservation>
    {
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/room/{roomId}/reservation?isReserved={isReserved}")]
        void ChangeRoomState(string roomId, bool isReserved);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/room/reservation/reserve")]
        [FaultContract(typeof(FaultException))]
        void Reserve(RoomReservation reservation);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/room/reservation/reject")]
        [FaultContract(typeof(FaultException))]
        void Reject(string reservationId);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/room/reservation/extend?days={days}")]
        [FaultContract(typeof(FaultException))]
        void Extend(string reservationId, int days);
    }
}
