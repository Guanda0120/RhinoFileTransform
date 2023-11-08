using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RhinoFileTransform.BasicGeometry
{
    [Serializable]
    public class MyPolyline: MyGeometryBase
    {
        public List<MyPoint3d> ControlPoint { get; set; }

        public MyPolyline(List<MyPoint3d> controlPoint, int layerIndex)
            :base(layerIndex) 
        {
            this.ControlPoint = controlPoint;
        }

        public override string ToJson()
        {
            return JsonSerializer.Serialize<MyPolyline>(this);
        }
    }
    
}
