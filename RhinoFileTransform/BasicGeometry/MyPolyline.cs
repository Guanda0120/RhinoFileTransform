using System.Text.Json;
using System.Text.Json.Serialization;

namespace RhinoFileTransform.BasicGeometry
{
    [Serializable]
    public class MyPolyline: MyGeometryBase
    {
        // The Object Type
        public new string MyObjectType { get; } = "MyPolyline";
        // The Control Point List
        public MyPoint3d[] ControlPoints { get; set; }
        // The Curve is Closed or not.
        [JsonIgnore]
        public readonly bool IsClosed;

        public MyPolyline(IEnumerable<MyPoint3d> controlPoints, int layerIndex)
            :base(layerIndex) 
        {
            this.ControlPoints = controlPoints.ToArray();
            // Check if the polyline is closed
            if (ControlPoints[0] == ControlPoints[ControlPoints.Length - 1])
            {
                this.IsClosed = true;
            }
            else
            {
                this.IsClosed = false;
            }
        }

        public override string ToJson()
        {
            return JsonSerializer.Serialize<MyPolyline>(this);
        }
    }
    
}
