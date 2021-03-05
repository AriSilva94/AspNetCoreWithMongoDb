using AspNetCoreWithMongoDb.Models;
using System.Collections.Generic;

namespace AspNetCoreWithMongoDb.Business.Interfaces
{
    public interface IHangarBusiness
    {
        List<Hangar> Get();
        Hangar Get(string id);
        Hangar Create(Hangar hangar);
        void Update(string id, Hangar hangarIn);
        void Remove(string id);
    }
}
