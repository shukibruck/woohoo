using System.Collections.Generic;
using Whoohoo.Model;

namespace Whoohoo.Services.Interfaces
{
    public interface ICameraService
    {
        List<CameraModel> FindByName(string name);
        List<CameraModel> GetAll();
        CamerasDividedModel GetDivided();
    }
}