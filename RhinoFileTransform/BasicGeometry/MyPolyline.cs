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
        public List<MyPoint3d> ControlPoints { get; set; }
        // Simplyfiy is 
        [JsonIgnore]
        public readonly bool IsClosed;

        public MyPolyline(List<MyPoint3d> controlPoints, int layerIndex)
            :base(layerIndex) 
        {
            this.ControlPoints = controlPoints;
            // Check if the polyline is closed
            if (ControlPoints[0] == ControlPoints[ControlPoints.Count - 1])
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
