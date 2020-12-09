using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode_2020.Core;

namespace AdventOfCode_2020.Solutions
{
    public class Day2Context : IAdventOfCodeContextProvider<IEnumerable<string>>
    {
        public Task<IEnumerable<string>> GenerateContext()
        {
            var fileInput = File.ReadLines("Day2_1_data.txt");

            return Task.FromResult(fileInput);

        }
    }
}
