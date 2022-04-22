/**

[Requirements]
	In a town, there are `N` people labelled from 1 to N. There is a rumor that one of these
    people is secretly the town judge.
 
	If the town judge exists, then:
		1. The town judge trusts nobody.
		2. Everybody (except for the town judge) trusts the town judge.
		3. There is exactly one person that satisfies properties 1 and 2.
 
	You are given `trust`, an array of pairs trust[i] = [a, b] representing that the person
    labelled `a` trusts the person labelled `b`.
	If the town judge exists and can be identified, return the label of the town judge.
    Otherwise, return -1.
 
[Example 1]
	Input: N = 3, trust = [[1,3],[2,3]]
	Output: 3
[Example 2]
	Input: N = 3, trust = [[1,3],[2,3],[3,1]]
	Output: -1
[Example 3]
	Input: N = 4, trust = [[1,3],[1,4],[2,3],[2,4],[4,3]]
	Output: 3

**/


using System;
using System.Collections.Generic;
using System.Linq;


namespace JudgeChallenge
{
    public class Solution
    {
        public static int findJudge(int N, int[,] trust)
        {
            List<int> mayBeJudge = Enumerable.Repeat(0, N+1).ToList();
            int Judge = 0;

            //write your solution here 

            for (int i = 0; i < trust.GetLength(0); i++)
            {
                mayBeJudge[trust[i, 1]] ++;
            }

            for (int i = 1; i < mayBeJudge.Count; i++)
            {
                if (mayBeJudge[i] == N-1)
                {
                    if (Judge == 0)
                    {
                        Judge = i;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }

            for (int i = 0; i < trust.GetLength(0); i++)
            {
                if (trust[i, 0] == Judge)
                {
                    return -1;
                }
            }
            return Judge;

        }

    }
    public class Program
    {

        public static void Main(string[] args)
        {
            var N = 3;
            var trust = new int[,] { { 1, 3 }, { 2, 3 } };
            Console.WriteLine(Solution.findJudge(N, trust));

            N = 3;
            trust = new int[,] { { 1, 3 }, { 2, 3 }, { 3, 1 } };
            Console.WriteLine(Solution.findJudge(N, trust));

            N = 4;
            trust = new int[,] { { 1, 3 }, { 1, 4 }, { 2, 3 }, { 2, 4 }, { 4, 3 } };
            Console.WriteLine(Solution.findJudge(N, trust));

        }
    }
}