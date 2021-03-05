using AspNetCoreWithMongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithMongoDb.Repository.Interfaces
{
    public interface IHangarRepository
    {
        List<Hangar> Get();
        Hangar Get(string id);
        Hangar Create(Hangar hangar);
        void Update(string id, Hangar hangarIn);
        void Remove(string id);
    }
}
