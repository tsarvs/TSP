using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TSP.Struct;

namespace TSP.Class
{
    class Node
    {
        #region Properties

        public Vertex Vertex;

        public List<Node> ChildNodes;

        public Node ParentNode;

        #endregion

        #region Constructor

        public Node(Vertex v)
        {
            Vertex = v;

            ChildNodes = new List<Node>();

            ParentNode = null;
        }

        #endregion

        #region Methods

        public int[] NodePathListToArray(List<Node> nodes, List<Vertex> vertices)
        {
            List<int> pathInts = new List<int>();

            foreach (var node in nodes)
            {
                int i = 1;
                //search through vertex list to find index of node
                foreach (var vertex in vertices)
                {
                    if (vertex.Equals(node.Vertex))
                    {
                       pathInts.Add(i);
                       break;
                    }

                    i++;
                }
            }

            return pathInts.ToArray();
        }

        public List<Node> GetPath()
        {
            List<Node> pathList = new List<Node>();
            pathList.Add(this);

            if (ParentNode != null)
            {
                pathList = ParentNode.GetPath(pathList);
            }

            return pathList;
        }

        private List<Node> GetPath(List<Node> currentPath)
        {
            currentPath.Add(this);

            if (ParentNode != null)
            {
                ParentNode.GetPath(currentPath);
            }

            return currentPath;
        }
        
#endregion
    }
}
