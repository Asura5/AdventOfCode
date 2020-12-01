using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode_2020.Core
{
    public interface IAdventOfCodeRunnableSolution<TIn, TOut>
    {
        public TOut Result();
        public void AddContext(TIn context);
    }
}
