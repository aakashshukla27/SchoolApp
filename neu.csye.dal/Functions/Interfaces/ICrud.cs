using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neu.csye.dal.Functions.Interfaces
{
    public interface ICrud
    {
        Task<T> Create<T>(T dbObject) where T : class;
        Task<T> Update<T>(int entityId, T dbObject) where T : class;
        Task<T> Read<T>(int entityId) where T : class;
        Task<List<T>> ReadAll<T>() where T : class;
        Task<bool> Delete<T>(int entityId) where T : class;
    }
}
