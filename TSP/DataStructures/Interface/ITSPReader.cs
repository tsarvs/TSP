using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSP.Struct;

namespace TSP.Interface
{
    public interface ITSPReader
    {

        List<Vertex> ReadTSP(string fileDir);

    }
}
