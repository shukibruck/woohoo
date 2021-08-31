using System;
using System.Collections.Generic;
using Whoohoo.Model;

namespace Whoohoo.Repository
{
    public interface ICameraRepository
    {
        List<CameraModel> GetAll();
        List<CameraModel> FindByQuery(Func<CameraModel, bool> predicate);
    }
}