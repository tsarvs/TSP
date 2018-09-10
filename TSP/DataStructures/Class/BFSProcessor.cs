using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TSP.Interface;
using TSP.Struct;

namespace TSP.Class
{
    public class BFSProcessor : IBFSProcessor
    {
        #region Properties

        private readonly ITSPReader _fileReader;

        private TreeBuilder _treeProcessor;

        private List<Vertex> _vertices;

        private IPathProcessor _pathProcessor;

        public double ShortestDistance { get; set; }

        public int[] ShortestPath { get; set; }

        public long CalculationTime { get; set; }

        #endregion

        #region Constructor

        public BFSProcessor()
        {
            _fileReader = new TSPReader();
            
            _vertices = new List<Vertex>();

            _pathProcessor = new PathProcessor();

            ShortestDistance = double.MaxValue;
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

            BreadthFirstSearch(_treeProcessor.TreeHeadNode);

            stopwatch.Stop();
            CalculationTime = stopwatch.ElapsedMilliseconds;
        }

        private void BreadthFirstSearch(Node headNode)
        {
            Queue<Node> nodeQueue = new Queue<Node>();

            nodeQueue.Enqueue(headNode);

            while (nodeQueue.Count > 0)
            {
                Node tempNode = nodeQueue.Dequeue();

                if (tempNode.ChildNodes.Count != 0)
                {
                    foreach (var childNode in tempNode.ChildNodes)
                    {
                        nodeQueue.Enqueue(childNode);
                    }
                }
                else
                {
                    int[] pathInts = tempNode.NodePathListToArray(tempNode.GetPath(), _vertices);
                    double distance = _pathProcessor.Process(pathInts, _vertices);

                    UpdateShortestPath(pathInts, distance);
                }

            }
        }

        private void UpdateShortestPath(int[] path, double distance)
        {
            if (distance < ShortestDistance)
            {
                ShortestDistance = distance;
                ShortestPath = path;
            }
        }

        #endregion
    }
}
