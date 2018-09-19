using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using TSP.Class;
using TSP.Interface;
using TSP.Struct;
using TSPConsole.Properties;

namespace TSPConsole
{
    internal class TSPUserConsole
    {

        #region Properties

        private readonly ITSPProcessor _tspProcessor;

        private readonly IPathProcessor _pathProcessor;

        #endregion

        #region Constructor

        public TSPUserConsole()
        {
            _tspProcessor = new TSPProcessor();

            _pathProcessor = new PathProcessor();
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
            Console.WriteLine("1) Project 1");
            Console.WriteLine("2) Project 2");
            Console.WriteLine("3) Project 3");
            Console.WriteLine("0) Exit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    input = Lab1Menu();
                    break;
                case "2":
                    input = Lab2Menu();
                    break;
                case "3":
                    input = Lab3Menu();
                    break;
                case "0":
                    Console.WriteLine("Thank you for using the TSP Processor");
                    break;
                default:
                    Console.WriteLine("You have provided incorrect input. Please try again.");
                    break;
            }

            return input;
        }

        private string Lab1Menu()
        {
            Console.WriteLine("\nProject 1");
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
                    BruteForceTSP("TSPFile/11PointDFSBFS.tsp");
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
            _tspProcessor.ProcessFile(file);

            Console.WriteLine("\nShortest Path: [" + string.Join(",", _tspProcessor.ShortestPath) + "]");
            Console.WriteLine("Shortest Distance: " + _tspProcessor.ShortestDist);
            Console.WriteLine("Calculation Time (ms): " + _tspProcessor.CalculationTime);

            Console.WriteLine("\nPress the enter button to continue. . .");
            Console.ReadLine();
        }

        private string Lab2Menu()
        {
            Console.WriteLine("\nProject 2");
            Console.WriteLine("1) Breadth First Search");
            Console.WriteLine("2) Depth First Search");
            Console.WriteLine("0) Exit");

            Console.WriteLine("Chose a search method: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    IBFSProcessor bfs = new BFSProcessor();

                    bfs.ProcessFile(Resources._11PointDFSBFS);

                    Console.WriteLine("\nShortest Path: [" + string.Join(",", bfs.ShortestPath) + "]");
                    Console.WriteLine("Shortest Distance: " + bfs.ShortestDistance);
                    Console.WriteLine("Calculation Time (ms): " + bfs.CalculationTime);

                    Console.WriteLine("\nPress the enter button to continue. . .");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("\nUnder Maintenance");
                    //IDFSProcessor dfs = new DFSProcessor();

                    //dfs.ProcessFile(Resources._11PointDFSBFS);

                    //Console.WriteLine("\nShortest Path: [" + string.Join(",", dfs.ShortestPath) + "]");
                    //Console.WriteLine("Shortest Distance: " + dfs.ShortestDist);
                    //Console.WriteLine("Calculation Time (ms): " + dfs.CalculationTime);

                    Console.WriteLine("\nPress the enter button to continue. . .");
                    Console.ReadLine();
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

        private string Lab3Menu()
        {
            Console.WriteLine("\nProject 2");
            Console.WriteLine("1) Random30.tsp");
            Console.WriteLine("2) Random40.tsp");
            Console.WriteLine("0) Exit");

            Console.WriteLine("Chose a file to run: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    GreedyAlgorithmTSP("TSPFile/Random30.tsp");
                    break;
                case "2":
                    GreedyAlgorithmTSP("TSPFile/Random40.tsp");
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

        private void GreedyAlgorithmTSP(string fileName)
        {
            Stopwatch stopwatch = new Stopwatch();
            

            IGreedyTSPProcessor fileProcessor = new GreedyTSPProcessor(fileName);

            stopwatch.Start();

            List<Vertex> outputPath = fileProcessor.BuildPath();

            stopwatch.Stop();

            Console.WriteLine("\nOutput Path");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Calculation Time: " + stopwatch.ElapsedMilliseconds + " ms");
            Console.WriteLine("Distance: " + _pathProcessor.Process(outputPath) + " units");
            Console.WriteLine("--------------------------------");

            foreach (var vertex in outputPath)
            {
                Console.WriteLine("\t("+vertex.x+", "+vertex.y+")");
            }


            Console.WriteLine("\nPress the enter button to continue. . .");
            Console.ReadLine();
        }
        #endregion
    }
}