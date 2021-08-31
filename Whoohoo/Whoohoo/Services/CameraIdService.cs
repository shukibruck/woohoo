using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Whoohoo.Helpers;
using Whoohoo.Model;
using Whoohoo.Services.Interfaces;

namespace Whoohoo.Services
{
    public class CameraIdService : ICameraIdService
    {
        public IList<CameraModel> SetCamerasId(IList<CameraModel> cameras)
        {
            if (cameras == null)
            {
                throw new ArgumentNullException(nameof(cameras));
            }

            var modelRegex = new Regex(@"UTR-CM-\d+");
            var idRegex = new Regex(@"\d+");

            for (var index = 0; index < cameras.Count; index++)
            {
                var camera = cameras[index];
                var model = modelRegex.Match(camera.Name);
                var idStr = idRegex.Match(model.Value);

                if (!int.TryParse(idStr.Value, out var id))
                {
                    PrintHelper.PrintError($"Error can't get id from camera: {camera.Name}");
                    cameras.Remove(camera);
                    index -= 1;

                    continue;
                }

                camera.Id = id;
            }

            return cameras;
        }
    }
}
