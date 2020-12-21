using System;
using System.Collections;
using System.Collections.Generic;
namespace Algoexpert
{
    public class SumOPerations
    {
        public SumOPerations()
        {

        }
        //O(n)| O(1)
        public ArrayList FindTwoSum(int[] array,int target)
        {
            //Sort the array
            //n logn n
            ArrayList identified = new ArrayList();
            Array.Sort(array);
            int left = 0;
            int right = array.Length - 1;
            while (left<right)
            {
                int sum = array[left] + array[right];
                if (sum == target)
                {
                    identified.Add(array[left] + "-" + array[right]);
                    Console.WriteLine(array[left] + "," + array[right]);
                    left++;
                    right--;
                }
                else if(sum<target)
                {
                    left++;
                }
                else if(sum>target)
                {
                    right--;
                }
            }
            return identified;
        }
        //O(n2)|O(n)
        public void FindThreenumSum(int[] array, int target)
        {
            //Sort the array
            //n logn n
            HashSet<string> counter = new HashSet<string>();
            Array.Sort(array);
            for (int i = 0; i < array.Length-2; i++)
            {
                int left = i + 1;
                int right = array.Length - 1;
                while (left < right)
                {
                    int sum = array[i]+array[left] + array[right];
                    if (sum == target)
                    {
                        string format = array[i] + "," + array[left] + "," + array[right];
                        if (!counter.Contains(format))
                        {
                            counter.Add(format);
                        }
                        left++;
                        right--;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else if (sum > target)
                    {
                        right--;
                    }
                }
            }
            Console.WriteLine("Total count" + counter.Count);
        }
        public List<int[]> FournumberSum(int[] input, int target)
        {
            Dictionary<int, List<int[]>> allPairs = new Dictionary<int, List<int[]>>();
            List<int[]> quadruplets = new List<int[]>();
            for (int i = 1; i < input.Length - 1; i++)
            {

                for (int j = i + 1; j < input.Length; j++)
                {
                    int currentSum = input[i] + input[j];
                    int diff = target - currentSum;
                    if (allPairs.ContainsKey(diff))
                    {
                        foreach (int[] pair in allPairs[diff])
                        {
                            int[] quadraPulet = { pair[0], pair[1], input[i], input[j] };
                            quadruplets.Add(quadraPulet);
                        }
                    }
                }
                //find P and Q where P = X,Y
                for (int k = 0; k < i; k++)
                {
                    int currentSum = input[i] + input[k];
                    int[] pair = { input[i], input[k] };
                    if (!allPairs.ContainsKey(currentSum))
                    {
                        allPairs.Add(currentSum, new List<int[]> { pair });
                    }
                    else
                    {
                        allPairs[currentSum].Add(pair);
                    }
                }
            }
            return quadruplets;
        }

        //O(nlog(n) + m log(m) | O(1)
        public int[] FindSmallestDifference(int[] firstArray,int[] secondArray)
        {
            //n log n
            //m log n
            Array.Sort(firstArray);
            Array.Sort(secondArray);
            int left = 0;
            int right = 0;
            int[] smallPair = new int[2];
            int smallest = int.MaxValue;
            int current = int.MaxValue;
            while (left<firstArray.Length && right<secondArray.Length)
            {   
                int first = firstArray[left];
                int second = secondArray[right];
                if (first < second)
                {
                    current = second - first;
                    left++;
                }
                else if(second < first)
                {
                    current = first - second;
                    right++;
                }
                else
                {
                    return new int[] { first, second };
                }
                if (smallest > current)
                {
                    smallest = current;
                    smallPair = new int[] { first, second };
                }
            }
            Console.WriteLine(smallPair[0]+","+smallPair[1]);
            return smallPair;
        }
        public int MaxSubsetSumNoAdjacent(int[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }
            if (array.Length == 1)
            {
                return array[0];
            }
            int[] maxSums = (int[])array.Clone();
            maxSums[1] = Math.Max(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                maxSums[i] = Math.Max(maxSums[i - 1], maxSums[i - 2] + array[i]);
            }
            return maxSums[array.Length - 1];
        }
        public int CoingChangeWays(int amount,int[] coins)
        {
           
            int[] maxWays = new int[amount + 1];
            maxWays[0] = 1;
            foreach (var coin in coins)
            {
                for (int i = 1; i < amount+1; i++)
                {
                    if (i>=coin)
                    {
                        maxWays[i] += maxWays[i - coin];
                    }
                }
            }
            return maxWays[amount];
        }
        public int MinimumCoins(int amount, int[] coins)
        {
            //1,2,5 12
            /* 12 5 7
             * 7  5 2
             * 2  2  0
             *
             * */
            Array.Sort(coins);
            int number = 0;
            
            int right = coins.Length-1;
            while (right>=0)
            {
                int coin = coins[right];
                while (amount >= coin)
                {
                    Console.WriteLine(coin);
                    amount -= coin;
                    number++;
                }
                right--;
            }
            if (amount == 0)
            {
                return number;
            }
            else
            {
                return -1;
            }
            
        }
        public int MinimumCoinsDynamic(int amount,int[] coins)
        {
            int[] numofCoins = new int[amount + 1];
            Array.Fill(numofCoins, int.MaxValue);
            numofCoins[0] = 0;
            foreach (var coin in coins)
            {
                for (int i = 1; i < numofCoins.Length; i++)
                {
                    if (coin<=i)
                    {
                        numofCoins[i] = Math.Min(numofCoins[i], 1 + numofCoins[i - coin]);
                    }
                }
            }
            return numofCoins[amount] != int.MaxValue ? numofCoins[amount] : -1;
        }
        public void KadaneAlogrith(int[] input)
        {
            int maxEndingHere = input[0];
            int maxSofar = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                int number = input[i];
                maxEndingHere = Math.Max(maxEndingHere + number, number);
                maxSofar = Math.Max(maxEndingHere, maxSofar);
            }
            Console.Write(maxSofar);
        }
        
    }
}
