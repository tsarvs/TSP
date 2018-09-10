using System.Collections.Generic;
using System.Diagnostics;
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

        private readonly IPathProcessor _pathProcessor;

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
            DepthFirstSearch(_treeProcessor.TreeHeadNode, new List<int>());

            stopwatch.Stop();
            var calculationTime = stopwatch.ElapsedMilliseconds;
        }

        private void DepthFirstSearch(Node parentNode, List<int> path)
        {
            if (parentNode.ChildNodes.Count != 0)
                foreach (var childNode in parentNode.ChildNodes)
                {
                    path.Add(GetVertexIndex(parentNode.Vertex));

                    DepthFirstSearch(childNode, path);
                }
            else
                _pathProcessor.Process(path.ToArray(), _vertices);
        }

        private int GetVertexIndex(Vertex searchVertex) 
        {
            var i = 0;

            do
            {
                i++;
            } while (!_vertices[i].Equals(searchVertex) && i < _vertices.Count - 1);

            return i;
        }

        #endregion
    }
}