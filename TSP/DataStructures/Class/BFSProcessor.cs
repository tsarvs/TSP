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
    public class BFSProcessor : IBFSProcessor
    {
        #region Properties

        private readonly ITSPReader _fileReader;

        private TreeBuilder _treeProcessor;

        private List<Vertex> _vertices;

        #endregion

        #region Constructor

        public BFSProcessor()
        {
            _fileReader = new TSPReader();
            
            _vertices = new List<Vertex>();
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

            BreadthFirstSearch();

            stopwatch.Stop();
            var calculationTime = stopwatch.ElapsedMilliseconds;
        }

        private void BreadthFirstSearch()
        {

        }

        #endregion
    }
}
