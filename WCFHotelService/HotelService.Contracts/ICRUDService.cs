using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HotelService.Contracts
{
    [ServiceContract]
    public interface ICRUDService<Entity,key>
    {
        [OperationContract]
        [WebGet]
        Entity Get(key id);

        [OperationContract]
        [WebGet]
        IEnumerable<Entity> GetAll();

        [OperationContract]
        [WebInvoke(Method = "POST")]
        void Create(Entity entity);

        [OperationContract]
        [WebInvoke(Method = "PUT")]
        void Update(Entity entity);

        [OperationContract]
        [WebInvoke(Method = "DELETE")]
        void Delete(Entity entity);
    }
}
