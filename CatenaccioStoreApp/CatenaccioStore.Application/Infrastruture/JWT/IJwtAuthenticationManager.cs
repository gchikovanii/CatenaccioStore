using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenaccioStore.Application.Infrastruture.JWT
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(bool status, string email, List<string> roles);
    }
}
