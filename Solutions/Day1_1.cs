using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode_2020.Core;
using AdventOfCode_2020.Core.SortingAlgorithms;

namespace AdventOfCode_2020.Solutions
{
    public class Day1_1 : IAdventOfCodeRunnableSolution<IEnumerable<int>, int>
    {
        private IEnumerable<int> _sourcelist;
        

        public Day1_1()
        {
        }

        public int Result()
        {
            var workingSet = _sourcelist.ToArray();

            Report(workingSet);

            //Sort the array
            QuickSort.quickSort(workingSet, 0, _sourcelist.Count() - 1);

            Report(workingSet);


            foreach (var i in workingSet)
            {
                var compliment = 2020 - i;

                var found = Array.BinarySearch(workingSet, compliment);

                if (found > 0)
                {
                    Console.WriteLine($"The solution was found. The compliment for {i} is {compliment} and was found at index {found} (value: {workingSet[found]}) product: {i * workingSet[found]}");
                    break;
                }
                else
                {
                    var startOfRegularSearch = ~found;

                    for (int j = startOfRegularSearch; j < workingSet.Length - 1; j++)
                    {
                        if (workingSet[j] == compliment)
                        {
                            Console.WriteLine($"The solution was found. The compliment for {i} is {compliment} and was found at index {j} (value: {workingSet[j]}) product: {i * workingSet[j]}");
                            break;
                        }
                    }


                }


                if ((found + i) == 2020)
                {
                    Console.WriteLine($"The solution was found: {i} and {found} add up to {i + found}");
                }
                else
                {
                    Console.WriteLine($"{i} and {found} don't add to 2020");
                }
            }


            return 0;
        }

        public void AddContext(IEnumerable<int> context)
        {
            _sourcelist = context;
        }

        private void Report(IEnumerable<int> data)
        {
            int tmp = 0;
            foreach (var i in data)
            {
                Console.WriteLine($"Position {tmp} contained {i}");
                tmp++;
            }
        }
    }
}
