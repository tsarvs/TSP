using System.Collections.Generic;
using System.Diagnostics;
using TSP.Interface;
using TSP.Struct;

namespace TSP.Class
{
    public class TSPProcessor : ITSPProcessor
    {
        #region Properties

        private readonly ITSPReader _fileReader;

        private IPermutationProcessor _permutationProcessor;

        private List<Vertex> _vertices;

        public int[] ShortestPath { get; set; }

        public double ShortestDist { get; set; }

        public long CalculationTime { get; set; }

        #endregion

        #region Constructors

        public TSPProcessor()
        {
            _fileReader = new TSPReader();

            _vertices = new List<Vertex>();
        }

        #endregion

        public void ProcessFile(string fileDir)
        {
            _vertices.Clear();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            _vertices = _fileReader.ReadTSP(fileDir);

            _permutationProcessor = new PermutationProcessor(_vertices);
            _permutationProcessor.Permutation(_vertices.Count);

            stopwatch.Stop();

            CalculationTime = stopwatch.ElapsedMilliseconds;
            ShortestPath = (int[]) _permutationProcessor.ShortestPath.Clone();
            ShortestDist = _permutationProcessor.ShortestDistance;
        }
    }
}