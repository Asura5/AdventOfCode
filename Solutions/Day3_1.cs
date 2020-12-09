using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using AdventOfCode_2020.Core;

namespace AdventOfCode_2020.Solutions
{
    public class Day3_1 : IAdventOfCodeRunnableSolution<IEnumerable<string>, int>
    {
        private IEnumerable<string> _treelines;
        private char[,] _forest;
        private int _xPosition;
        private int _yPosition;
        public int EffectiveXPosition => _xPosition % 31;

        public int Result()
        {
            var hillDepth = _treelines.Count();
            var hillWidth = _treelines.First().Length;

            Console.WriteLine($"hillDepth: {hillDepth}, hillWidth: {hillWidth}");

            int numberOfTreesHit = 0;

            _forest = new char[hillDepth, hillWidth];

            PopulateArray();

            _xPosition = 0;
            _yPosition = 0;

            for (int p = 1; p < (hillDepth / 2)+1; p++)
            {
                Move(1, 2);

                if (_forest[_yPosition, EffectiveXPosition] == '#')
                {
                    Console.WriteLine($"Tree found at: {EffectiveXPosition},{_yPosition}");
                    numberOfTreesHit++;
                }
                else
                {
                    Console.WriteLine($"No tree found at: {EffectiveXPosition},{_yPosition}");
                }
            }

            RecreateForestMap(_forest);

            Console.WriteLine($"Total number of trees hit: {numberOfTreesHit}");
            return numberOfTreesHit;
        }

        private void PopulateArray()
        {
            int i = 0, j = 0;

            foreach (var line in _treelines)
            {
                j = 0;

                foreach (var point in line)
                {
                    _forest[i, j] = point;
                    j++;
                }

                i++;
            }
        }

        private void RecreateForestMap(char[,] forest)
        {
            var depth = forest.GetLength(0);
            var width = forest.GetLength(1);

            for (int x = 0; x < depth; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    Console.Write(forest[x,y]);
                }

                Console.WriteLine();
            }
        }

        public void AddContext(IEnumerable<string> context)
        {
            _treelines = context;
        }

        private void MoveRight(int steps)
        {
            _xPosition += steps;
        }

        private void MoveDown(int steps)
        {
            _yPosition += steps;
        }

        private void Move(int right, int down)
        {
            MoveRight(right);
            MoveDown(down);
        }
    }
}
