using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Whoohoo.Model;
using Whoohoo.Repository.RepositoryContext;
using Whoohoo.Services.Interfaces;

namespace Whoohoo.Repository
{
    public class CameraRepository : CsvContext<CameraModel>, ICameraRepository
    {
        private readonly ICameraIdService _cameraIdService;

        public CameraRepository(
            IConfiguration configuration,
            ICameraIdService cameraIdService)
            : base(configuration["CameraCsvFilePath"])
        {
            _cameraIdService = cameraIdService;
            SetCamerasId();
        }

        public List<CameraModel> GetAll()
        {
            return DataSet.ToList();
        }

        public List<CameraModel> FindByQuery(Func<CameraModel, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return DataSet
                .Where(predicate)
                .ToList();
        }

        private void SetCamerasId()
        {
            DataSet = _cameraIdService.SetCamerasId(DataSet?.ToList());
        }
    }
}