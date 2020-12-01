using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode_2020.Core;
using AdventOfCode_2020.Core.SortingAlgorithms;

namespace AdventOfCode_2020.Solutions
{
    public class Day1_2 : IAdventOfCodeRunnableSolution<IEnumerable<int>, int>
    {
        private IEnumerable<int> _sourcelist;
        

        public Day1_2()
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
                //for each item in the ordered list, prepare a complimentary array of all numbers who don't already sum to more than 2020
                var compliment = 2020 - i;

                var upperBoundSecondOrder = Array.BinarySearch(workingSet, compliment);

                //the complimentary array is everything smaller (lower) than that
                int[] complimentarySecondOrderArray;

                if (upperBoundSecondOrder < 0)
                {
                    complimentarySecondOrderArray = workingSet[..^~upperBoundSecondOrder];
                }
                else
                {
                    complimentarySecondOrderArray = workingSet[..^upperBoundSecondOrder];
                }

                foreach (var i2 in complimentarySecondOrderArray)
                {
                    var thirdCompliment = 2020 - i - i2;

                    var thirdOrderComplimentIndex = Array.BinarySearch(workingSet, thirdCompliment);

                    if (thirdOrderComplimentIndex > 0)
                    {
                        Console.WriteLine($"The solution was found. Values: {i}, {i2}, {thirdCompliment} (in pos {thirdOrderComplimentIndex} product: {i * i2 * thirdCompliment}");
                        break;
                    }
                    else
                    {
                        var startOfRegularSearch = ~thirdOrderComplimentIndex;

                        for (int j = startOfRegularSearch; j < workingSet.Length - 1; j++)
                        {
                            if (workingSet[j] == thirdCompliment)
                            {
                                Console.WriteLine($"The solution was found. Values: {i}, {i2}, {thirdCompliment} product: {i * i2 * thirdCompliment} ");
                                break;
                            }
                        }


                    }

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
