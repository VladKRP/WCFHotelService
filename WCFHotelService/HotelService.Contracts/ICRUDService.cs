using System.Collections.Generic;
using System.ServiceModel;

namespace HotelService.Contracts
{
    [ServiceContract]
    public interface ICRUDService<Entity,key>
    {
        [OperationContract]
        Entity Get(key id);
        [OperationContract]
        IEnumerable<Entity> GetAll();
        [OperationContract]
        void Create(Entity entity);
        [OperationContract]
        void Update(key id, Entity entity);
        [OperationContract]
        void Delete(Entity entity);
    }
}
