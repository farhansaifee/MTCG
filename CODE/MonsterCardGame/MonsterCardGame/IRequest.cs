using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame
{
    public interface IRequest
    {

        string Method { get; }

        string Url { get; }

        string Version { get; }

        string ContentStr { get; }

        Dictionary<string, string> RequestBody { get; }

    }
}
