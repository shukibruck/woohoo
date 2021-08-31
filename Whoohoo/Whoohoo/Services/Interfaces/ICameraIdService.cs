using System.Collections.Generic;
using Whoohoo.Model;

namespace Whoohoo.Services.Interfaces
{
    public interface ICameraIdService
    {
        IList<CameraModel> SetCamerasId(IList<CameraModel> cameras);
    }
}