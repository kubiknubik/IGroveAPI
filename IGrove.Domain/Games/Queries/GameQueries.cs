using IGrove.Domain.Games.Entities;
using Shared.Utils.Queries;
using System.Collections.Generic;

namespace IGrove.Domain.Games.Queries
{
    public class GetGameByIdQuery : QueryBase<Game>
    {
        public int Id { get; set; }
    }

    public class GetAllGameQuery : QueryBase<IEnumerable<Game>>
    {

    }
}
