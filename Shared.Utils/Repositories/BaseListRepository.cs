using Shared.Utils.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Utils.Repositories
{
    public class BaseListRepository<T, T1> where T : IEntityIdentifier<T1>
    {
        protected readonly List<T> _data;

        public BaseListRepository()
        {
            _data = new List<T>();
        }

        public async Task Add(T data, CancellationToken cancellationToken)
        {
            _data.Add(data);
        }

        public async Task Remove(T data, CancellationToken cancellationToken)
        {
            _data.Remove(data);
        }

        public async Task Update(T data, CancellationToken cancellationToken)
        {
            _data.RemoveAll(e => e.Id.Equals(data.Id));
            _data.Add(data);
        }

        public T GetBy(Predicate<T> predicate, CancellationToken cancellationToken)
        {
            return _data.Find(predicate);
        }

        public async Task<T> GetById(T1 id, CancellationToken cancellationToken)
        {
            return _data.Find(e => e.Id.Equals(id));
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
        {
            return _data;
        }
    }
}
