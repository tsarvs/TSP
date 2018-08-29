namespace TSP.Interface
{
    public interface ITSPProcessor
    {
        #region Properties

        int[] ShortestPath { get; set; }

        double ShortestDist { get; set; }

        long CalculationTime { get; set; }

        #endregion

        #region Methods

        void ProcessFile(string fileDir);

        #endregion
    }
}