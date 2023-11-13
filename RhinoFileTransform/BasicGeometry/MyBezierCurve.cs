using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace RhinoFileTransform.BasicGeometry
{
    /// <summary>
    /// The Bezier Curve is a Generialized Curve Type. 
    /// The B
    /// </summary>
    [Serializable]
    public class MyBezierCurve: MyGeometryBase
    {
        // The Object Type
        public new string MyObjectType { get; } = "MyBezierCurve";
        // The Control Point List
        public MyPoint3d[] ControlPoints { get; set; }
        // The Curve is Closed or not
        [JsonIgnore]
        public readonly bool IsClosed;
        // Convert The Point into Matrix Form
        private Matrix<double> _MatrixForm { get; set; }

        public MyBezierCurve(IEnumerable<MyPoint3d> controlPoints, int layerIndex)
            :base(layerIndex) 
        {
            this.ControlPoints = controlPoints.ToArray();
            // Check Closed or Not
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
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public MyPoint3d PointAt(double t) 
        {
            
        }

        public override string ToJson()
        {
            return JsonSerializer.Serialize<MyBezierCurve>(this);
        }

        /// <summary>
        /// Convert to Rhino Bezier Curve.
        /// </summary>
        /// <returns> The Rhino Bezier Curve </returns>
        public BezierCurve ToRhino() 
        {
            // Construct a Container
            Point3d[] point3Ds = new Point3d[ControlPoints.Length];
            for(int i = 0; i < point3Ds.Length; i++) 
            {
                point3Ds[i] = this.ControlPoints[i].ToRhino(); 
            }

            return new BezierCurve(point3Ds);
        }
    }
}
