using System;
using System.Collections.Generic;
using Whoohoo.Model;

namespace Whoohoo.Helpers
{
    public static class PrintHelper
    {
        private const string LineSeparator = "--------------------------------------";

        public static void PrintCameras(IEnumerable<CameraModel> cameraModels)
        {
            if (cameraModels == null)
            {
                throw new ArgumentNullException(nameof(cameraModels));
            }

            foreach (var cameraModel in cameraModels)
            {
                PrintCamera(cameraModel);
            }

            Console.WriteLine(LineSeparator);
        }

        public static void PrintCamera(CameraModel cameraModel)
        {
            if (cameraModel == null)
            {
                throw new ArgumentNullException(nameof(cameraModel));
            }

            Console.WriteLine($"{cameraModel.Id} | {cameraModel.Name} | {cameraModel.Latitude} | {cameraModel.Longitude}");
        }

        public static void PrintError(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentNullException(nameof(errorMessage));
            }

            Console.WriteLine(LineSeparator);
            Console.WriteLine($"---- {errorMessage} ----");
            Console.WriteLine(LineSeparator);
        }
    }
}
