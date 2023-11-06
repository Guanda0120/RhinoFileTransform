
using RhinoFileTransform.BasicGeometry;

class Program 
{
    public static void Main() 
    {
        MyPoint3d fromPoint = new MyPoint3d(0, 0, 0, 1);
        MyPoint3d toPoint = new MyPoint3d(1, 2, 3, 1);
        MyLine myLine = new MyLine(toPoint, fromPoint, 4);
        string jsonString = myLine.ToJson();
        Console.WriteLine(jsonString);
        string filePath = "C:\\Users\\12748\\Desktop\\1.json";
        File.WriteAllText(filePath, jsonString);
        Console.WriteLine("Finish Json");
    }
}
