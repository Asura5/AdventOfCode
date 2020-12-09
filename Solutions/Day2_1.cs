using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode_2020.Core;

namespace AdventOfCode_2020.Solutions
{
    public class Day2_1 : IAdventOfCodeRunnableSolution<IEnumerable<string>, int>
    {
        private IEnumerable<string> _listOfPasswords;

        public int Result()
        {
            int i = 0;
            int validPasswords = 0, invalidPasswords = 0;

            foreach (var line in _listOfPasswords)
            {
                var colonPosition = line.IndexOf(":");

                var policy = line.Substring(0, colonPosition);

                var lowerBound = Convert.ToInt32(policy.Substring(0,policy.IndexOf('-')));

                var dashIndex = policy.IndexOf('-');
                var spaceIndex = policy.IndexOf(' ');

                var upperBound = Convert.ToInt32(policy.Substring(dashIndex + 1, (spaceIndex - dashIndex)-1 ));
                
                var password = line.Substring(colonPosition + 2, (line.Length - (colonPosition + 2)));

                var policyLetter = policy[colonPosition - 1];

                Console.WriteLine($"Policy found: {policy}, Password found: {password} Lowerlimit of chars: {lowerBound} Upperlimit of chars: {upperBound} Letter: {policyLetter}");

                var numberOfPolicyLetters = password.Count(l => l == policyLetter);

                if (numberOfPolicyLetters < lowerBound)
                {
                    Console.WriteLine($"Not in policy: There are fewer than {lowerBound} {policyLetter} in {password}");
                    invalidPasswords++;
                    continue;
                }

                if (numberOfPolicyLetters > upperBound)
                {
                    Console.WriteLine($"Not in policy: There are more than {upperBound} {policyLetter} in {password}");
                    invalidPasswords++;
                    continue;
                }

                Console.WriteLine($"In policy: There are between {lowerBound} and {upperBound} {policyLetter} in {password}");
                validPasswords++;

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
