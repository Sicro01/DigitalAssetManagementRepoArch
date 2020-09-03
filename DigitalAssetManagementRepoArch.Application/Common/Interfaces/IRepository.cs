using System.Collections.Generic;

namespace DigitalAssetManagementRepoArch.Application.Common.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        void Save();
    }
}
