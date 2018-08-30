using System;
using System.Collections.Generic;
using TSP.Interface;
using TSP.Struct;

namespace TSP.Class
{
    public class PermutationProcessor : IPermutationProcessor
    {
        #region Properties

        private readonly IPathProcessor _pathProcessor;

        private readonly List<Vertex> _vertices;

        public int[] ShortestPath { get; set; }

        public double ShortestDistance { get; set; }

        #endregion

        #region Constructor

        public PermutationProcessor(List<Vertex> vertices)
        {
            this._vertices = vertices;

            this._pathProcessor = new PathProcessor();

            this.ShortestDistance = 0;
        }

        #endregion
        
        #region Methods

        private void SwitchVertices(ref int v1, ref int v2)
        {
            //switch two vertices on the list of paths
            if (v1 == v2) return;

            var vTemp = v1;
            v1 = v2;
            v2 = vTemp;
        }

        public void Permutation(int listSize)
        {
            //generate generic path list
            int[] list = GenerateGenericPath(listSize);

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
                //calculate distance
                double pathDistance = _pathProcessor.Process(list, _vertices);

                //save shortest path
                if (this.ShortestPath == null)
                {
                    this.ShortestDistance = pathDistance;
                    this.ShortestPath = (int[])list.Clone();
                }
                else if (this.ShortestDistance > pathDistance)
                {
                    this.ShortestDistance = pathDistance;
                    this.ShortestPath = (int[])list.Clone();
                }
            }
        }

        private int[] GenerateGenericPath(int size)
        {
            //based on the size given as an input, it will generate a generic list path
            //ex: size =5; int[] genericList = {1, 2, 3, 4, 5}

            //This list will be used to generate the other permutations and run calculations
            //on all of the possible paths

            int[] genericList = new int[size];

            for(int i = 0; i < genericList.Length; i++)
            {
                genericList[i] = i+1;
            }

            return genericList;
        }

        #endregion
    }
}