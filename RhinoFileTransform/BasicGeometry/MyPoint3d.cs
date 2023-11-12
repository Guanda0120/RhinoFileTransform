using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace RhinoFileTransform.BasicGeometry
{
    [Serializable]
    public class MyPoint3d: MyGeometryBase, IEquatable<MyPoint3d>
    {
        // The Object Type
        public string MyObjectType { get; } = "MyPoint3d";
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

        public override bool Equals(object? obj) => this.Equals(obj as MyPoint3d);
        
        public bool Equals(MyPoint3d other)
        {
            if (other is null)
                return false;
            if (Object.ReferenceEquals(this, other))
                return true;
            if (this.GetType() != other.GetType())
                return false;
            return this.X == other.X && this.Y == other.Y && this.Z == other.Z;
        }

        public override int GetHashCode() => (this.X,this.Y,this.Z).GetHashCode();

        public static bool operator ==(MyPoint3d left, MyPoint3d right) 
        {
            if (left is null) 
            {
                if (right is null) { return true; }
                return false;
            }
            return left.Equals(right);
        }

        public static bool operator !=(MyPoint3d left, MyPoint3d right) => !(left == right);

        public override string ToJson()
        {
            return JsonSerializer.Serialize<MyPoint3d>(this);
        }

        public Point3d ToRhino() 
        {
            // Return a Point3d
            return new Point3d(this.X, this.Y, this.Z);
        }
    }
}
