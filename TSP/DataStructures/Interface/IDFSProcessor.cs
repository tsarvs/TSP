﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP.Interface
{
    public interface IDFSProcessor
    {
        int[] ShortestPath { get; set; }

        double ShortestDist { get; set; }

        long CalculationTime { get; set; }

        void ProcessFile(byte[] file);
    }
}
