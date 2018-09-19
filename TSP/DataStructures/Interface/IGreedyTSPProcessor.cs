using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSP.Struct;

namespace TSP.Interface
{
    public interface IGreedyTSPProcessor
    {
        #region Mathods

        List<Vertex> BuildPath();

        #endregion
    }
}
