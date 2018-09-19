using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSP.Struct;

namespace TSP.Interface
{
    interface IEdgeProcessor
    {
        int FindIndexToInsert(Vertex vertexToInsert, List<Vertex> pathList);
    }
}
