using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TSP.Interface;
using TSP.Class;
using TSP.Struct;

namespace TSPConsole
{
    public partial class TSPGUI : Form
    {
        #region Properties

        private ITSPReader _fileReader;

        private IGAProcessor _geneticAlgorithmProcessor;

        private IPathProcessor _pathProcessor;

        private List<Vertex> _vertices;

        private const int Iterations = 20;
        
        
        #endregion

        public TSPGUI()
        {
            InitializeComponent();

            _fileReader = new TSPReader();
            _vertices = new List<Vertex>();
            _pathProcessor = new PathProcessor();

            chrtMain.ChartAreas[0].AxisX.Minimum = 0;
            chrtMain.ChartAreas[0].AxisY.Minimum = 0;
        }

        private void random100tspToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _geneticAlgorithmProcessor = new GAProcessor("TSPFile/Random100.tsp");
            _vertices.Clear();
            
            if (chrtMain.Series.IndexOf("Random100") == -1)
            {
                chrtMain.Series.Add("Random100");
                chrtMain.Series["Random100"].ChartType = SeriesChartType.Point;

                _vertices = _fileReader.ReadTSP("TSPFile/Random100.tsp");

                foreach (var vertex in _vertices)
                {
                    chrtMain.Series["Random100"].Points.AddXY(vertex.x, vertex.y);
                }
            }

            chrtMain.Series["Random100"].ChartArea = "ChartArea1";
            
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double av0, av1, av2, av3, av4;
            
            for (int i = 0; i<=4; i++)
            {
                _geneticAlgorithmProcessor.RunGA1A(Iterations);
                double distance0 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[0]);
                double distance1 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[1]);
                double distance2 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[2]);
                double distance3 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[3]);
                double distance4 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[4]);
                double distance5 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[5]);
                double distance6 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[6]);
                double distance7 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[7]);
                double distance8 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[8]);
                double distance9 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[9]);

                switch (i)
                {
                    case (0):
                        av0 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                    case (1):
                        av1 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                    case (2):
                        av2 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                                 distance7 + distance8 + distance9) / 10;
                        break;
                    case (3):
                        av3 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                    case (4):
                        av4 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                }
            }
            
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double av0, av1, av2, av3, av4;

            for (int i = 0; i <= 4; i++)
            {
                _geneticAlgorithmProcessor.RunGA1B(Iterations);
                double distance0 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[0]);
                double distance1 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[1]);
                double distance2 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[2]);
                double distance3 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[3]);
                double distance4 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[4]);
                double distance5 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[5]);
                double distance6 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[6]);
                double distance7 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[7]);
                double distance8 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[8]);
                double distance9 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[9]);

                switch (i)
                {
                    case (0):
                        av0 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                    case (1):
                        av1 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                    case (2):
                        av2 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                                 distance7 + distance8 + distance9) / 10;
                        break;
                    case (3):
                        av3 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                    case (4):
                        av4 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                }
            }
        }

        private void aToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            double av0, av1, av2, av3, av4;

            for (int i = 0; i <= 4; i++)
            {
                _geneticAlgorithmProcessor.RunGA2A(Iterations);
                double distance0 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[0]);
                double distance1 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[1]);
                double distance2 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[2]);
                double distance3 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[3]);
                double distance4 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[4]);
                double distance5 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[5]);
                double distance6 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[6]);
                double distance7 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[7]);
                double distance8 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[8]);
                double distance9 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[9]);

                switch (i)
                {
                    case (0):
                        av0 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                    case (1):
                        av1 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                    case (2):
                        av2 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                                 distance7 + distance8 + distance9) / 10;
                        break;
                    case (3):
                        av3 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                    case (4):
                        av4 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                }
            }
        }

        private void bToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            double av0, av1, av2, av3, av4;

            for (int i = 0; i <= 4; i++)
            {
                _geneticAlgorithmProcessor.RunGA2B(Iterations);
                double distance0 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[0]);
                double distance1 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[1]);
                double distance2 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[2]);
                double distance3 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[3]);
                double distance4 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[4]);
                double distance5 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[5]);
                double distance6 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[6]);
                double distance7 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[7]);
                double distance8 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[8]);
                double distance9 = _pathProcessor.Process(_geneticAlgorithmProcessor.ParentGenerationList[9]);

                switch (i)
                {
                    case (0):
                        av0 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                    case (1):
                        av1 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                    case (2):
                        av2 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                                 distance7 + distance8 + distance9) / 10;
                        break;
                    case (3):
                        av3 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                    case (4):
                        av4 = (distance0 + distance1 + distance2 + distance3 + distance4 + distance5 + distance6 +
                               distance7 + distance8 + distance9) / 10;
                        break;
                }
            }

            if (chrtMain.Series.IndexOf("Random100Line") == -1)
            {
                chrtMain.Series.Add("Random100Line");
                chrtMain.Series["Random100Line"].ChartType = SeriesChartType.Line;

                _geneticAlgorithmProcessor.RunGA2B(Iterations);

                List<Vertex> pathList = _geneticAlgorithmProcessor.ParentGenerationList[0];

                foreach (var vertex in pathList)
                {
                    chrtMain.Series["Random100Line"].Points.AddXY(vertex.x, vertex.y);
                }

                //close loop
                chrtMain.Series["Random100Line"].Points.AddXY(pathList[0].x, pathList[0].y);
            }
            
            chrtMain.Series["Random100"].ChartArea = "ChartArea1";
        }
    }
}
