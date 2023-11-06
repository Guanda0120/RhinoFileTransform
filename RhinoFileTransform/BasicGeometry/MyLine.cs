using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RhinoFileTransform.BasicGeometry
{
    public class MyLine: MyGeometryBase
    {
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
            //Write Here
            Dictionary<string, object> jsonObject = new Dictionary<string, object> 
            {
                { "From", this.From}, { "To", this.To}, {"LayerIndex", this.LayerIndex}
            };
            return JsonSerializer.Serialize(jsonObject);
        }
    }
}
