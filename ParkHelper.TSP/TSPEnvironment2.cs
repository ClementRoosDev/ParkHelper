using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.TSP
{
    public class TSPEnvironment2
    {
        //Tabu Search Environment
        public int[][] distances;

        public TSPEnvironment2()
        {

        }

        public int GetObjectiveFunctionValue(int[] solution)
        { //returns the path cost
          //the first and the last cities'
          //  positions do not change.
          // example solution : {0, 1, 3, 4, 2, 0}

            int cost = 0;

            for (int i = 0; i < (solution.Length - 1); i++)
            {
                var position = solution.ElementAt(i);
                var newPosition = position - 1;
                var x = distances[newPosition];
                var y = x.ElementAt(i + 1);
                cost += y;
            }

            return cost;

        }
    }
}