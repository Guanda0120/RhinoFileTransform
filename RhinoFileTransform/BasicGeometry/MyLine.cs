using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Rhino;
using Rhino.Geometry;

namespace RhinoFileTransform.BasicGeometry
{
    [Serializable]
    public class MyLine: MyGeometryBase
    {
        // The Object Type
        public string MyObjectType { get; } = "MyLine";
        // Start point of line segment.
        public MyPoint3d From {  get; set; }
        // End point of line segment.
        public MyPoint3d To { get; set; }

        // Constructs a new line segment between two points.
        public MyLine(MyPoint3d from, MyPoint3d to, int layerIndex)
            :base(layerIndex)
        {
            this.From = from;
            this.From.SetLayerIndex(layerIndex);
            this.To = to;
            this.To.SetLayerIndex(layerIndex);
        }

        public override string ToJson()
        {
            return JsonSerializer.Serialize<MyLine>(this);
        }

        
    }
}
