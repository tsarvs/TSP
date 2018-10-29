using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSP.Interface;
using TSP.Struct;

namespace TSP.Class
{
    class WocProcessor : IWocProcessor
    {
        #region Properties

        public List<Vertex> OptimizedPath { get; set; }

        public int[][] ProportionGrid { get; set; }

        public int[][] TranslatedGrid { get; set; }

        private IGAProcessor _genAlgProcessor;

        

        #endregion

        #region Constructors

        public WocProcessor(string fileName)
        {
            _genAlgProcessor = new GAProcessor(fileName);
            
        }

        #endregion

    }
}
