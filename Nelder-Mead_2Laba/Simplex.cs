using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nelder_Mead_2Laba
{    
    class Simplex
    {
        const double alpha = 1;
        const double gamma = 2;
        const double beta = 0.5;
        const double epsilon = 0.001;

        public Point highValuePoint;
        public Point middleValuePoint;
        public Point lowValuePoint;
        public Point x0Point;
        public Point xrPoint;
        public Point xePoint;
        public Point xcPoint;
        
        public Simplex(Point highValuePoint, Point middleValuePoint, Point lowValuePoint)
        {
            this.highValuePoint = highValuePoint;
            this.middleValuePoint = middleValuePoint;
            this.lowValuePoint = lowValuePoint;
        }

        public void Sort()
        {
            Point[] temp = { highValuePoint, middleValuePoint, lowValuePoint };
            temp = temp.OrderBy(x => SimplexFunc.ObjFunc(x)).ToArray();
            
            lowValuePoint = temp[0];
            middleValuePoint = temp[1];
            highValuePoint = temp[2];
        }

        public void Calculatex0Point()
        {
            x0Point = (middleValuePoint + lowValuePoint) / 2;
        }  
        
        public void CalculateReflectionPoint()
        {
            xrPoint = (1 + alpha) * x0Point - alpha * highValuePoint;
        }

        public void CalculateExpansionPoint()
        {
            xePoint = gamma * xrPoint + (1 - gamma) * x0Point;
        }

        public void CalculateContractionPoint()
        {
            xcPoint = beta * highValuePoint + (1 - beta) * x0Point;
        }

        public void ShrinkSimplex()
        {
            highValuePoint = (highValuePoint + lowValuePoint) / 2;
            middleValuePoint = (middleValuePoint + lowValuePoint) / 2;
        }

        public bool IsSimplexConverges()
        {
            double xSum = (SimplexFunc.ObjFunc(lowValuePoint) + SimplexFunc.ObjFunc(middleValuePoint) +
                SimplexFunc.ObjFunc(highValuePoint)) / 3;

            double tempSum = 0;
            tempSum = Math.Pow(SimplexFunc.ObjFunc(lowValuePoint) - xSum, 2) + 
                Math.Pow(SimplexFunc.ObjFunc(middleValuePoint) - xSum, 2) +
                Math.Pow(SimplexFunc.ObjFunc(highValuePoint) - xSum, 2);

            double S = Math.Sqrt((tempSum) / 3);

            return S < epsilon;
        }
    }
}
