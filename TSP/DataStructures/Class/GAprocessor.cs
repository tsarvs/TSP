using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSP.Interface;
using TSP.Struct;

namespace TSP.Class
{
    public class GAProcessor : IGAProcessor
    {
        #region Properties

        private ITSPReader _fileReader;

        private IPathProcessor _pathProcessor;

        private List<Vertex> _vertices;

        private const int GenerationSize = 10;

        private const double CrossoverProb = .6;

        private const double MutationProb = .01;

        public List<List<Vertex>> ParentGenerationList { get; set; }

        private List<List<Vertex>> _childGenerationList;

        public List<int> FitnessList { get; set; }

        private Random _rng;

        #endregion

        #region Constructor

        public GAProcessor()
        {
            _fileReader = new TSPReader();
            _pathProcessor = new PathProcessor();
            _vertices = new List<Vertex>();
            ParentGenerationList = new List<List<Vertex>>();
            _childGenerationList = new List<List<Vertex>>();
            FitnessList = new List<int>();
            _rng = new Random();

        }

        public GAProcessor(string filename)
        {
            _fileReader = new TSPReader();
            _pathProcessor = new PathProcessor();
            _vertices = new List<Vertex>(_fileReader.ReadTSP(filename));
            ParentGenerationList = new List<List<Vertex>>();
            _childGenerationList = new List<List<Vertex>>();
            FitnessList = new List<int>();
            _rng = new Random();

        }
        #endregion

        #region Methods

        public void PopulateVertices(string fileDir)
        {
            _vertices = _fileReader.ReadTSP(fileDir);
        }

        //1-point crossover, Twors Mutation
        public void RunGA1A(int iterations)
        {
            GenerateInitialPopulation();

            for (int i = 0; i < iterations; i++)
            {
                _childGenerationList.Clear();

                while (_childGenerationList.Count < 10)
                {
                    EvaluateParentFitness();

                    List<List<Vertex>> parentPair = RouletteWheelSelection();
                    List<List<Vertex>> childPair = Crossover1Pt(parentPair);

                    childPair[0] = MutationTwors(childPair[0]);
                    childPair[1] = MutationTwors(childPair[1]);

                    _childGenerationList.Add(childPair[0]);
                    _childGenerationList.Add(childPair[1]);
                }

                ParentGenerationList.Clear();
                ParentGenerationList.AddRange(_childGenerationList);
            }

        }

        //2-point crossover, Twors Mutation
        public void RunGA1B(int iterations)
        {
            GenerateInitialPopulation();

            for (int i = 0; i < iterations; i++)
            {
                _childGenerationList.Clear();

                while (_childGenerationList.Count < 10)
                {
                    EvaluateParentFitness();

                    List<List<Vertex>> parentPair = RouletteWheelSelection();
                    List<List<Vertex>> childPair = Crossover2Pt(parentPair);

                    childPair[0] = MutationTwors(childPair[0]);
                    childPair[1] = MutationTwors(childPair[1]);

                    _childGenerationList.Add(childPair[0]);
                    _childGenerationList.Add(childPair[1]);
                }

                ParentGenerationList.Clear();
                ParentGenerationList.AddRange(_childGenerationList);
            }

        }

        //1-point crossover, Reverse Sequence Mutation
        public void RunGA2A(int iterations)
        {
            GenerateInitialPopulation();

            for (int i = 0; i < iterations; i++)
            {
                _childGenerationList.Clear();

                while (_childGenerationList.Count < 10)
                {
                    EvaluateParentFitness();

                    List<List<Vertex>> parentPair = RouletteWheelSelection();
                    List<List<Vertex>> childPair = Crossover1Pt(parentPair);

                    childPair[0] = MutationReverseSeq(childPair[0]);
                    childPair[1] = MutationReverseSeq(childPair[1]);

                    _childGenerationList.Add(childPair[0]);
                    _childGenerationList.Add(childPair[1]);
                }

                ParentGenerationList.Clear();
                ParentGenerationList.AddRange(_childGenerationList);
            }
        }

        //2-point crossover, Reverse Sequence Mutation
        public void RunGA2B(int iterations)
        {
            GenerateInitialPopulation();

            for (int i = 0; i < iterations; i++)
            {
                _childGenerationList.Clear();

                while (_childGenerationList.Count < 10)
                {
                    EvaluateParentFitness();

                    List<List<Vertex>> parentPair = RouletteWheelSelection();
                    List<List<Vertex>> childPair = Crossover2Pt(parentPair);

                    childPair[0] = MutationReverseSeq(childPair[0]);
                    childPair[1] = MutationReverseSeq(childPair[1]);

                    _childGenerationList.Add(childPair[0]);
                    _childGenerationList.Add(childPair[1]);
                }

                ParentGenerationList.Clear();
                ParentGenerationList.AddRange(_childGenerationList);
            }
        }

        //populate parent generation with randomized paths
        private void GenerateInitialPopulation()
        {
            for (int i = 0; i < GenerationSize; i++)
            {
                //generate random path & add it to ParentGenerationList
                ParentGenerationList.Add(GenerateRandomPath());
            }
        }

        private List<Vertex> GenerateRandomPath()
        {
            List<Vertex> randomList = new List<Vertex>(_vertices);
            
            for (int i = 0; i < _vertices.Count - 1; i++)
            {
                var swapIndex = _rng.Next(0, randomList.Count - 1);

                Vertex tempVertex = randomList[i];
                randomList[i] = randomList[swapIndex];
                randomList[swapIndex] = tempVertex;
            }

            return randomList;
        }

        //populate Fitness List with parents level of fitness
        private void EvaluateParentFitness()
        {
            FitnessList.Clear();

            List<double> lengthList = new List<double>();

            foreach (var path in ParentGenerationList)
            {
                lengthList.Add(_pathProcessor.Process(path));
            }

            int i = 0;
            foreach (var pathLength in lengthList)
            {
                //higher rank = higher fitness
                int rank = 1;
                foreach (var d in lengthList)
                {
                    if (pathLength < d)
                    {
                        rank++;
                    }
                }

                FitnessList.Add(rank);
            }

            for (int j = 0; j < FitnessList.Count; j++)
            {
                if (FitnessList.FindAll(x => x == j).Count > 1)
                {
                    FitnessList[FitnessList.FindIndex(x => x == j)] += 1;
                }
            }
        }

        //input: population list
        //output: two paths
        public List<List<Vertex>> RouletteWheelSelection()
        {
            int rangeMax = 0;
            int selectedA = 0, selectedB = 0;
            List<Vertex> pathA = new List<Vertex>(), pathB = new List<Vertex>();
            
            foreach (var i in FitnessList)
            {
                rangeMax += i;
            }

            do
            {
                //find pathA
                do
                {
                    selectedA = _rng.Next(1, rangeMax);
                    int intiialA = selectedA;
                    int iA = 0;

                    for (int i = 1; i <= FitnessList.Count; i++)
                    {
                        iA = i;
                        if (selectedA - i > 0)
                        {
                            selectedA -= i;
                        }
                        else
                        {
                            for (int j = 0; j <= FitnessList.Count - 1; j++)
                            {
                                if (FitnessList[j] == i)
                                {
                                    pathA = ParentGenerationList[j];
                                    break;
                                }
                            }

                            break;
                        }
                    }
                } while (pathA.Count == 0);
                
                //find pathB
                do
                {
                    selectedB = _rng.Next(1, rangeMax);

                    //for debugging purposes
                    int initialB = selectedB; 
                    int iB = 0;

                    for (int i = 1; i <= FitnessList.Count; i++)
                    {
                        iB = i;
                        if (selectedB - i > 0)
                        {
                            selectedB -= i;
                        }
                        else
                        {
                            for (int j = 0; j <= FitnessList.Count - 1; j++)
                            {
                                if (FitnessList[j] == i)
                                {
                                    pathB = ParentGenerationList[j];
                                    break;
                                }
                            }

                            break;
                        }
                    }
                } while (pathB.Count == 0);
                
            } while (pathA == pathB);

            List<List<Vertex>> parentPair = new List<List<Vertex>>();
            parentPair.Add(pathA);
            parentPair.Add(pathB);

            return parentPair;
        }

        private List<List<Vertex>> Crossover1Pt(List<List<Vertex>> parents)
        {
            List<Vertex> childA = new List<Vertex>(), childB = new List<Vertex>();

            if (_rng.NextDouble() <= CrossoverProb)
            {
                var i = _rng.Next(1, _vertices.Count - 2);
                
                childA.AddRange(parents[0].GetRange(0, i));
                childA.AddRange(parents[1].GetRange(i, parents[1].Count - i));

                childB.AddRange(parents[1].GetRange(0, i));
                childB.AddRange(parents[0].GetRange(i, parents[1].Count - i));
                
            }
            else
            {
                //no crossover
                childA = parents[0];
                childB = parents[1];
            }

            List<List<Vertex>> childPair = new List<List<Vertex>>();
            childPair.Add(childA);
            childPair.Add(childB);

            return childPair;
        }

        private List<List<Vertex>> Crossover2Pt(List<List<Vertex>> parents)
        {
            List<Vertex> childA = new List<Vertex>(), childB = new List<Vertex>();

            if (_rng.NextDouble() <= CrossoverProb)
            {
                int i, j;

                do
                {
                    i = _rng.Next(1, _vertices.Count - 2);
                    j = _rng.Next(1, _vertices.Count - 2);
                } while (i == j || i > j);
                
                childA.AddRange(parents[0].GetRange(0, i));
                childA.AddRange(parents[1].GetRange(i, j - i));
                childA.AddRange(parents[0].GetRange(j, parents[0].Count - j));

                childB.AddRange(parents[1].GetRange(0, i));
                childB.AddRange(parents[0].GetRange(i, j - i));
                childB.AddRange(parents[1].GetRange(j, parents[0].Count - j));

            }
            else
            {
                //no crossover
                childA = parents[0];
                childB = parents[1];
            }

            List<List<Vertex>> childPair = new List<List<Vertex>>();
            childPair.Add(childA);
            childPair.Add(childB);

            return childPair;
        }

        private List<Vertex> MutationTwors(List<Vertex> child)
        {
            if (_rng.NextDouble() <= MutationProb)
            {
                int i = 0;
                int j = 0;

                while (i == j)
                {
                    i = _rng.Next(0, _vertices.Count - 1);
                    j = _rng.Next(0, _vertices.Count - 1);
                }

                Vertex tempVertex = child[i];
                child[i] = child[j];
                child[j] = tempVertex;
            }

            return child;

        }

        private List<Vertex> MutationReverseSeq(List<Vertex> child)
        {
            if (_rng.NextDouble() <= MutationProb)
            {
                int i = 0;//also acts as index for flipping
                int j = 0;

                while (i>=j)
                {
                    i = _rng.Next(0, _vertices.Count - 1);
                    j = _rng.Next(0, _vertices.Count - 1);
                }

                List<Vertex> subList = child.GetRange(i, j - i);
                subList.Reverse();

                foreach (var vertex in subList)
                {
                    child[i] = vertex;
                    i++;
                }
            }

            return child;
        }
        
        #endregion
    }
}
