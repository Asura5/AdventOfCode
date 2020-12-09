using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode_2020.Core;

namespace AdventOfCode_2020.Solutions
{
    public class Day2_2 : IAdventOfCodeRunnableSolution<IEnumerable<string>, int>
    {
        private IEnumerable<string> _listOfPasswords;

        public int Result()
        {
            int i = 0;
            int validPasswords = 0, invalidPasswords = 0;

            foreach (var line in _listOfPasswords)
            {
                int matches = 0;

                var colonPosition = line.IndexOf(":");

                var policy = line.Substring(0, colonPosition);

                var firstPositionOneBased = Convert.ToInt32(policy.Substring(0,policy.IndexOf('-')));

                var dashIndex = policy.IndexOf('-');
                var spaceIndex = policy.IndexOf(' ');

                var secondPositionOneBased = Convert.ToInt32(policy.Substring(dashIndex + 1, (spaceIndex - dashIndex)-1 ));
                
                var password = line.Substring(colonPosition + 2, (line.Length - (colonPosition + 2)));

                var policyLetter = policy[colonPosition - 1];

                if (password[firstPositionOneBased - 1] == policyLetter) matches++;
                if (password[secondPositionOneBased - 1] == policyLetter) matches++;

                if (matches == 1)
                {
                    Console.WriteLine($"Policy found: {policy}, Password found: {password} 1stpos One based: {firstPositionOneBased} 2ndpos one based: {secondPositionOneBased} Letter: {policyLetter} Match policy: {matches == 1}");
                    validPasswords++;
                }
                else
                {
                    Console.WriteLine($"Policy found: {policy}, Password found: {password} 1stpos One based: {firstPositionOneBased} 2ndpos one based: {secondPositionOneBased} Letter: {policyLetter} Match policy: {matches == 1}");
                    invalidPasswords++;
                }
            }

            Console.WriteLine($"Operation complete: Valid passwords: {validPasswords}, Invalid passwords: {invalidPasswords}, Total passwords: {invalidPasswords + validPasswords}");
            return i;
        }

        public void AddContext(IEnumerable<string> context)
        {
            _listOfPasswords = context;
        }
    }
}
