using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSP.Interface;
using TSP.Struct;

namespace TSP.Class
{
    class PathProcessor : IPathProcessor
    {
        #region Properties
        #endregion 

        #region Methods
        public double Process(int[] pathArray, List<Vertex> vertices)
        {
            double distance = 0;

            if (pathArray.Length == 0 || pathArray.Length == 1)
            {
                return distance;
            }

            int i;
            for (i = 0; i < pathArray.Length - 1; i++)
            {
                distance += CalculateDistance(vertices[pathArray[i] - 1], vertices[pathArray[i + 1] - 1]);
            }
            
            //finish path loop and calculate distance from last point back to the first
            distance += CalculateDistance(vertices[pathArray[i] - 1], vertices[pathArray[0] - 1]);
            

            return distance;
        }

        public double CalculateDistance(Vertex pointA, Vertex pointB)
        {
            double distance = 0;

            distance = Math.Sqrt(
                            Math.Pow((pointB.x - pointA.x), 2)
                          + Math.Pow((pointB.y - pointA.y), 2)
                                );

            return distance;
        }
        #endregion
    }
}
