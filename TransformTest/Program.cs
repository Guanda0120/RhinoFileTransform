using Rhino.FileIO;
using Rhino.Geometry;
using RhinoFileTransform.BasicGeometry;
using RhinoFileTransform.MathUtility;

class Program 
{
    public static void Main() 
    {
        Console.WriteLine(FactorialUtl.Factorial(5));

        MyPoint3d[] myPoint3Ds = new MyPoint3d[]
        {
            new MyPoint3d(0, 0, 0, 1),
            new MyPoint3d(0, 1, 0, 1),
            new MyPoint3d(1, 1, 0, 1),
            new MyPoint3d(1, 0, 0, 1),
        };

        MyBezierCurve myBezierCurve = new MyBezierCurve(myPoint3Ds, 0);
        MyPoint3d tPoint3D = myBezierCurve.PointAt(0.5);
        Console.WriteLine(tPoint3D.ToJson());
    }
}
