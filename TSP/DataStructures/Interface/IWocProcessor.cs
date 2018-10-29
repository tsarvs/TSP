using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSP.Struct;

namespace TSP.Interface
{
    public interface IWocProcessor
    {

        #region Properties

        List<Vertex> OptimizedPath { get; set; }

        int[][] ProportionGrid { get; set; }

        int[][] TranslatedGrid { get; set; }

        #endregion




    }
}
