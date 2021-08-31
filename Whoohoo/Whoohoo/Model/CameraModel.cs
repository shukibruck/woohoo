using CsvHelper.Configuration.Attributes;

namespace Whoohoo.Model
{
    public class CameraModel
    {
        [Ignore]
        public int Id { get; set; }

        [Name("Camera")]
        public string Name { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}