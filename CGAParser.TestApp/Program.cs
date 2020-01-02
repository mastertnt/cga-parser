using System;
using System.IO;
using CGACompute;
using SharpDX;

namespace CGAParser.TestApp
{
    class Program
    {
        static void Main(string[] pArgs)
        {
            if (pArgs.Length == 2 && pArgs[0] == "compute")
            {
                Console.WriteLine("Try parse on " + pArgs[1]);
                Compiler lCompiler = new Compiler();
                Context lContext =  new Context();

                Polygon lPolygon = new Polygon();
                lPolygon.Vertices.Add(new Vector3(-2, 0, -2));
                lPolygon.Vertices.Add(new Vector3(2, 0, -2));
                lPolygon.Vertices.Add(new Vector3(2, 0, 2));
                lPolygon.Vertices.Add(new Vector3(-2, 0, 2));
                lPolygon.Normal = Vector3.Up;

                lContext.SetVariable("Lot", lPolygon);
                
                lCompiler.Compile(new FileInfo(pArgs[1]), lContext, new FileInfo("."));
            }
            else if (pArgs.Length == 1)
            {
                Console.WriteLine("Try parse on " + pArgs[0]);
                Compiler lCompiler = new Compiler();
                Context lContext =  new Context();

                Polygon lPolygon = new Polygon();
                lPolygon.Vertices.Add(new Vector3(-2, 0, -2));
                lPolygon.Vertices.Add(new Vector3(2, 0, -2));
                lPolygon.Vertices.Add(new Vector3(2, 0, 2));
                lPolygon.Vertices.Add(new Vector3(-2, 0, 2));
                lPolygon.Normal = Vector3.Up;

                lContext.SetVariable("Lot", lPolygon);
                lCompiler.Compile(new FileInfo(pArgs[0]), lContext, new FileInfo("."));
            }
            else
            {
                Console.WriteLine("Try parse on SampleFile.txt");
                Compiler lCompiler = new Compiler();
                lCompiler.Compile(new FileInfo("SampleFile.txt"), new Context(), new FileInfo(""));
            }
        }
    }
}
