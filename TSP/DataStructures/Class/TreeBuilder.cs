using System.Collections.Generic;
using TSP.Struct;

namespace TSP.Class
{
    internal class TreeBuilder : PermutationProcessor
    {
        #region Properties

        public Node TreeHeadNode;

        private readonly List<Vertex> vertices;

        #endregion

        #region Constructors

        public TreeBuilder(List<Vertex> vertices) : base(vertices)
        {
            this.vertices = vertices;

            if (this.vertices.Count != 0)
            {
                TreeHeadNode = new Node(vertices[0]);

                //run permutations and build tree
                Permutation(vertices.Count);
            }
        }

        #endregion

        #region Methods

        private new void Permutation(int listSize)
        {
            //generate generic path list
            var list = GenerateGenericPath(listSize);

            //start the real permutation loop
            Permutation(list, 0, list.Length - 1);
        }

        private void Permutation(int[] list, int depthRecursion, int depthMax)
        {
            if (depthRecursion != depthMax)
            {
                var i = depthRecursion;

                for (; i <= depthMax; i++)
                {
                    SwitchVertices(ref list[depthRecursion], ref list[i]);

                    Permutation(list, depthRecursion + 1, depthMax);

                    SwitchVertices(ref list[depthRecursion], ref list[i]);
                }
            }
            else
            {
                //build branch with path given
                AddBranch(list);
            }
        }

        private int[] GenerateGenericPath(int size)
        {
            //based on the size given as an input, it will generate a generic list path
            //ex: size =5; int[] genericList = {2, 3, 4, 5}

            //This list will be used to generate the other permutations of all possible branches
            //branches[] = headNode + Permutations(1:n) + headNode

            var genericList = new int[size - 1];

            for (var i = 0; i < genericList.Length; i++) genericList[i] = i + 2;

            return genericList;
        }

        private void AddBranch(int[] path)
        {
            bool isNewVertex;
            var tempNode = TreeHeadNode;

            //1 step through each vertex in path = 1 step through tree
            foreach (var vertex in path)
            {
                isNewVertex = true;

                //search through tempNode's children to see if that path already exists
                //if there is a match, then iterate tempNode to that child, set isNewVertex to false
                //if not a match, set isNewVertex = true
                foreach (var child in tempNode.ChildNodes)
                    if (child.Vertex.Equals(vertices[vertex - 1]))
                    {
                        tempNode = child;
                        isNewVertex = false;
                        break;
                    }

                //if the vertex is not a child node, add it to the child list and set the 
                //tempNode to the added node
                if (isNewVertex)
                {
                    var addedNode = new Node(vertices[vertex - 1]);
                    addedNode.ParentNode = tempNode;

                    tempNode.ChildNodes.Add(addedNode);

                    tempNode = addedNode;
                }
            }
        }
    }

    #endregion
}