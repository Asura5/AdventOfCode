using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2020.Core
{
    public interface IAdventOfCodeContextProvider<T>
    {
        public Task<T> GenerateContext();
    }
}
