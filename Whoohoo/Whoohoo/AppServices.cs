using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Whoohoo.Helpers;
using Whoohoo.Services.Interfaces;

namespace Whoohoo
{
    public static class AppServices
    {
        public static void UseCLICameraSearchService(
            this IApplicationBuilder applicationBuilder,
            IConfiguration configuration,
            ICameraService cameraService)
        {
            var cameraName = configuration.GetValue<string>("name");

            switch (cameraName)
            {
                case null:
                    Console.WriteLine("No search parameters");

                    return;
                case "":
                    PrintHelper.PrintError("Parameter 'Name' can not be empty");
                    Process.GetCurrentProcess().Kill();

                    break;
            }

            var result = cameraService.FindByName(cameraName);

            if (!result.Any())
            {
                PrintHelper.PrintError($"Can not find cameras with name: '{cameraName}'");
            }

            PrintHelper.PrintCameras(result);
            Process.GetCurrentProcess().Kill();
        }
    }
}