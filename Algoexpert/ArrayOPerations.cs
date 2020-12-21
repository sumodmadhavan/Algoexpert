using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Algoexpert
{
    public class ArrayOPerations
    {
        public ArrayOPerations()
        {
        }
        //O(n)|O(1)
        public bool hasSingleCycle(int[] input)
        {
            int numberofItemVisited = 0;
            int currentIndex = 0;
            while (numberofItemVisited < input.Length)
            {
                if (numberofItemVisited > 0 && currentIndex == 0)
                {
                    return false;
                }
                numberofItemVisited++;
                currentIndex = getJumpIndex(currentIndex, input);
            }
            return currentIndex == 0;
        }

        private int getJumpIndex(int currentIndex, int[] input)
        {
            int jump = input[currentIndex];
            //mod operate reduce naive jumps example 26. No need to
            //jump 25 time but 25+1 the next element. The mod operator
            //rounds the jump. Tricky edge case. 
            currentIndex = (jump + currentIndex) % input.Length;
            //if negative -1 then add -1+len(array)
            return currentIndex >=0?currentIndex: currentIndex+input.Length;
        }
        public void findMissingnumber(int[] a)
        {
            // 1 2 4 5
            for (int i = 0; i < a.Length-1; i++)
            {
                int comp = a[i + 1] - a[i];
                if (comp==2)
                {
                    Console.WriteLine(a[i] + 1);
                }
            }

            //HashSet<int> lookUp = new HashSet<int>();

            //foreach (var item in a)
            //{
            //    lookUp.Add(item);
            //}
            //for (int i = 0; i < a.Length-1; i++)
            //{
            //    int comp = a[i] + 1;
            //    if (!lookUp.Contains(comp))
            //    {
            //        Console.WriteLine(comp);
            //    }
            //}
            
        }
        public List<ArrayList> Permutations(int[] array)
        {
            List<ArrayList> permuations = new List<ArrayList>();
            getPermutations(0, array, permuations);
            return permuations;
        }
        /*
         * Given arrival and departure times of all trains that reach a railway station,
         * find the minimum number of platforms required for the railway station so that no train waits.
         * int[] arrival = new int[]{ 900, 940, 950, 1100, 1500, 1800 }; 
            int[] departure = new int[]{ 910, 1200, 1120, 1130, 1900, 2000 }; 
         * *
         */
        //Time O(N) | Space O(N)
        public int MinPlatforms(int[] arrivals, int[] departures)
        {
            SortedDictionary<int, char> intervalMapping = new SortedDictionary<int, char>();
            foreach (var arrival in arrivals)
            {
                //Time Log(n)
                intervalMapping.Add(arrival, 'a');
            }
            foreach (var departure in departures)
            {
                intervalMapping.Add(departure, 'd');
            }
            int maxsoFar = 0;
            int plarformNeeded = 0;
            foreach (var item in intervalMapping)
            {
                if (intervalMapping[item.Key] == 'a')
                {
                    plarformNeeded++;
                }
                else
                {
                    plarformNeeded--;
                }
                maxsoFar = Math.Max(plarformNeeded, maxsoFar);
            }
            return maxsoFar == 0 ? 1 : maxsoFar;
        }
        private void getPermutations(int i, int[] array, List<ArrayList> permuations)
        {
            if (i == array.Length -1)
            {
                permuations.Add(new ArrayList(array));
            }
            else
            {
                for (int j = i; j < array.Length; j++)
                {
                    swap(i, j, array);
                    getPermutations(i + 1, array, permuations);
                    swap(i, j, array);

                }
            }
        }

        private void swap(int a,int b,int[] array)
        {
            int t = array[a];
            array[a] = array[b];
            array[b] = t;
        }
        public List<ArrayList> PowerSet(int[] array)
        {
            List<ArrayList> subsets = new List<ArrayList>();
            subsets.Add(new ArrayList());
            foreach (var element in array)
            {
                int length = subsets.Count;
                for (int i = 0; i < length; i++)
                {
                    var currentSubset = new ArrayList(subsets[i]);
                    currentSubset.Add(element);
                    subsets.Add(currentSubset);
                }
            }
            foreach (var elemment in subsets)
            {
                foreach (var item in elemment)
                {
                    Console.Write("," + item + ",");
                }
                Console.WriteLine("---------");
            }
            return subsets;
            
        }
        public int[] searchSortedMatrix(int[,] matrix ,int target)
        {
            int row = 0;
            //GetLenght(0) row 1 coluumn.
            int col = matrix.GetLength(1)-1;
            while (row <= matrix.GetLength(0)-1 && col>=0)
            {
                if (matrix[row,col] > target)
                {
                    col--;
                }
                else if (matrix[row, col] < target)
                {
                    row++;
                }
                else
                {
                    Console.Write(row+":"+col);
                    return new int[] { row, col };
                }
                
            }
            return new int[] { -1, -1 };
        }
        //O(n) Time and SPace O(n)
        public int[] LargestRange(int[] array)
        {
            Dictionary<int, bool> arrayMap = new Dictionary<int, bool>();
            int[] baseRange = new int[2];
            int maxSofar = 0;
            foreach (var num in array)
            {
                arrayMap.Add(num, true);
            }
            for (int i = 0; i < array.Length-1; i++)
            {
                int num = array[i];
                int currentLength = 1;
                if (!arrayMap[num])
                {
                    continue;
                }
                arrayMap[num] = false;
                int left = num-1;
                while (arrayMap.ContainsKey(left))
                {
                    currentLength++;
                    arrayMap[left] = false;
                    left--;

                }
                int right = num+1;
                while (arrayMap.ContainsKey(right))
                {
                    currentLength++;
                    arrayMap[right] = false;
                    right++;
                }

                if (currentLength>maxSofar)
                {
                    maxSofar = currentLength;
                    baseRange = new int[] { left + 1, right - 1 };
                }
            }
            return baseRange;
        }
        public int MinRewards(int[] array)
        {
            int[] rewards = new int[array.Length];
            Array.Fill(rewards, 1);
            int left = 1;
            while (left<array.Length-1)
            {
                if (array[left] > array[left-1])
                {
                    rewards[left] = rewards[left - 1] + 1;
                }
                left++;
            }
            int right = array.Length - 2;
            while (right>=0)
            {
                if (array[right] > array[right + 1])
                {
                    rewards[right] = Math.Max(rewards[right], rewards[right + 1]+1);
                }
                right--;
            }
            int sum = 0;
            Array.ForEach(rewards, delegate (int i) { sum += i; });
            return sum;
        }
        //public int MinPlatforms(int[] arrivals, int[] departures)
        //{
        //    Array.Sort(arrivals);
        //    Array.Sort(departures);
        //    int n = arrivals.Length;
        //    int platform = 1, result = 1;
        //    int i = 1, j = 0;
        //    while (i < n && j < n)
        //    {
        //        if (arrivals[i] <= departures[j])
        //        {
        //            platform++;
        //            i++;
        //        }
        //        else
        //        {
        //            platform--;
        //            j++;
        //        }
        //        if (platform > result)
        //        {
        //            result = platform;
        //        }
        //    }
        //    return result;
        //}
        //public int MinPlatforms(int[] arrivals, int[] departures)
        //{
        //    Array.Sort(arrivals);
        //    Array.Sort(departures);
        //    int i = 0, j = 0, plat = 0, count = 0;
        //    while (i<arrivals.Length)
        //    {
        //        if (arrivals[i]<departures[j])
        //        {
        //            count++;
        //            i++;
        //            plat = Math.Max(count, plat);
        //        }
        //        else
        //        {
        //            count--;
        //            j++;
        //        }
        //    }
        //    return plat;
            
        //}
        //Time O(N) | Space O(N)
        //public int MinPlatforms(int[] arrivals, int[] departures)
        //{
        //    SortedDictionary<int, char> intervalMapping = new SortedDictionary<int, char>();
        //    foreach (var arrival in arrivals)
        //    {
        //        //Time Log(n)
        //        intervalMapping.Add(arrival, 'a');
        //    }
        //    foreach (var departure in departures)
        //    {
        //        intervalMapping.Add(departure, 'd');
        //    }
        //    int maxsoFar = 0;
        //    int plarformNeeded = 0;
        //    foreach (var item in intervalMapping)
        //    {
        //        if (intervalMapping[item.Key] == 'a')
        //        {
        //            plarformNeeded++;
        //        }
        //        else
        //        {
        //            plarformNeeded--;
        //        }
        //        maxsoFar = Math.Max(plarformNeeded, maxsoFar);
        //    }
        //    return maxsoFar == 0?1:maxsoFar;
        //}
        //Need revision.
        public List<List<int>> maxSumIncreasingSubsequence(int[] array)
        {
            int[] sequences = new int[array.Length];
            Array.Fill(sequences, int.MinValue);
            int[] sums = (int[])array.Clone();
            int maxSumIdX = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int currentNum = array[i];
                for (int j = 0; j < i; j++)
                {
                    int otherNum = array[j];
                    if (otherNum<currentNum && sums[j]+ currentNum>=sums[i])
                    {
                        sums[i] = sums[j] + currentNum;
                        sequences[i] = j;
                    }
                }
                if (sums[i] >=sums[maxSumIdX])
                {
                    maxSumIdX = i;
                }
            }
            return BuildSequenceIncreasing(array, sequences, maxSumIdX, sums[maxSumIdX]);
        }

        private List<List<int>> BuildSequenceIncreasing(int[] array, int[] sequences, int currentIndex, int sums)
        {
            List<List<int>> sequencesList = new List<List<int>>();
            sequencesList.Add(new List<int>());
            sequencesList.Add(new List<int>());
            sequencesList[0].Add(sums);
            while (currentIndex!=int.MinValue)
            {
                sequencesList[1] = new List<int>() { 0, array[currentIndex] };
                currentIndex = sequences[currentIndex];
            }
            return sequencesList;
        }
        /*
         * Formula : if x == y pick diagonal + 1
         * else : Max(left,top)
         * */
        //O(nm) | O(nm)
        public void LongestCommonSubsequence(string x,string y)
        {
            int m = x.Length;
            int n = y.Length;
            int[,] lcs = new int[m + 1, n + 1];
            for (int i = 1; i <m+1; i++)
            {
                for (int j = 1; j<n+1; j++)
                {
                   
                    if (x[i-1] == y[j-1])
                    {
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                    }
                }
            }
            BuildSequenceforLCS(lcs, x);
        }

        private void BuildSequenceforLCS(int[,] lcs, string x)
        {
            List<char> sequence = new List<char>();
            int i = lcs.GetLength(0)-1; //row
            int j = lcs.GetLength(1)-1; //column
            while (i!=0 && j!=0)
            {
                //if currentVal coming from left move left
                if (lcs[i,j] == lcs[i-1,j])
                {
                    i--;
                }
                //if currentVal coming from right/top move top
                else if (lcs[i,j] == lcs[i,j-1])
                {
                    j--;
                }
                else
                {
                    sequence.Add(x[i - 1]);
                    i--;
                    j--;
                }
            }
        }
        //O(n)|O(1)
        public int MinimuJumps(int[]  array)
        {
            if (array.Length ==1)
            {
                return 0;
            }
            int maxReach = array[0];
            int jumps = 0;
            int steps = array[0];
            for (int i = 1; i < array.Length-1; i++)
            {
                maxReach = Math.Max(maxReach, array[i] + i);
                steps--;
                if (steps == 0)
                {
                    jumps++;
                    steps = maxReach - i;
                }
            }
            return jumps + 1;
        }
        //O(n)|O(n)
        public int WaterArea(int[] heights)
        {
            int n = heights.Length;
            int left = 0;
            int right = n-1;
            int leftMax=0, rightMax = 0;
            int[] leftmaxArray = new int[heights.Length];
            int[] rightmaxArray = new int[heights.Length];
            int[] water = new int[heights.Length];
            while (left<=right)
            {
                int currentHeight = heights[left];
                leftmaxArray[left] = leftMax;
                leftMax = Math.Max(currentHeight, leftMax);
                left++;
            }
            while (right>=0)
            {
                int currentHeight = heights[right];
                rightmaxArray[right] = rightMax;
                rightMax = Math.Max(currentHeight, rightMax);
                right--;
            }
            //find the minimum
            for (int i = 0; i < heights.Length-1; i++)
            {
                int min = Math.Min(leftmaxArray[i], rightmaxArray[i]);
                int currHeight = heights[i];
                if (currHeight < min)
                {
                    water[i] = min - currHeight;
                }
                else
                {
                    water[i] = 0;
                }
            }
            int total = 0;
            foreach (var item in water)
            {
                total += item;
            }
            return total;
        }
        public void KnapSackProblem(int[,] items,int capacity)
        {
            int[,] knapSackValues = new int[items.GetLength(0) + 1, capacity+1];
            for (int i = 1; i < items.GetLength(0)+1; i++)
            {
                int currentValueUnits = items[i - 1,0];
                int currentWeight = items[i - 1,1];
                for (int j = 0; j < capacity+1; j++)
                {
                    if (currentWeight > j)
                    {
                        knapSackValues[i, j] = knapSackValues[i - 1, j];
                    }
                    else
                    {
                        int w = currentWeight;
                        int v = currentValueUnits;
                        knapSackValues[i, j] = Math.Max(knapSackValues[i - 1, j], knapSackValues[i - 1, j - w] + v);
                    }
                }
            }
            getKnapSackSequenceBackTrack(knapSackValues, items, knapSackValues[items.GetLength(0), capacity]);
        }

        private void getKnapSackSequenceBackTrack(int[,] knapSackValues, int[,] items, int weights)
        {
            List<ArrayList> sequences = new List<ArrayList>();
            ArrayList totalWeight = new ArrayList();
            totalWeight.Add(weights);
            sequences.Add(totalWeight);
            sequences.Add(new ArrayList());
            int i = knapSackValues.GetLength(0)-1;
            int j = knapSackValues.GetLength(1) - 1;
            while (i>0)
            {
                if (knapSackValues[i,j] == knapSackValues[i-1,j])
                {
                    i--;
                }
                else
                {
                    sequences[1].Add(i - 1);
                    int weight = items[i - 1,1];
                    j -= weight;
                    i--;
                }
                if (j==0)
                {
                    break;
                }
            }

        }
        public string findMaxwithKSwaps(string input,int k,string max)
        {
            string str = input;
            int n = str.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    if (str[i] < str[j])
                    {
                        str = swap(i, j,str);
                        if (String.Compare(str, max) > 0)
                        {
                            max = str;
                        }
                        findMaxwithKSwaps(str, k - 1, max);
                        str = swap(i,j,str);
                    }
                }
            }
            return max;
        }
        public string swap(int a,int b,string str)
        {
            char[] newAraau = str.ToCharArray();
            char temp = newAraau[a];
            newAraau[a] = newAraau[b];
            newAraau[b] = temp;
            return new string(newAraau);
        }
        public int ShiftedBinarySearch(int[] array,int target)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left<right)
            {
                int leftNum = array[left];
                int rightNum = array[right];
                int middle = (left + right) / 2;
                int potentialMatch = array[middle];
                if (target == potentialMatch)
                {
                    return middle;
                }
                //if left half is sorted. expore left and right
                else if (leftNum < potentialMatch)
                {
                    if (target < potentialMatch && target>leftNum)
                    {
                        right = middle - 1;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
                //if right half is sorted explore right and left.
                else
                {
                    if (target > potentialMatch && target < rightNum)
                    {
                        //explore right
                        left = middle + 1;
                    }
                    else
                    {
                        //explore left
                        right = middle - 1;
                    }
                }
            }
            return -1;
        }
        public int ProductSum(List<object> nestArray,int multiplier = 1)
        {
            int sum = 0;
            foreach (var element in nestArray)
            {
                if (element is List<object>)
                {
                    sum += ProductSum((List<object>)element, multiplier+1);
                }
                else
                {
                    sum += (int)element;    
                }
            }
            return sum * multiplier;
        }
        public int ContiguousPrime(int[] arr, int n)
        {
            int max = arr.Max();
            bool[] prime = new bool[max + 1];
            Array.Fill<bool>(prime, true);
            Seive(prime, max);
            int curMax = 0, maxSofar = 0;
            for (int i = 0; i < n; i++)
            {
                int p = arr[i];
                if (prime[p] == false)
                {
                    curMax = 0;
                }
                else
                {
                    curMax++;
                    maxSofar = Math.Max(curMax, maxSofar);
                }

            }
            return maxSofar;
        }
        private void Seive(bool[] prime, int n)
        {
            for (int p = 2; p*p <= n; p++)
            {
                if (prime[p])
                {
                    for (int i = p*2; i <= n; i+=p)
                    {
                        prime[i] = false;
                    }
                }
            }
        }

       
    }
}
