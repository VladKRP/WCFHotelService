using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HotelService.Contracts
{
    [ServiceContract]
    public interface ICRUDService<Entity>
    {
        [OperationContract]
        [WebGet(UriTemplate = "/{id}")]
        Entity Get(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/")]
        IEnumerable<Entity> GetAll();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/")]
        void Create(Entity entity);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/{id}")]
        void Update(string id, Entity entity);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/{id}")]
        void Delete(string id);
    }
}
