using AspNetCoreWithMongoDb.Business.Interfaces;
using AspNetCoreWithMongoDb.Models;
using AspNetCoreWithMongoDb.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace AspNetCoreWithMongoDb.Business
{
    public class HangarBusiness : IHangarBusiness
    {
        private readonly IHangarRepository _repository;

        public HangarBusiness(IHangarRepository repository)
        {
            _repository = repository;
        }

        public List<Hangar> Get()
        {
            return _repository.Get();
        }

        public Hangar Get(string id)
        {
            return _repository.Get(id);
        }

        public Hangar Create(Hangar hangar)
        {
            hangar.Id = Guid.NewGuid().ToString();

            return _repository.Create(hangar);
        }

        public void Update(string id, Hangar hangarIn)
        {
            var hangar = _repository.Get(id);

            if (hangar != null)
            {
                try
                {
                    _repository.Update(id, hangarIn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Remove(string id)
        {
            _repository.Remove(id);
        }
    }
}
