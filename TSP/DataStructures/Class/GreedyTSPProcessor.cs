using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSP.Interface;
using TSP.Struct;

namespace TSP.Class
{
    public class GreedyTSPProcessor : IGreedyTSPProcessor
    {
        #region Properties

        private ITSPReader _fileReader;

        private IEdgeProcessor _edgeProcessor;

        private List<Vertex> _vertices;

        #endregion

        #region Constructor

        public GreedyTSPProcessor(string filename)
        {
            _fileReader = new TSPReader();

            _edgeProcessor = new EdgeProcessor();

            _vertices = _fileReader.ReadTSP(filename);
        }

        #endregion

        public List<Vertex> BuildPath()
        {
            if (_vertices.Count <= 2) return null;

            List<Vertex> pathList = new List<Vertex>();

            foreach (var vertex in _vertices)
            {
                //add the first two vertices to pathList
                if (pathList.Count < 2)
                {
                    pathList.Add(vertex);
                }
                else
                {
                    var index = _edgeProcessor.FindIndexToInsert(vertex, pathList);

                    if (index == pathList.Count)
                    {
                        pathList.Add(vertex);
                    }
                    else
                    {
                        pathList.Insert(index + 1, vertex);
                    }
                    
                }
            }

            return pathList;
        }
        
    }
}
