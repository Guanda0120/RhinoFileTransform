using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RhinoFileTransform.BasicGeometry
{
    public class MyPoint3d: MyGeometryBase
    {
        // X Coordinate of the Point
        public double X { get; set; }
        // Y Coordinate of the Point
        public double Y { get; set; }
        // Z Coordinate of the Point
        public double Z { get; set; }

        public MyPoint3d(double x, double y, double z, int layerIndex)
            :base(layerIndex) 
        {
            this.X = x; this.Y = y; this.Z = z;
        }

        public override string ToJson()
        {
            Dictionary<string, object> jsonObject = new Dictionary<string, object>
            {
                {"X", this.X}, { "Y", this.Y}, { "Z", this.Z}, {"LayerIndex", this.LayerIndex }
            };

            return JsonSerializer.Serialize(jsonObject);
        }
    }
}
