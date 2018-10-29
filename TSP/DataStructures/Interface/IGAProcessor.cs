using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSP.Struct;

namespace TSP.Interface
{
    public interface IGAProcessor
    {
        List<List<Vertex>> ParentGenerationList { get; set; }

        List<int> FitnessList { get; set; }

        void RunGA1A(int iterations);
        void RunGA1B(int iterations);
        void RunGA2A(int iterations);
        void RunGA2B(int iterations);
    }
}
