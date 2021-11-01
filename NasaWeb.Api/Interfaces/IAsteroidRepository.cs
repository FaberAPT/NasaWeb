using NasaWeb.Api.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace NasaWeb.Api.Interfaces
{
    public interface IAsteroidRepository
    {
        Task<IEnumerable<Asteroids>> GetAsteroids(string planeta);
    }
}
