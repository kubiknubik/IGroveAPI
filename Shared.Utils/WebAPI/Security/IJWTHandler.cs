using System.Collections.Generic;
using System.Security.Claims;

namespace Shared.Utils.WebAPI.Security
{
    public interface IJWTHandler
    {
        string Create(params Claim[] claims);

        string Create(List<Claim> claims);
    }
}
