namespace ParkHelper.TSP
{
    public class TabuList
    {
        public int[][] tabuList;
        public TabuList(int numCities)
        {
            tabuList = new int[numCities][];
            //for (int i = 0; i < numCities; i++)
            //{
            //    tabuList[i] = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //}
            
            //city 0 is not used here, but left for simplicity
        }

        public void tabuMove(int city1, int city2)
        { 
            //tabus the swap operation
            tabuList[city1][city2] += 5;
            tabuList[city2][city1] += 5;

        }

        public void decrementTabu()
        {
            for (int i = 0; i < tabuList.Length; i++)
            {
                for (int j = 0; j < tabuList.Length; j++)
                {
                    tabuList[i][j] -= tabuList[i][j] <= 0 ? 0 : 1;
                }
            }
        }

    }
}