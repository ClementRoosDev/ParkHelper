﻿using System;
using System.Collections.Generic;

namespace ParkHelper.TSP
{
    class Program
    {
        private static TSPEnvironment2 _tspEnvironment;

        public static int[] GetBestNeighbour(TabuList tabuList,
            TSPEnvironment2 tspEnviromnet,
            int[] initSolution)
        {


            var bestSol = new int[initSolution.Length]; //this is the best Solution So Far
            bestSol = Arraycopy(initSolution, 0, 0, bestSol.Length);
            var bestCost = tspEnviromnet.GetObjectiveFunctionValue(initSolution);
            var city1 = 0;
            int city2 = 0;
            var firstNeighbor = true;

            for (var i = 1; i < bestSol.Length - 1; i++)
            {
                for (var j = 2; j < bestSol.Length - 1; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var newBestSol = new int[bestSol.Length]; //this is the best Solution So Far
                    newBestSol = Arraycopy(bestSol, 0, 0, newBestSol.Length);

                    newBestSol = SwapOperator(i, j, initSolution); //Try swapping cities i and j
                                                                   // , maybe we get a bettersolution
                    var newBestCost = tspEnviromnet.GetObjectiveFunctionValue(newBestSol);



                    if ((newBestCost > bestCost || firstNeighbor) && _tspEnvironment.distances[i][j] == 0)
                    { //if better move found, store it
                        firstNeighbor = false;
                        city1 = i;
                        city2 = j;
                        bestSol = Arraycopy(newBestSol, 0, 0, newBestSol.Length);
                        bestCost = newBestCost;
                    }


                }
            }

            if (city1 != 0)
            {
                tabuList.decrementTabu();
                tabuList.tabuMove(city1, city2);
            }
            return bestSol;


        }

        //swaps two cities
        public static int[] SwapOperator(int city1, int city2, int[] solution)
        {
            int temp = solution[city1];
            solution[city1] = solution[city2];
            solution[city2] = temp;
            return solution;
        }



        static void Main(string[] args)
        {
            _tspEnvironment = new TSPEnvironment2
            {
                distances = new[]
                {
                    new[] {0, 1, 3, 4, 5},
                    new[] {1, 0, 1, 4, 8},
                    new[] {3, 1, 0, 5, 1},
                    new[] {4, 4, 5, 0, 2},
                    new[] {5, 8, 1, 2, 0}
                }
            };

            //Distance matrix, 5x5, used to represent distances
            //Between cities. 0,1 represents distance between cities 0 and 1, and so on.

            int[] currSolution = { 0, 1, 2, 3, 4, 0 };   //initial solution
                                                                   //city numbers start from 0
                                                                   // the first and last cities' positions do not change

            var numberOfIterations = 100;
            var tabuLength = 10;
            TabuList tabuList = new TabuList(tabuLength);

            int[] bestSol = new int[currSolution.Length]; //this is the best Solution So Far
            bestSol = Arraycopy(currSolution, 0, 0, bestSol.Length);
            int bestCost = _tspEnvironment.GetObjectiveFunctionValue(bestSol);

            for (int i = 0; i < numberOfIterations; i++)
            { // perform iterations here

                currSolution = GetBestNeighbour(tabuList, _tspEnvironment, currSolution);
                //printSolution(currSolution);
                int currCost = _tspEnvironment.GetObjectiveFunctionValue(currSolution);

                //System.out.println("Current best cost = " + tspEnvironment.getObjectiveFunctionValue(currSolution));

                if (currCost < bestCost)
                {
                    bestSol = Arraycopy(currSolution, 0, 0, bestSol.Length);
                    bestCost = currCost;
                }
            }

            Console.WriteLine("Search done! \nBest Solution cost found = " + bestCost + "\nBest Solution :");

            PrintSolution(bestSol);
            Console.ReadKey();
        }

        private static int[] Arraycopy(IReadOnlyList<int> currSolution, int positionDepart, int debut, int fin)
        {
            var result = new int[currSolution.Count];
            for(var i=0;i<fin;i++)
            {
                result[i] = currSolution[i + debut];
            }
            return result;
        }

        public static void PrintSolution(int[] solution)
        {
            foreach (var t in solution)
            {
                Console.Write(t + " ");
            }
            Console.WriteLine("");
        }
    }
}
