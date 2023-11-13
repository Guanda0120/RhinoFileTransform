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
using RhinoFileTransform.MathUtility;

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
            this.ConvertToMatrixForm();
        }

        /// <summary>
        /// For a N_th Degree Bezier Curve. C(t) = Sum(i = 0 to N) (N choose i) * (1 - t)^(N - i) * t^i * P_i
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public MyPoint3d PointAt(double t) 
        {
            Matrix<double> WeightFactor = this.PointWeightMatrix(t);
            Matrix<double> PointMatrix = this._MatrixForm.PointwiseMultiply(WeightFactor);
            Vector<double> PointVector = PointMatrix.ColumnSums();
            return new MyPoint3d(PointVector[0], PointVector[1], PointVector[2], this.LayerIndex);
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

        /// <summary>
        /// Construct a Matrix Form of the Control Points
        /// </summary>
        private void ConvertToMatrixForm()
        {
            // Construct a Container
            double[,] matrix = new double[ControlPoints.Length, 3];
            for (int i = 0; i < ControlPoints.Length; i++)
            {
                matrix[i, 0] = this.ControlPoints[i].X;
                matrix[i, 1] = this.ControlPoints[i].Y;
                matrix[i, 2] = this.ControlPoints[i].Z;
            }
            this._MatrixForm = Matrix<double>.Build.DenseOfArray(matrix);
        }

        private Matrix<double> PointWeightMatrix(double t) 
        {

            double[,] WeightFactor = new double[ControlPoints.Length, 3];

            for (int i = 0; i < ControlPoints.Length; i++)
            {
                double Bu = (FactorialUtl.Factorial(ControlPoints.Length)/(FactorialUtl.Factorial(i+1)* FactorialUtl.Factorial(ControlPoints.Length-i-1)))*(Math.Pow(t, i+1)*Math.Pow(1-t, ControlPoints.Length-i-1));
                WeightFactor[i, 0] = Bu;
                WeightFactor[i, 1] = Bu;
                WeightFactor[i, 2] = Bu;
            }

            return Matrix<double>.Build.DenseOfArray(WeightFactor);
        }
    }
}
