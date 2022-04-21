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
            List<int> notJuge = new List<int>();
            List<int> mayBeJuge = new List<int>();
            List<int> whoTrustJuge = new List<int>();

            //write your solution here
            for (int i = 0; i < trust.GetLength(0); i++)
            {
                notJuge.Add(trust[i, 0]);
            }
            for (int i = 1; i <= N; i++)
            {
                if (!notJuge.Contains(i))
                {
                    mayBeJuge.Add(i);
                }
            }
            if (mayBeJuge.Count != 1)
            {
                return -1;
            }
            for (int i = 0; i < trust.GetLength(0); i++)
            {
                if (trust[i, 1] == mayBeJuge[0])
                {
                    whoTrustJuge.Add(trust[i, 0]);
                }
            }
            for (int i = 1; i <= N; i++)
            {
                if (!(whoTrustJuge.Contains(i)) && i != mayBeJuge[0])
                {
                    return -1;
                }
            }
            return mayBeJuge[0];
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