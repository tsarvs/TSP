using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSP.Interface;
using TSP.Struct;

namespace TSP.Class
{
    public class DFSProcessor : IDFSProcessor
    {
        #region Properties

        public int[] ShortestPath;

        public double ShortestDist;

        private readonly ITSPReader _fileReader;

        private TreeBuilder _treeProcessor;

        private List<Vertex> _vertices;

        private IPathProcessor _pathProcessor;

        #endregion

        #region Constructors

        public DFSProcessor()
        {
            _fileReader = new TSPReader();

            _vertices = new List<Vertex>();

            _pathProcessor = new PathProcessor();
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

            SearchAndSaveShortestPath();

            stopwatch.Stop();
            var calculationTime = stopwatch.ElapsedMilliseconds;
        }

        private double DepthFirstSearch(Node parentNode, double distance, List<int> path)
        {
            if (parentNode.ChildNodes.Count != 0)
            {
                foreach (var childNode in parentNode.ChildNodes)
                {
                    distance += _pathProcessor.CalculateDistance(parentNode.Vertex, childNode.Vertex);
                    distance = DepthFirstSearch(childNode, distance, path);
                }
            }
            else
            {
                double tempDistance = distance;
                distance = 0;

                //calculate once more to close the path
                //check to see if its the shortest path
                

                return tempDistance;
            }

            return distance;
        }

        private void SearchAndSaveShortestPath()
        {
            double shortestDistance = Double.MaxValue;
            List<int> path = new List<int>();

            double returned = DepthFirstSearch(_treeProcessor.TreeHeadNode, 0, path);

        }
        

        #endregion
    }
}
