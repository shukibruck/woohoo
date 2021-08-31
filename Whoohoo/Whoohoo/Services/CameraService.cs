using System;
using System.Collections.Generic;
using Whoohoo.Model;
using Whoohoo.Repository;
using Whoohoo.Services.Interfaces;

namespace Whoohoo.Services
{
    public class CameraService : ICameraService
    {
        private readonly ICameraRepository _cameraRepository;

        public CameraService(ICameraRepository cameraRepository)
        {
            _cameraRepository = cameraRepository;
        }

        public List<CameraModel> GetAll()
        {
            return _cameraRepository.GetAll();
        }

        public List<CameraModel> FindByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            var result = _cameraRepository
                .FindByQuery(cam => 
                    cam.Name
                        .ToLower()
                        .Contains(name.ToLower()
                    ));

            return result;
        }

        public CamerasDividedModel GetDivided()
        {
            var cameras = _cameraRepository.GetAll();
            var result = DivideCameras(cameras);

            return result;
        }

        private static CamerasDividedModel DivideCameras(IEnumerable<CameraModel> cameras)
        {
            var camerasDivided = new CamerasDividedModel();

            foreach (var camera in cameras)
            {
                if (camera.Id == 0)
                {
                    camerasDivided.NotDividedByThreeAndFive.Add(camera);
                }

                if (camera.Id % 3 == 0)
                {
                    camerasDivided.DividedByThree.Add(camera);
                }

                if (camera.Id % 5 == 0)
                {
                    camerasDivided.DividedByFive.Add(camera);
                }

                if (camera.Id % 3 == 0 && camera.Id % 5 == 0)
                {
                    camerasDivided.DividedByThreeAndFive.Add(camera);
                }
                else
                {
                    camerasDivided.NotDividedByThreeAndFive.Add(camera);
                }
            }

            return camerasDivided;
        }
    }
}