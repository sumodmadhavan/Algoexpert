using System;
using System.Collections.Generic;

namespace Algoexpert
{
    public class MinHeap
    {
        List<int> minHeap = new List<int>();
        private List<int> input;
        public MinHeap(List<int> array)
        {
            input = array;
            minHeap = BuildHeap(input);
        }
        //O(n) | O(1)
        public List<int> BuildHeap(List<int> array)
        {
            int firstParentIndex = (array.Count - 2) / 2;
            for (int currentIndex = firstParentIndex; currentIndex >=0; currentIndex--)
            {
                SiftDown(currentIndex, array.Count - 1, array);
            }
            return array;
        }
        //O(log n) | O(1)
        public void SiftDown(int currentIndex,int endIndex,List<int> heap)
        {
            int left = currentIndex * 2 + 1;
            int right = currentIndex * 2 + 2;
            while (left <= endIndex)
            {
                right = currentIndex * 2 + 2;
                if (right <= endIndex == false)
                {
                    right = -1;
                }
                int indextoSwap;
                if (right!=-1 && heap[right]<heap[left])
                {
                    indextoSwap = right;
                }
                else
                {
                    indextoSwap = left;
                }
                if (heap[indextoSwap] < heap[currentIndex])
                {
                    swap(currentIndex, indextoSwap, heap);
                    currentIndex = indextoSwap;
                    left = currentIndex * 2 + 1;
                }
                else
                {
                    return;
                }
            }
        }
        //O(log n) | O(1)
        public void SiftUp(int currentIndex,List<int> heap)
        {
            int parentIndex = (currentIndex - 1) / 2;
            while (currentIndex>0 && heap[currentIndex] < heap[parentIndex])
            {
                swap(currentIndex, parentIndex, heap);
                currentIndex = parentIndex;
                parentIndex = (currentIndex - 1) / 2;
            }
        }
        public int Peek()
        {
            return minHeap[0];
        }
        public int remove()
        {
            int lastIndex = minHeap.Count - 1;
            swap(0,lastIndex, minHeap);
            int valuetoRemove = minHeap[lastIndex];
            minHeap.RemoveAt(lastIndex);
            lastIndex = minHeap.Count - 1;
            SiftDown(0, lastIndex, minHeap);
            return valuetoRemove;
        }
        public void insert(int value)
        {
            minHeap.Add(value);
            SiftUp(minHeap.Count - 1, minHeap);
        }
        public void swap(int i,int j,List<int> heap)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
        public void print()
        {
            for (int i = 0; i <= (minHeap.Count - 2) / 2; i++)
            {
                Console.WriteLine(" PARENT : " + minHeap[i]
                                 + " LEFT CHILD : " + minHeap[2 * i]
                                 + " RIGHT CHILD :" + minHeap[2 * i + 1]);
                Console.WriteLine();
            }
        }
        public void PrintHeap()
        {
            foreach (var item in minHeap)
            {
                Console.WriteLine(item);
            }
        }


    }
}
