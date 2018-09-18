using System;
using System.Collections.Generic;
using System.Diagnostics;
using TSP.Interface;
using TSP.Struct;

namespace TSP.Class
{
    public class DFSProcessor : IDFSProcessor
    {
        #region Properties

        public int[] ShortestPath { get; set; }

        public double ShortestDist { get; set; }

        public long CalculationTime { get; set; }

        private readonly ITSPReader _fileReader;

        private TreeBuilder _treeProcessor;

        private List<Vertex> _vertices;

        private readonly IPathProcessor _pathProcessor;

        #endregion

        #region Constructors

        public DFSProcessor()
        {
            _fileReader = new TSPReader();

            _vertices = new List<Vertex>();

            _pathProcessor = new PathProcessor();

            ShortestDist = Double.MaxValue;
        }

        #endregion

        #region Methods

        public void ProcessFile(byte[] file)
        {
            _vertices.Clear();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            _vertices = _fileReader.ReadTSP("TSPFile/11PointDFSBFS.tsp");
            _treeProcessor = new TreeBuilder(_vertices);
            DepthFirstSearch(_treeProcessor.TreeHeadNode, new List<int>());

            stopwatch.Stop();
            CalculationTime = stopwatch.ElapsedMilliseconds;
        }

        private void DepthFirstSearch(Node parentNode, List<int> path)
        {
            List<int> localPath = path;

            if (parentNode != null)
            {
                //look for all possible children
                foreach (var childNode in parentNode.ChildNodes)
                {
                    DepthFirstSearch(childNode, localPath);
                }
            }
            else
            {
                //now that I have a full path, process it and see if its the shortest path
                double distance = _pathProcessor.Process(localPath.ToArray(), _vertices);

                UpdateShortestPath(localPath.ToArray(), distance);

                return;
            }
            
        }

        //input = vertex
        //outpuut = index of said vertex in _vertices array
        private int GetVertexIndex(Vertex searchVertex)
        {
            var i = 1;

            foreach (var vertex in _vertices)
            {
                if (searchVertex.Equals(vertex))
                    break;

                i++;
            }

            return i;
        }

        //check to see if param distance is the shortest distance
        private void UpdateShortestPath(int[] path, double distance)
        {
            if (distance < ShortestDist)
            {
                ShortestDist = distance;
                ShortestPath = path;
            }
        }

        #endregion
    }
}