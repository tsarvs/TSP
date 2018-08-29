using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSP.Interface;
using TSP.Struct;

namespace TSP.Class
{
    internal class TSPReader : ITSPReader
    {
        #region Properties

        private List<Vertex> _vertices;

        #endregion

        #region Constructors

        public TSPReader()
        {
            _vertices = new List<Vertex>();
        }
        #endregion

        #region Methods

        public List<Vertex> ReadTSP(string fileDir)
        {
            _vertices.Clear();

            using (StreamReader reader = new StreamReader(fileDir))
            {
                string line;

                do
                {
                    line = reader.ReadLine();
                } while (line != "NODE_COORD_SECTION");

                string x, y;
                
                do
                {
                    Vertex tempVertex = new Vertex();

                    line = reader.ReadLine();

                    //get the substring of coordinates
                    line = line.Substring(line.IndexOf(" ") + 1);

                    x = line.Substring(0, line.IndexOf(" "));
                    y = line.Substring(line.IndexOf(" ") + 1);

                    //turn to a vertex
                    tempVertex.x = Convert.ToDouble(x);
                    tempVertex.y = Convert.ToDouble(y);

                    this._vertices.Add(tempVertex);

                } while (!reader.EndOfStream);
            }

            return _vertices;
        }



        #endregion
    }
}
