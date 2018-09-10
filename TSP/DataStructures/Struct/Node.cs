using System.Collections.Generic;

namespace TSP.Struct
{
    public struct Node
    {
        public Vertex Vertex;
        public List<Node> ChildNodes;
    }

}
