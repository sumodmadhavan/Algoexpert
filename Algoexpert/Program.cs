using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algoexpert
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 2,3,5,7,8 };
            //int r = new ArrayOPerations().ContiguousPrime(arr,arr.Length);
            #region <<Infix>>
            //var text = "(33 + 5)*7*(3 + 99)/100";
            ////https://github.com/jdbrowndev/infix-expression-calculator/blob/master/InfixExpressionCalculator/InfixExpressionCalculator.cs
            //var result = ExpressionEvaluator.Expression.Evaluate(text);
            //Console.Write(result);
            #endregion
            #region <<MaxusingStack>>
            //MagoStack magoStack = new MagoStack();
            //magoStack.Push(1);
            //magoStack.Push(2);
            //magoStack.Push(3);
            //magoStack.Push(1);
            //Console.WriteLine(magoStack.getMax());
            //MaxStackVersion stackV = new MaxStackVersion();
            //for (int i = 0; i < 20; i++)
            //{
            //    var rand = new Random().Next(1, 20);
            //    stackV.Push(rand);

            //}
            //Console.Write(stackV.MaxVersion);
            //Console.Write(stackV.baseCount());
            #endregion
            #region LinkedList

            //Node first = new Node(1);
            //Node two = new Node(2);
            //Node three = new Node(3);
            //Node four = new Node(4);
            //Node five = new Node(5);
            //Node twoOne = new Node(21);
            //Node two2 = new Node(22);
            //DoubleLink dbLink = new DoubleLink();
            //dbLink.setHead(first);
            //dbLink.insertAfter(first, two);
            //dbLink.insertAfter(two, three);
            //dbLink.insertBefore(first, two2);
            //dbLink.insertAfter(three, four);
            //dbLink.insertAfter(four, five);
            //dbLink.insertAfter(four, twoOne);
            //dbLink.insertBefore(four, two2);
            //dbLink.remove(three);
            //dbLink.insertatPosition(4, new Node(11));
            //dbLink.removeNodeWithValue(21);
            //var result = getNodeValuesHeadToTail(dbLink);
            //var singleLL = new SingleLinkedList();
            ////create a loop
            ////singleLL.getNNode(8, singleLL.head).next = singleLL.getNNode(4, singleLL.head);
            ////Assert for 3
            ////singleLL.FindLoop(singleLL.head);
            ////singleLL.ReverseLinkedList(singleLL.head);
            //singleLL.removeKthNode(singleLL.head, 4);

            #endregion

            #region Fib

            Fibonaci fib = new Fibonaci(9);
            //var fibN = fib.getFibOptim(9);
            fib.GetFibwithProd(9);
            //Console.Write(fibN);
            //Console.Write(fibNP);
            //Console.Write(fib.MemoResult);
            #endregion

            #region BinarySearch
            // var binarySearch = new BinarySearch();
            #endregion

            #region FindThreeLarge

            //var result = new FindThreeLargeNum();
            #endregion

            #region sorting
            //int[] unorderList = { 9, 8, 7, 1, 4, 6, 21, 11, 15, 33, 28,0 };
            //var result = new Sorting();
            ////result.BubbleSort(unorderList);
            ////result.InsertionSort(unorderList);
            ////result.SelectionSort(unorderList);
            //int[] array = { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 };
            //var resultArray = result.SubArraySort(array);
            //var resQuick = result.QuickSort(unorderList);
            //Console.Write(resQuick);
            //var qs = result.QuickSelect(new int[] {43,24,37 }, 1);
            //Console.Write(qs);
            #endregion

            #region String OPerations

            //var result = new StringOperations();
            /*
            Console.WriteLine(result.IsPalindrome("abcdcba"));
            Console.WriteLine(result.IsPalindrome("malayalam"));
            Console.WriteLine(result.IsPalindrome("sumod"));
            */
            //var output = result.ceaserEncryptor("xyz", 2);

            #endregion

            #region <<SumOPerations>>
            var result = new SumOPerations();
            int[] array = { 0, -8, 9, 3, 7, 1, 6, -2, 4, -9 };
            int[] triplearray = { 1,2,2,2,4};
            result.FindThreenumSum(triplearray, 8);

            //int[] array = { 7, 6, 4, -1, 1, 2 };
            //var finalRes = result.FournumberSum(array, 16);
            //foreach (var item in finalRes)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region <<SmallestDifference>>
            //int[] first = { -1, 5, 10, 20, 28, 3 };
            //int[] second = { 26, 134, 135, 15, 17 };
            //var result = new SumOPerations();
            //int[] outPut = result.FindSmallestDifference(first, second);
            //Console.WriteLine(outPut[0].ToString(), outPut[1].ToString());
            #endregion

            #region <<BST Construction>>
            //BST test1 = new BST(10);
            //test1.InsertforBST(5).InsertforBST(15).InsertforBST(25).InsertforBST(2).InsertforBST(4).InsertforBST(22);
            //test1.ValidBST(test1, int.MinValue, int.MaxValue);
            //var result = InorderTraversal(test1, new List<int>());
            //bool valOut = IsArraySorted(result);
            //test1.InvertBinaryTree(test1);
            ////test1.InOrder(test1);
            //test1.InOrderIterative(test1);
            //Console.WriteLine("-----------------");
            //test1.PreOrder(test1);
            //Console.WriteLine("-----------------");
            //test1.PostOrder(test1);
            //Console.WriteLine("-----------------");
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            //test1.remove(25);
            //result = InorderTraversal(test1, new List<int>());
            //foreach (var item in result)
            //{
            //    Console.Write(item);
            //}
            #endregion

            #region <<Graph>>
            //BFS
            //Node test1 = new Node("A");
            //test1.AddChild("B").AddChild("C").AddChild("D");
            //test1.childrens[0].AddChild("E").AddChild("F");
            //test1.childrens[2].AddChild("G").AddChild("H");
            //test1.childrens[0].childrens[1].AddChild("I").AddChild("J");
            //test1.childrens[2].childrens[0].AddChild("K");
            //GraphOperations graph = new GraphOperations();
            //var result = graph.BreadthFirstSearch(test1);

            //DFS

            //Node dfsNode = new Node("A");
            ////dfsNode.AddChild("B").AddChild("C").AddChild("D");
            ////dfsNode.childrens[0].AddChild("E").AddChild("F");
            ////dfsNode.childrens[2].AddChild("G").AddChild("H");
            ////dfsNode.childrens[0].childrens[1].AddChild("I").AddChild("J");
            ////dfsNode.childrens[2].childrens[0].AddChild("K");

            ////simple depth test
            //dfsNode.AddChild("B");
            //dfsNode.childrens[0].AddChild("E");
            //dfsNode.childrens[0].childrens[0].AddChild("F");




            //GraphOperations dfs = new GraphOperations();
            //dfs.DepthFirstSearch(dfsNode, new List<string>());
            //dfs.DepthFirstSearchIterative(dfsNode, new List<string>());
            //var X1 = dfs.FindGraphEqual(dfsNode, new List<string>());
            //var X2 = dfs.FindGraphEqual(dfsNode, new List<string>());
            //var x3 = dfs.DepthFirstSearch(dfsNode, new List<string>());
            //var x4 = dfs.BreadthFirstSearch(dfsNode);
            //var isEqual = System.Linq.Enumerable.SequenceEqual(X1, X2);
            //var isEqual2 = System.Linq.Enumerable.SequenceEqual(X1, x4);



            #endregion

            #region <<MaxSumAdjacent>>
            //int[] array = { 7, 10, 12, 7, 9, 14 };
            //var result = new SumOPerations().MaxSubsetSumNoAdjacent(array);
            //Console.WriteLine(result);
            #endregion

            #region <<Coinchange>>
            //int amount = 10;
            //int[] coins = { 1, 5, 10,25 };
            ////var resultWays = new SumOPerations().CoingChangeWays(amount, coins);
            //var resultMin = new SumOPerations().MinimumCoinsDynamic(amount, coins);
            #endregion

            #region <<LevishteinDistance>>
            //new StringOperations().LevenshteinDistance("yabd", "abc");
            //new StringOperations().LevenshteinDistance("pqqrst", "qqttps");
            #endregion

            #region <<KadaneAlgo>>
            //new SumOPerations().KadaneAlogrith(new int[] { 3,4,-6,7,8 });
            #endregion

            #region <<Single Cycle Array>>
            //var result = new ArrayOPerations().hasSingleCycle(new int[] { 2, 3, 1, -4, -4, 2 });
            #endregion

            #region <<River Sizes>>
            //1,2,2,2,5
            //int[,] input = {
            //                    {1, 0, 0,1,0},
            //                    {1, 0, 1,0,0},
            //                    {0, 0, 1,0,1},
            //                    {1, 0, 1,0,1},
            //                    {1, 0, 1,1,0}
            //               };
            //var result = new RiverSizes().CindRiverSizers(input);
            //result.Sort();
            //foreach (var item in result)
            //{
            //    Console.Write(item + ",");
            //}
            ////2,1,3,1
            #endregion

            #region <<Heap>>
            //var input = new List<int> { 8, 12, 23, 17, 31, 30, 44, 102, 18 };
            //var minHeap = new MinHeap(input);
            //Console.WriteLine(minHeap.Peek());
            //minHeap.remove();
            //Console.WriteLine(minHeap.Peek());
            //Console.Write("----------\n");
            //minHeap.PrintHeap();
            //Console.Write("============\n");
            //var minHeapOptim = new MinHeapOptim();
            //////minHeapOptim.Push(8);
            //////minHeapOptim.Push(12);
            //////minHeapOptim.Push(23);
            //////minHeapOptim.Push(17);
            //////minHeapOptim.Push(31);
            //////minHeapOptim.Push(30);
            //////minHeapOptim.Push(44);
            //////minHeapOptim.Push(102);
            //////minHeapOptim.Push(18);
            //var inputOPtim = new List<int> { 8, 12, 23, 17, 31, 30, 44, 102, 18 };
            //var healR = minHeapOptim.Heapify(inputOPtim);
            //Console.WriteLine(minHeapOptim.Peek());
            //Console.WriteLine("Pop:" + minHeapOptim.Pop());
            //Console.WriteLine(minHeapOptim.Peek());
            //Console.WriteLine("---------");
            //minHeapOptim.PrintHeap();
            ////Max Heap
            //Console.WriteLine("Max Heap//////////////");
            //var maxinput = new List<int> { 8, 12, 23, 17, 31, 30, 44, 102, 18 };
            //var maxHeap = new MaxHeap();
            //maxHeap.Heapify(maxinput);
            ////maxHeap.Push(8);
            ////maxHeap.Push(12);
            ////maxHeap.Push(23);
            ////maxHeap.Push(17);
            ////maxHeap.Push(31);
            ////maxHeap.Push(30);
            ////maxHeap.Push(44);
            ////maxHeap.Push(102);
            ////maxHeap.Push(18);
            //Console.WriteLine(maxHeap.Peek());
            //Console.WriteLine("Pop:" + maxHeap.Pop());
            //Console.WriteLine(maxHeap.Peek());
            //Console.WriteLine("---------");
            //maxHeap.PrintHeap();

            #endregion

            #region <<Permutations>>
            // var result = new ArrayOPerations().Permutations(new int[] { 1, 2, 3 });
            ////var result = new ArrayOPerations();
            ////var output = result.PowerSet(new int[] { 1, 2, 3 });
            ////int[,] matrix =
            ////{
            ////    { 1,4,7,12,5,1000},
            ////    { 2,5,19,31,32,1001},
            ////    { 3,8,24,33,35,1002},
            ////    { 40,41,42,44,45,1003},
            ////    { 99,100,103,106,128,1004}
            ////};
            ////var res = new ArrayOPerations().searchSortedMatrix(matrix, 44);
            //#endregion

            //#region <<MinMax Stack>>
            ////var result = new Stack();
            ////result.pushDTO(5);
            ////result.pushDTO(7);
            ////result.pushDTO(2);
            ////result.popDTO();
            ////var min = result.getMinDTO();
            ////var max = result.getMaxDTO();
            ////Console.Write(min);
            ////Console.Write(max);

            //var minMaxStack = new MinMaxStack();
            //minMaxStack.Push(5);
            //minMaxStack.Push(7);
            //minMaxStack.Push(2);
            //minMaxStack.Push(21);
            //minMaxStack.Push(11);
            //minMaxStack.Push(14);
            //var p = minMaxStack.Pop();
            //var p1 = minMaxStack.Pop();
            //var p2 = minMaxStack.Pop();
            //var min = minMaxStack.getMin();
            //var max = minMaxStack.getMax();
            //Console.Write(min);
            //Console.Write(max);


            //result.pop();
            //Console.Write("min {0}:max {1}", min, max);
            //result.BalanceBrackets("({}[])");
            //result.BalanceBracketsClean("({}[])");
            //var outp = result.CountBalancedBracket("(()(()))");
            ////var outp = result.CountBalancedBracket("()()()");
            ////var outp = result.CountBalancedBracket("(()()())");
            ////var outp = result.CountBalancedBracket("(()(()))");
            //Console.Write(outp);

            #endregion

            #region <<Longest Palindrome>>
            //var res = new StringOperations();
            //res.longestPalindromeString("abaxyzzyxf");
            #endregion

            #region <<Suffix Trie>>
            //var result = new SuffixTrie("babc");
            //var oup = result.searchTrie("abc");
            //Console.Write(oup);
            #endregion

            #region <<LargestRange>>
            //int[] array = {1,11,3,0,15,5,2,4,10,7,12,6};
            //var resultOut = new ArrayOPerations().LargestRange(array);
            #endregion

            #region <<MinRewards>>
            //int[] array = { 8, 4, 2, 1, 3, 6, 7, 9, 5 };
            //var result = new ArrayOPerations();
            //int minRe = result.MinRewards(array);
            #endregion

            #region <<MinPlatforms>>
            //int[] arr = {900, 940, 950, 1100,
            //                     1500, 1800};
            //int[] dep = {910, 1200, 1120, 1130,
            //                     1900, 2000};
            //int[] arr = { 2200, 2300 };
            //int[] dep = { 200, 300 };
            //var result = new ArrayOPerations();
            //int plat = result.MinPlatforms(arr, dep);
            #endregion

            #region <<MaxPath Sum>>
            //Need revision. For test.
            //var root = new BST(1);
            //root.InsertforBT(2).InsertforBT(3).InsertforBT(4).InsertforBT(5).InsertforBT(6).InsertforBT(7);
            //var result = root.MaxPathSum(root);
            #endregion

            #region<<LCS>>
            //string s1 = "xkykzpw";
            //string s2 = "zxvvyzw";
            //var lcs = new ArrayOPerations();
            //lcs.LongestCommonSubsequence(s1, s2);

            #endregion
            #region <<MinJumps>>
            //int[] arr = { 3, 4, 2, 1, 2, 3, 7, 1, 1, 13 };
            //var result = new ArrayOPerations();
            //Console.Write(result.MinimuJumps(arr));
            #endregion
            #region <<WaterArea>>
            //int[] arr = { 0, 8, 0, 0, 5, 0, 0, 10, 0, 0, 1, 1, 0, 3 };
            //_ = new ArrayOPerations().WaterArea(arr);
            #endregion
            #region <<Knapsack Problem>>
            //int[,] array = { { 1, 2 }, { 4, 3 }, { 5, 6 }, { 6, 7 } };
            //new ArrayOPerations().KnapSackProblem(array, 10);
            #endregion
            #region<<MaxwithKSwaps>>
            //string s = "129814999";
            //int k = 4;
            //string m = s;
            //var kr = new ArrayOPerations();
            //var result = kr.findMaxwithKSwaps(s, k, m);

            #endregion

            #region <<ShiftedBinarySearch>>
            //int[] array = { 45, 61, 71, 72, 0, 1, 21, 33, 45 };
            //int target = 33;
            //var s = new ArrayOPerations();
            //int result = s.ShiftedBinarySearch(array, target);
            //Console.Write(array[result]);
            #endregion

            #region <ProductSum>>
            //var one = new List<object> { 7, -1 };
            //var two = new List<object> { 6,new List<object> { -13,8}, 4 };
            //List<object> arrauNested = new List<object>{ 5, 2, one,3, two};
            //var resul = new ArrayOPerations().ProductSum(arrauNested);
            #endregion

            #region <<LongestSubstringwithoutDups>>
            //_ = new StringOperations().LongestSubstringwithoutDuplicatesOptim("clementisacap");
            #endregion

            #region <<Search Range>>
            //int[] input = { 0, 1, 21, 33, 45, 45, 45, 45, 45, 45, 61, 71, 73 };
            //BinarySearch binarySearch = new BinarySearch();
            //var r1 = binarySearch.SearchForRange(input, 45);

            #endregion

            #region <<Find Max - Min in K Elements
            //            int[] input = {10,
            //4,
            //1,
            //2,
            //3,
            //4,
            //10,
            //20,
            //30,
            //40,
            //100,
            //200 };
            //            _ = maxMin(3, input);
            #endregion
            #region <<FindMissingNumber>>
            //new ArrayOPerations().findMissingnumber(new int[] { 54,55,57,58,60,62});
            #endregion

        }
        static int maxMin(int k, int[] arr)
        {

            Array.Sort(arr);
            int n = arr.Length - 1;
            int answer = int.MaxValue;
            for (int i = 0; i + k - 1 < n; i++)
            {
                answer = Math.Min(answer,arr[i + k - 1]-arr[i]);
            }
            return answer;

        }
        private static bool IsArraySorted(List<int> result)
        {
            for (int i = 1; i < result.Count; i++)
            {
                if (result[i] < result[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        private static List<int> getNodeValuesHeadToTail(DoubleLink linkedList)
        {
            List<int> values = new List<int>();
            Node node = linkedList.head;
            while (node != null)
            {
                values.Add(node.value);
                node = node.next;
            }
            return values;
        }
        private static List<int> InorderTraversal(BST tree,List<int> array)
        {
            if (tree.left!=null)
            {
               InorderTraversal(tree.left, array);
            }
            Console.WriteLine(tree.value);
            array.Add(tree.value);
            if (tree.right != null)
            {
                InorderTraversal(tree.right, array);
            }
            return array;
        }
    }
}
