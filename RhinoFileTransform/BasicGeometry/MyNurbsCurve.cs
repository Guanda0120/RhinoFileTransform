using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Transactions;

namespace RhinoFileTransform.BasicGeometry
{
    [Serializable]
    public class MyNurbsCurve: MyGeometryBase
    {
        // The Object Type
        public new string MyObjectType { get; } = "NurbCurve";
        // The Control Point List
        public MyPoint3d[] ControlPoints { get; set; }
        // The Curve Degree
        public int Degree { get; set; }

        [JsonIgnore]
        public readonly bool IsClosed;

        /// <summary>
        /// A Constructor of NurbsCurve
        /// </summary>
        /// <param name="controlPoints"> A list of MyPoint3d </param>
        /// <param name="degree"> The Degree of the nurbs curve </param>
        /// <param name="layerIndex"> The  </param>
        public MyNurbsCurve(IEnumerable<MyPoint3d> controlPoints, int degree, int layerIndex)
            :base(layerIndex)
        {
            this.ControlPoints = controlPoints.ToArray();
            this.Degree = degree;
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

        /// <summary>
        /// This is the point at the specified parameter along the curve.
        /// </summary>
        /// <param name="t"> t blongs to [0,1] domain </param>
        /// <returns> MyPoint3d that at t </returns>
        public void PointAt(double t) 
        {
            
        }

        public NurbsCurve ToRhino()
        {
            List<Point3d> controlPoints = new List<Point3d>();
            foreach (MyPoint3d myPoint3d in this.ControlPoints)
            {
                controlPoints.Add(myPoint3d.ToRhino());
            }
            NurbsCurve nurbsCurve = NurbsCurve.Create(false, this.Degree, controlPoints);
            return nurbsCurve;
        }

        public override string ToJson()
        {
            return JsonSerializer.Serialize<MyNurbsCurve>(this);
        }
    }
}
