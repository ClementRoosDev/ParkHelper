using System.Linq;

namespace ParkHelper.Apiv2.Model
{
    public class TspEnvironment
    {
        public int[][] Distances;

        public int GetObjectiveFunctionValue(int[] solution)
        { //returns the path cost
          //the first and the last cities'
          //  positions do not change.
          // example solution : {0, 1, 3, 4, 2, 0}
            var cost = 0;

            for (var i = 0; i < solution.Length - 1; i++)
            {
                var position = solution.ElementAt(i);
                var newPosition = position - 1;
                var x = Distances[newPosition];
                var y = x.ElementAt(i + 1);
                cost += y;
            }
            return cost;
        }
    }
}