using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utils.Entities
{
    public interface IEntityIdentifier<T2>
    {
        public T2 Id { get; set; }
    }
}
