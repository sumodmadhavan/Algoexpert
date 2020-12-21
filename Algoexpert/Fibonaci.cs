using System;
using System.Collections;
using System.Collections.Generic;

namespace Algoexpert
{
    public class Fibonaci
    {

        Hashtable hashtable = new Hashtable();
        public int MemoResult { get; set; }
        public  Fibonaci()
        {
            
        }
        public Fibonaci(int n)
        {
            hashtable.Add(1, 0);
            hashtable.Add(2, 1);
            MemoResult = getFibMem(n, hashtable);
        }
        public int getFib(int n)
        {
            
            if (n == 2)
            {
                return 1;
            }
            else if(n == 1)
            {
                return 0;
            }
            else
            {
                return getFib(n - 1) + getFib(n - 2);
            }
        }
        public int getFibMem(int n, Hashtable hashtable)
        {
            if (hashtable.ContainsKey(n))
            {
                return (int)hashtable[n];
            }
            else
            {
                var computation = getFibMem(n - 1,hashtable) + getFibMem(n - 2,hashtable);
                hashtable.Add(n, computation);
                return (int)hashtable[n];
            }
        }
        //O(n)|O(1)
        public int getFibOptim(int n)
        {
            int[] lastTwo = { 0, 1 };
            int counter = 3;
            while (counter <=n)
            {
                Console.Write(lastTwo[1] + " ");
                int nextFib = lastTwo[0] + lastTwo[1];
                lastTwo[0] = lastTwo[1];
                lastTwo[1] = nextFib;
                counter++;
            }
            return n > 1 ? lastTwo[1] : lastTwo[0];
        }
        public int getFibOptimProd(int n)
        {
            int[] lastTwo = { 0, 1 };
            int counter = 3;
            int prod = 1;
            Queue<int> hash = new Queue<int>();
            while (counter <= n)
            {
                hash.Enqueue(lastTwo[1]);
                Console.Write(lastTwo[1] + " ");
                int nextFib = lastTwo[0] + lastTwo[1];
                lastTwo[0] = lastTwo[1];
                lastTwo[1] = nextFib;
                counter++;
            }
            Console.WriteLine("------");
            while (hash.Count>0)
            {
                prod *= hash.Dequeue();
                Console.Write(prod+",");
            }
            
            return n > 1 ? lastTwo[1] : lastTwo[0];
        }
        //Time : O(n) | Space O(1)
        public List<int> GetFibwithProd(int n)
        {
            if (n <= 1)
                return null; ;
            List<int> finalArray = new List<int>();
            int a = 0, b = 1,p = b;
            Queue<int> hash = new Queue<int>();
            while (n-- > 1)
            {
                Console.Write(b + ",");
                
                int sum = a + b;
                a = b;
                b = sum;
                hash.Enqueue(b);
            }
            Console.WriteLine("=========");
            while (hash.Count>0)
            {
                finalArray.Add(p);
                Console.Write(p + ",");
                p *= hash.Dequeue();
            }
            return finalArray;
        }
    }
}
