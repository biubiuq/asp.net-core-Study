using System;

namespace Study.IRepo
{
    public interface IRepositoryBase<T>
    {
        T GetT(string Id);
        bool UpData(T t);
        bool Delete(T guid);
    }
}

