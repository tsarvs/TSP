namespace TSP.Interface
{
    internal interface IPermutationProcessor
    {
        #region Properties

        int[] ShortestPath { get; set; }

        double ShortestDistance { get; set; }

        #endregion
        #region Methods

        void Permutation(int listSize);

        #endregion
    }
}