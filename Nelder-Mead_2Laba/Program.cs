using System;

namespace Nelder_Mead_2Laba
{
    class Program
    {
        static void Main(string[] args)
        {
            Simplex simplex = new Simplex(new Point(180, 20), new Point(50, -20), new Point(-90, 81));

            int counter = 0;
            while (true)
            {
                counter++;

                simplex.Sort();
                simplex.Calculatex0Point();
                simplex.CalculateReflectionPoint();

                //Левое крыло блок-схемы
                if (SimplexFunc.ObjFunc(simplex.xrPoint) < SimplexFunc.ObjFunc(simplex.lowValuePoint))
                {
                    simplex.CalculateExpansionPoint();
                    
                    if (SimplexFunc.ObjFunc(simplex.xePoint) < SimplexFunc.ObjFunc(simplex.lowValuePoint))
                        simplex.highValuePoint = simplex.xePoint;
                    else simplex.highValuePoint = simplex.xrPoint;
                }
                //Центральная часть блок-схемы  
                else if (SimplexFunc.ObjFunc(simplex.xrPoint) < SimplexFunc.ObjFunc(simplex.middleValuePoint))
                {
                    simplex.highValuePoint = simplex.xrPoint;
                }
                //Правое крыло блок-схемы
                else
                {
                    if (SimplexFunc.ObjFunc(simplex.xrPoint) < SimplexFunc.ObjFunc(simplex.highValuePoint))
                        simplex.highValuePoint = simplex.xrPoint;

                    simplex.CalculateContractionPoint();

                    if (SimplexFunc.ObjFunc(simplex.xcPoint) < SimplexFunc.ObjFunc(simplex.highValuePoint))
                        simplex.highValuePoint = simplex.xcPoint;
                    else simplex.ShrinkSimplex();
                }
                if (simplex.IsSimplexConverges()) break;
            }

            Console.WriteLine("{" + simplex.lowValuePoint + "} " + SimplexFunc.ObjFunc(simplex.lowValuePoint));
            Console.WriteLine(counter);
        }
    }
}
