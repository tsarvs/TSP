using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSP.Struct;

namespace TSP.Interface
{
    public interface IPathProcessor
    {
        double Process(int[] pathArray, List<Vertex> vertices);

        double Process(List<Vertex> pathList);

        double CalculateDistance(Vertex pointA, Vertex pointB);
    }
}
