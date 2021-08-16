using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EveryBodyCodes.Interfaces
{
    public interface ICameraBs
    {
        Task<List<EntityCamera>> GetCamerasByNameAsync(string Name);
    }

}
