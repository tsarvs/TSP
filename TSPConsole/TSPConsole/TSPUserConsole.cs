using System;
using TSP.Class;
using TSP.Interface;

namespace TSPConsole
{
    internal class TSPUserConsole
    {

        #region Properties

        private readonly ITSPProcessor _processor;

        #endregion
        #region Constructor

        public TSPUserConsole()
        {
            _processor = new TSPProcessor();
        }

        #endregion

        #region Methods

        public void Run()
        {
            string input;

            do
            {
                input = MainMenu();
                
            } while (input != "0");
        }

        private string MainMenu()
        {
            Console.Clear();

            Console.WriteLine("Welcome to the TSP Processor");
            Console.WriteLine("1) Run Random4.tsp");
            Console.WriteLine("2) Run Random5.tsp");
            Console.WriteLine("3) Run Random6.tsp");
            Console.WriteLine("4) Run Random7.tsp");
            Console.WriteLine("5) Run Random8.tsp");
            Console.WriteLine("6) Run Random9.tsp");
            Console.WriteLine("7) Run Random10.tsp");
            Console.WriteLine("8) Run Random11.tsp");
            Console.WriteLine("9) Run Random12.tsp");
            Console.WriteLine("0) Exit");

            Console.WriteLine("Chose a TSP file to process: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    BruteForceTSP("TSPFile/Random4.tsp");
                    break;
                case "2":
                    BruteForceTSP("TSPFile/Random5.tsp");
                    break;
                case "3":
                    BruteForceTSP("TSPFile/Random6.tsp");
                    break;
                case "4":
                    BruteForceTSP("TSPFile/Random7.tsp");
                    break;
                case "5":
                    BruteForceTSP("TSPFile/Random8.tsp");
                    break;
                case "6":
                    BruteForceTSP("TSPFile/Random9.tsp");
                    break;
                case "7":
                    BruteForceTSP("TSPFile/Random10.tsp");
                    break;
                case "8":
                    BruteForceTSP("TSPFile/Random11.tsp");
                    break;
                case "9":
                    BruteForceTSP("TSPFile/Random12.tsp");
                    break;
                case "0":
                    Console.WriteLine("Thank you for using the TSP Processor!");
                    break;
                default:
                    Console.WriteLine("You have provided incorrect input. Please try again.");
                    break;
            }

            return input;
        }

        private void BruteForceTSP(string file)
        {
            _processor.ProcessFile(file);

            Console.WriteLine("\nShortest Path: [" + string.Join(",", _processor.ShortestPath) + "]");
            Console.WriteLine("Shortest Distance: " + _processor.ShortestDist);
            Console.WriteLine("Calculation Time (ms): " + _processor.CalculationTime);

            Console.ReadKey();
        }

        #endregion
    }
}