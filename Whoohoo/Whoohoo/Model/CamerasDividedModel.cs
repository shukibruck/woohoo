using System.Collections.Generic;

namespace Whoohoo.Model
{
    public class CamerasDividedModel
    {
        public CamerasDividedModel()
        {
            DividedByThree = new List<CameraModel>();
            DividedByFive = new List<CameraModel>();
            DividedByThreeAndFive = new List<CameraModel>();
            NotDividedByThreeAndFive = new List<CameraModel>();
        }

        public List<CameraModel> DividedByThree { get; set; }

        public List<CameraModel> DividedByFive { get; set; }

        public List<CameraModel> DividedByThreeAndFive { get; set; }

        public List<CameraModel> NotDividedByThreeAndFive { get; set; }
    }
}